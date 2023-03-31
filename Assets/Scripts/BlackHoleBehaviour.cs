using UnityEngine;

public class BlackHoleBehaviour : MonoBehaviour
{
	public float RotationSpeed;

	public float AttractionForce = 150f;

	public float EffectRange = 4f;

	public float DeletionRange = 4f;

	private static readonly Collider2D[] buffer = new Collider2D[256];

	private int mask;

	private void Awake()
	{
		mask = Physics2D.GetLayerCollisionMask(base.gameObject.layer);
	}

	private void FixedUpdate()
	{
		int a = Physics2D.OverlapCircleNonAlloc(base.transform.position, EffectRange, buffer, mask);
		Vector3 position = base.transform.position;
		CameraShakeBehaviour.main.Shake(0.5f, base.transform.position, 0.5f);
		for (int i = 0; i < Mathf.Min(a, buffer.Length); i++)
		{
			Collider2D collider2D = buffer[i];
			if (!(collider2D.transform == base.transform) && (bool)collider2D.attachedRigidbody)
			{
				Vector3 a2 = position - collider2D.transform.position;
				float magnitude = a2.magnitude;
				Vector3 a3 = a2 / magnitude;
				collider2D.attachedRigidbody.AddForce(AttractionForce * collider2D.attachedRigidbody.mass * a3);
				PhysicalBehaviour value;
				if (!(magnitude > DeletionRange) && !collider2D.isTrigger && Global.main.PhysicalObjectsInWorldByTransform.TryGetValue(collider2D.transform, out value) && value.Deletable)
				{
					UnityEngine.Object.Destroy(collider2D.transform.root.gameObject);
				}
			}
		}
	}
}
