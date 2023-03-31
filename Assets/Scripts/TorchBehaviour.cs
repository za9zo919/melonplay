using System.Collections.Generic;
using UnityEngine;

public class TorchBehaviour : MonoBehaviour
{
	private HashSet<PhysicalBehaviour> currentlyColliding = new HashSet<PhysicalBehaviour>();

	public float TouchTemperature = 400f;

	public float TransferSpeed = 0.01f;

	private void OnEnable()
	{
		ContactPoint2D[] array = new ContactPoint2D[4];
		Collider2D[] componentsInChildren = GetComponentsInChildren<Collider2D>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			int contacts = componentsInChildren[i].GetContacts(array);
			for (int j = 0; j < contacts; j++)
			{
				Register(array[j].collider);
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (base.enabled && (bool)collision.rigidbody)
		{
			Register(collision.collider);
		}
	}

	private void Register(Collider2D c)
	{
		if ((bool)c.gameObject && Global.main.PhysicalObjectsInWorldByTransform.TryGetValue(c.transform, out PhysicalBehaviour value))
		{
			currentlyColliding.Add(value);
			value.Ignite(ignoreFlammability: true);
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (base.enabled && (bool)collision.rigidbody && (bool)collision.transform && Global.main.PhysicalObjectsInWorldByTransform.TryGetValue(collision.transform, out PhysicalBehaviour value))
		{
			currentlyColliding.Remove(value);
		}
	}

	private void FixedUpdate()
	{
		currentlyColliding.RemoveWhere((PhysicalBehaviour a) => !a);
		foreach (PhysicalBehaviour item in currentlyColliding)
		{
			item.Temperature = Mathf.Lerp(item.Temperature, TouchTemperature, TransferSpeed);
		}
	}
}
