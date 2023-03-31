using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Obsolete]
public class RaygunBehaviour : MonoBehaviour, Messages.IUse
{
	public Vector2 barrelPosition;

	public Vector2 barrelDirection;

	public LayerMask layersTohit;

	public LineRenderer beam;

	public AnimationCurve beamCurve;

	public AudioSource audioSource;

	public const int VertexCount = 16;

	private Vector3[] vertices = new Vector3[17];

	private Transform targetRoot;

	private Vector3 targetPosition;

	private float t;

	private bool activated;

	public void Use(ActivationPropagation activation)
	{
		activated = !activated;
		if (activated)
		{
			InitiateBlast();
		}
		else
		{
			StopBlast();
		}
	}

	private void StopBlast()
	{
		beam.enabled = false;
		audioSource.Stop();
	}

	private void InitiateBlast()
	{
		t = 0f;
		UpdateLineRenderer();
		beam.enabled = true;
		audioSource.Play();
	}

	private void FixedUpdate()
	{
		if (!activated)
		{
			return;
		}
		if (!targetRoot)
		{
			FindTarget();
		}
		else
		{
			targetRoot.BroadcastMessage("Raygunned", this, SendMessageOptions.DontRequireReceiver);
			if ((double)Vector2.Dot(GetBarrelDirection(), (targetPosition - base.transform.position).normalized) < 0.7)
			{
				targetRoot = null;
			}
			Burn();
		}
		UpdateLineRenderer();
	}

	private void Burn()
	{
		if (!targetRoot)
		{
			return;
		}
		t += Time.deltaTime;
		if (!(t > 1f))
		{
			return;
		}
		UnityEngine.Object.Instantiate(Resources.Load("Prefabs/RaygunExplosion"), targetPosition, Quaternion.identity);
		Rigidbody2D[] componentsInChildren = targetRoot.GetComponentsInChildren<Rigidbody2D>();
		foreach (Rigidbody2D rigidbody2D in componentsInChildren)
		{
			if ((double)UnityEngine.Random.value > 0.8)
			{
				UnityEngine.Object.Instantiate(Resources.Load("Prefabs/RaygunExplosion"), rigidbody2D.position, Quaternion.identity);
			}
		}
		PhysicalBehaviour[] componentsInChildren2 = targetRoot.GetComponentsInChildren<PhysicalBehaviour>();
		for (int i = 0; i < componentsInChildren2.Length; i++)
		{
			componentsInChildren2[i].BurnProgress = 1f;
		}
		DestroyableBehaviour[] componentsInChildren3 = targetRoot.GetComponentsInChildren<DestroyableBehaviour>();
		for (int i = 0; i < componentsInChildren3.Length; i++)
		{
			componentsInChildren3[i].Break();
		}
		targetRoot = null;
		t = 0f;
		activated = false;
		StopBlast();
	}

	private void FindTarget()
	{
		t = 0f;
		RaycastHit2D hit = Physics2D.Raycast(GetBarrelPosition(), GetBarrelDirection(), 250f, layersTohit);
		if ((bool)hit && (bool)hit.transform.GetComponent<PhysicalBehaviour>())
		{
			targetRoot = hit.transform.root;
			UpdateLineRenderer();
		}
	}

	private void UpdateLineRenderer()
	{
		Vector2 a = Vector2.zero;
		if ((bool)targetRoot)
		{
			IEnumerable<Vector2> enumerable = from c in targetRoot.GetComponentsInChildren<Rigidbody2D>()
				select c.position;
			foreach (Vector2 item in enumerable)
			{
				a += item;
			}
			a /= enumerable.Count();
		}
		else
		{
			RaycastHit2D hit = Physics2D.Raycast(GetBarrelPosition(), GetBarrelDirection(), 250f, layersTohit);
			a = ((!hit) ? (GetBarrelDirection() * 250f + GetBarrelPosition()) : hit.point);
		}
		targetPosition = a;
		CalculateCurve(GetBarrelPosition(), a, 16, ref vertices);
		beam.positionCount = 17;
		beam.SetPositions(vertices);
	}

	private void CalculateCurve(Vector3 pointA, Vector3 pointB, int vertexCount, ref Vector3[] vertices)
	{
		float d = Vector2.Distance(pointA, pointB);
		for (int i = 0; i < vertexCount; i++)
		{
			float time = (float)i / (float)vertexCount;
			Vector3 a = Vector3.Lerp(pointA, GetBarrelDirection() * d + GetBarrelPosition(), time);
			Vector3 vector = Vector3.Lerp(pointA, Vector3.Lerp(a, pointB, beamCurve.Evaluate(time)), time);
			vertices[i] = vector;
		}
		vertices[0] = pointA;
		vertices[vertexCount] = pointB;
	}

	public Vector2 GetBarrelPosition()
	{
		return base.transform.TransformPoint(barrelPosition);
	}

	public Vector2 GetBarrelDirection()
	{
		return base.transform.TransformDirection(barrelDirection) * base.transform.localScale.x;
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawRay(GetBarrelPosition(), GetBarrelDirection());
	}
}
