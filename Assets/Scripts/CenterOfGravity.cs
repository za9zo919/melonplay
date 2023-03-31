using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CenterOfGravity : MonoBehaviour
{
	private Camera camera;

	public Renderer Renderer;

	public float SizeMultiplier = 0.25f;

	private bool shouldExist;

	private void Awake()
	{
		camera = Camera.main;
	}

	private void Update()
	{
		shouldExist = SelectionController.Main.SelectedObjects.Any((PhysicalBehaviour c) => c);
		Renderer.enabled = shouldExist;
		if (shouldExist)
		{
			base.transform.position = GetPosition(SelectionController.Main.SelectedObjects);
		}
		base.transform.localScale = camera.orthographicSize * SizeMultiplier * Vector3.one;
	}

	protected virtual Vector3 GetPosition(IEnumerable<PhysicalBehaviour> phys)
	{
		Vector3 a = Vector2.zero;
		float num = 0f;
		foreach (PhysicalBehaviour phy in phys)
		{
			if ((bool)phy)
			{
				num += phy.rigidbody.mass;
			}
		}
		foreach (PhysicalBehaviour phy2 in phys)
		{
			if ((bool)phy2)
			{
				if (phy2.rigidbody.bodyType != 0)
				{
					a += phy2.transform.position * phy2.rigidbody.mass;
				}
				else
				{
					Vector2 centerOfMass = phy2.rigidbody.centerOfMass;
					a += phy2.transform.localToWorldMatrix.MultiplyPoint3x4(centerOfMass / phy2.transform.lossyScale) * phy2.rigidbody.mass;
				}
			}
		}
		Vector3 vector = a / num;
		vector.x = vector.x.NaNFallback();
		vector.y = vector.y.NaNFallback();
		vector.z = vector.z.NaNFallback();
		return vector;
	}
}
