using UnityEngine;

public class NoCollideWithBodyPart : MonoBehaviour
{
	[SkipSerialisation]
	public LimbBehaviour.BodyPart BodyPart;

	[SkipSerialisation]
	public Collider2D Collider;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		LimbBehaviour component;
		if (!(collision.otherCollider != Collider) && collision.transform.TryGetComponent(out component) && component.RoughClassification == BodyPart)
		{
			IgnoreCollisionStackController.IgnoreCollisionSubstituteMethod(Collider, collision.collider);
		}
	}
}
