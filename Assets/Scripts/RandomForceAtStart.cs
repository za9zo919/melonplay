using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RandomForceAtStart : MonoBehaviour
{
	public float PositionalVelocityStrength = 5f;

	public float RotationalVelocityStrength = 5f;

	private void Start()
	{
		Rigidbody2D component = GetComponent<Rigidbody2D>();
		component.AddForce(UnityEngine.Random.insideUnitCircle * PositionalVelocityStrength, ForceMode2D.Impulse);
		component.AddTorque(UnityEngine.Random.Range(-1f, 1f) * RotationalVelocityStrength, ForceMode2D.Impulse);
		UnityEngine.Object.Destroy(this);
	}
}
