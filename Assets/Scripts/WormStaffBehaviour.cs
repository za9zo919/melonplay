using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class WormStaffBehaviour : MonoBehaviour
{
	private class Worm
	{
		public Vector2 velocity;

		public Vector2 endPosition;

		public Vector2 originalEndpos;

		public LineRenderer lineRenderer;

		public Vector3[] vertices;

		public float seed;

		public Worm(LineRenderer lineRenderer, float seed)
		{
			this.lineRenderer = lineRenderer;
			this.seed = seed;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003C_003Ec__DisplayClass12_0
	{
		public Collider2D target;

		public Vector2 worldEndPos;

		public Worm worm;
	}

	[SkipSerialisation]
	public int VertexCount = 4;

	[SkipSerialisation]
	public float Range;

	[SkipSerialisation]
	public float Damage;

	[SkipSerialisation]
	public float CutChance;

	[SkipSerialisation]
	public Vector3 Center;

	[SkipSerialisation]
	public LayerMask Layer;

	[SkipSerialisation]
	public Rigidbody2D Rigidbody;

	[SkipSerialisation]
	public LineRenderer[] LineRenderers;

	private Worm[] worms;

	private Collider2D[] collisionBuffer;

	private void Start()
	{
		collisionBuffer = new Collider2D[LineRenderers.Length + 1];
		worms = new Worm[LineRenderers.Length];
		for (int i = 0; i < LineRenderers.Length; i++)
		{
			worms[i] = new Worm(LineRenderers[i], UnityEngine.Random.value * 1000f);
		}
		float num = 0f;
		for (int j = 0; j < worms.Length; j++)
		{
			Worm worm = worms[j];
			Vector3 a = Vector2.zero;
			Vector3 vector = new Vector2(Mathf.Cos(num), Mathf.Sin(num)) * Range;
			worm.lineRenderer.positionCount = VertexCount;
			for (int k = 0; k < VertexCount; k++)
			{
				worm.lineRenderer.SetPosition(k, Vector3.Lerp(a, vector, (float)k / (float)VertexCount));
			}
			worm.endPosition = vector;
			worm.originalEndpos = vector;
			worm.vertices = new Vector3[VertexCount];
			worm.lineRenderer.GetPositions(worm.vertices);
			num += (float)Math.PI * 2f / (float)LineRenderers.Length;
		}
	}

	private void Update()
	{
		float num = Time.time * 1.2f;
		float num2 = Time.deltaTime * 60f;
		float num3 = Mathf.Pow(0.4f, num2);
		Vector2 point = base.transform.TransformPoint(Center);
		Vector2 pointVelocity = Rigidbody.GetPointVelocity(point);
		int collCount = Physics2D.OverlapCircleNonAlloc(point, Range, collisionBuffer, Layer);
		for (int i = 0; i < worms.Length; i++)
		{
			Worm worm = worms[i];
			worm.velocity += pointVelocity * -0.5f;
			if (!ActOnTarget(collCount, worm))
			{
				worm.velocity += worm.originalEndpos - worm.endPosition;
			}
			worm.velocity *= num3;
			worm.endPosition += (Vector2)base.transform.InverseTransformVector(0.01f * num2 * worm.velocity);
			worm.endPosition = Vector2.ClampMagnitude(worm.endPosition, Range * 1.5f);
			for (int j = 0; j < VertexCount; j++)
			{
				float num4 = (float)j / (float)VertexCount;
				worm.vertices[j] = Vector3.Lerp(Vector2.zero, worm.endPosition, num4) + 0.2f * num4 * Utils.GetPerlin2Mapped(num - (float)j * 0.1f, worm.seed);
			}
			worm.lineRenderer.SetPositions(worm.vertices);
		}
	}

	private bool ActOnTarget(int collCount, Worm worm)
	{
		_003C_003Ec__DisplayClass12_0 _003C_003Ec__DisplayClass12_ = default(_003C_003Ec__DisplayClass12_0);
		_003C_003Ec__DisplayClass12_.worm = worm;
		if (collCount <= 1)
		{
			return false;
		}
		_003C_003Ec__DisplayClass12_.target = collisionBuffer.PickRandom(collCount);
		if (_003C_003Ec__DisplayClass12_.target == null)
		{
			return false;
		}
		if (_003C_003Ec__DisplayClass12_.target.transform == base.transform)
		{
			return false;
		}
		_003C_003Ec__DisplayClass12_.worldEndPos = _003C_003Ec__DisplayClass12_.worm.lineRenderer.transform.TransformPoint(_003C_003Ec__DisplayClass12_.worm.endPosition);
		if (_003C_003Ec__DisplayClass12_.target.TryGetComponent(out LimbBehaviour component))
		{
			_003CActOnTarget_003Eg__moveToTargetAndTarget_007C12_0(component.PhysicalBehaviour.rigidbody, ref _003C_003Ec__DisplayClass12_);
			if (Mathf.PerlinNoise(_003C_003Ec__DisplayClass12_.worm.seed, Time.time * 15f) < CutChance)
			{
				component.Damage(Damage);
				component.CirculationBehaviour.StabWoundCount++;
				component.SkinMaterialHandler.AddDamagePoint(DamageType.Stab, _003C_003Ec__DisplayClass12_.worldEndPos, 6f);
				component.CirculationBehaviour.Cut(_003C_003Ec__DisplayClass12_.worldEndPos, UnityEngine.Random.insideUnitCircle);
			}
			return true;
		}
		if (_003C_003Ec__DisplayClass12_.target.TryGetComponent(out Rigidbody2D component2))
		{
			_003CActOnTarget_003Eg__moveToTargetAndTarget_007C12_0(component2, ref _003C_003Ec__DisplayClass12_);
			return true;
		}
		return false;
	}

	[CompilerGenerated]
	private static void _003CActOnTarget_003Eg__moveToTargetAndTarget_007C12_0(Rigidbody2D rb, ref _003C_003Ec__DisplayClass12_0 P_1)
	{
		Vector2 vector = P_1.target.bounds.ClosestPoint(P_1.worldEndPos);
		P_1.worm.velocity += vector - P_1.worldEndPos;
		rb.AddForceAtPosition(UnityEngine.Random.insideUnitCircle, vector);
	}
}
