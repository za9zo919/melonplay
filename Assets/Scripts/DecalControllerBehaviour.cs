using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DecalControllerBehaviour : MonoBehaviour, Messages.IDecal
{
	public DecalDescriptor DecalDescriptor;

	[NonSerialized]
	[SkipSerialisation]
	public GameObject decalHolder;

	[NonSerialized]
	[SkipSerialisation]
	private bool dirty;

	[HideInInspector]
	public HashSet<Vector2> localDecalPositions = new HashSet<Vector2>();

	private SpriteMask spriteMask;

	private (int id, int order) originalSortingLayer;

	private void Awake()
	{
		dirty = false;
	}

	private void Start()
	{
		if (!DecalDescriptor)
		{
			UnityEngine.Object.Destroy(this);
			Debug.LogError("Decal controller has an invalid DecalDescriptor!");
		}
	}

	public void Clear()
	{
		localDecalPositions.Clear();
		if (!dirty)
		{
			return;
		}
		if ((bool)decalHolder)
		{
			foreach (Transform item in decalHolder.transform)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			UnityEngine.Object.Destroy(decalHolder);
		}
		dirty = false;
	}

	private void CreateContainer()
	{
		dirty = true;
		string n = DecalDescriptor.name + " container";
		Transform transform = base.transform.Find(n);
		if ((bool)transform)
		{
			decalHolder = transform.gameObject;
		}
		else
		{
			decalHolder = new GameObject(n);
		}
		decalHolder.transform.SetParent(base.transform);
		decalHolder.transform.localPosition = Vector3.zero;
		decalHolder.transform.localScale = Vector3.one;
		decalHolder.transform.localEulerAngles = Vector3.zero;
		decalHolder.GetOrAddComponent<Optout>();
		SpriteRenderer component = GetComponent<SpriteRenderer>();
		originalSortingLayer = (component.sortingLayerID, component.sortingOrder);
		SortingGroup orAddComponent = decalHolder.GetOrAddComponent<SortingGroup>();
		orAddComponent.sortingLayerID = originalSortingLayer.id;
		orAddComponent.sortingOrder = component.sortingOrder + 1;
		spriteMask = decalHolder.GetOrAddComponent<SpriteMask>();
		spriteMask.sprite = component.sprite;
		spriteMask.sortingOrder = component.sortingOrder + 1;
	}

	private bool IsNearOtherDecal(Vector2 localPosition)
	{
		Vector3 vector = base.transform.TransformPoint(localPosition);
		foreach (Vector2 localDecalPosition in localDecalPositions)
		{
			if ((vector - base.transform.TransformPoint(localDecalPosition)).sqrMagnitude < DecalDescriptor.IgnoreRadius * DecalDescriptor.IgnoreRadius)
			{
				return true;
			}
		}
		return false;
	}

	public void Decal(DecalInstruction instruction)
	{
		if (DecalDescriptor != instruction.type || !UserPreferenceManager.Current.Decals)
		{
			return;
		}
		if (!dirty)
		{
			CreateContainer();
		}
		if (!decalHolder)
		{
			return;
		}
		Vector2 vector = base.transform.InverseTransformPoint(instruction.globalPosition);
		if (!IsNearOtherDecal(vector))
		{
			GameObject obj = new GameObject("decal");
			obj.isStatic = true;
			obj.transform.SetParent(decalHolder.transform, worldPositionStays: true);
			obj.transform.localScale = decalHolder.transform.InverseTransformVector(instruction.size * UnityEngine.Random.Range(1f, 1.2f) * Vector3.one);
			obj.transform.localRotation = Quaternion.LookRotation(Vector3.forward, decalHolder.transform.InverseTransformDirection(Vector3.zero));
			obj.transform.localPosition = vector;
			SpriteRenderer spriteRenderer = obj.AddComponent<SpriteRenderer>();
			spriteRenderer.sprite = DecalDescriptor.Sprites.PickRandom();
			spriteRenderer.color = DecalDescriptor.Color * instruction.colourMultiplier;
			if (UserPreferenceManager.Current.GorelessMode)
			{
				Color color = spriteRenderer.color;
				spriteRenderer.color = Utils.ChangeRedToOrange(in color);
			}
			spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
			spriteRenderer.sortingLayerID = originalSortingLayer.id;
			spriteRenderer.sortingOrder = originalSortingLayer.order + 1;
			localDecalPositions.Add(vector);
		}
	}
}
