using System.Collections.Generic;
using UnityEngine;

public class PortalBehaviour : MonoBehaviour
{
	public PortalBehaviour OtherEnd;

	public TriggerEventBehaviour EntryTriggerEvent;

	public TriggerEventBehaviour ExitTriggerEvent;

	public SortingLayer Mask;

	private Dictionary<PhysicalBehaviour, SpriteRenderer> passingThrough = new Dictionary<PhysicalBehaviour, SpriteRenderer>();

	private GameObject objectRenderer;

	private void Awake()
	{
		objectRenderer = new GameObject("Portal clone renderer");
		objectRenderer.transform.position = Vector3.zero;
	}

	private void Start()
	{
		EntryTriggerEvent.OnTriggerEnter = StartPassage;
		ExitTriggerEvent.OnTriggerExit = StartExit;
	}

	public void StartPassage(Collider2D obj)
	{
		PhysicalBehaviour value;
		if (Global.main.PhysicalObjectsInWorldByTransform.TryGetValue(obj.transform, out value) && (bool)value && !passingThrough.ContainsKey(value))
		{
			SpriteRenderer spriteRenderer = new GameObject(obj.gameObject.name + " ghost").AddComponent<SpriteRenderer>();
			spriteRenderer.sprite = value.spriteRenderer.sprite;
			spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
			spriteRenderer.sortingLayerID = Mask.value;
			passingThrough.Add(value, spriteRenderer);
			value.gameObject.GetOrAddComponent<PortalTraversingBehaviour>().enabled = true;
		}
	}

	public void StartExit(Collider2D collision)
	{
		if (Global.main.PhysicalObjectsInWorldByTransform.TryGetValue(collision.transform, out PhysicalBehaviour value) && passingThrough.TryGetValue(value, out SpriteRenderer value2))
		{
			UnityEngine.Object.Destroy(value2.gameObject);
			passingThrough.Remove(value);
			if ((bool)value && value.gameObject.TryGetComponent(out PortalTraversingBehaviour component))
			{
				component.enabled = false;
			}
			else
			{
				UnityEngine.Debug.LogWarning("Attempt to disable a PortalTraversingBehaviour but it doesn't exist :(");
			}
		}
	}

	private void OnWillRenderObject()
	{
		if ((bool)OtherEnd)
		{
			RenderObjectClones();
		}
	}

	private void RenderObjectClones()
	{
		Transform transform = OtherEnd.transform;
		foreach (KeyValuePair<PhysicalBehaviour, SpriteRenderer> item in passingThrough)
		{
			PhysicalBehaviour key = item.Key;
			SpriteRenderer value = item.Value;
			if ((bool)key)
			{
				Vector3 a = base.transform.InverseTransformPoint(key.transform.position);
				Vector3 position = transform.TransformPoint(-a);
				Vector3 direction = base.transform.InverseTransformDirection(-key.transform.right);
				Vector3 right = transform.TransformDirection(direction);
				value.transform.position = position;
				value.transform.right = right;
				value.transform.localScale = key.transform.lossyScale;
			}
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawRay(base.transform.position, base.transform.right);
	}

	private void OnDestroy()
	{
		UnityEngine.Object.Destroy(objectRenderer);
	}
}
