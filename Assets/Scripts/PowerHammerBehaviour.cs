using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class PowerHammerBehaviour : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003C_003Ec__DisplayClass14_0
	{
		public Vector2 dir;

		public Vector2 affectingForce;

		public PowerHammerBehaviour _003C_003E4__this;
	}

	private static readonly ContactPoint2D[] buffer = new ContactPoint2D[4];

	private static readonly Collider2D[] collbuffer = new Collider2D[64];

	private float lastImpactTime = float.MinValue;

	[SerializeField]
	private Collider2D powerImpactCollider;

	[SerializeField]
	private AudioSource mainAudioSource;

	[SerializeField]
	private PhysicalBehaviour physicalBehaviour;

	[SkipSerialisation]
	public AudioClip[] ImpactClips;

	[SkipSerialisation]
	public float ForceMultiplier = 1f;

	[SkipSerialisation]
	public float Range = 1f;

	[SkipSerialisation]
	public float CameraShakeIntensity = 3f;

	[SkipSerialisation]
	public float RequiredImpactForce = 15f;

	[SkipSerialisation]
	public LayerMask LayersToConsider;

	[SkipSerialisation]
	public float ImpactCharge;

	[SkipSerialisation]
	public GameObject HammerEffectPrefab;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		_003C_003Ec__DisplayClass14_0 _003C_003Ec__DisplayClass14_ = default(_003C_003Ec__DisplayClass14_0);
		_003C_003Ec__DisplayClass14_._003C_003E4__this = this;
		if (Time.time - lastImpactTime < 1f || collision.otherCollider != powerImpactCollider)
		{
			return;
		}
		float num = Utils.GetMinImpulse(buffer, collision.GetContacts(buffer));
		if (collision.gameObject.TryGetComponent(out LimbBehaviour _))
		{
			num *= 12f;
		}
		if (num <= RequiredImpactForce)
		{
			return;
		}
		ContactPoint2D contact = collision.GetContact(0);
		Vector2 normal = contact.normal;
		Vector2 point = contact.point;
		float z = Mathf.Atan2(normal.y, normal.x) * 57.29578f - 90f;
		GameObject gameObject = UnityEngine.Object.Instantiate(HammerEffectPrefab, point, Quaternion.Euler(0f, 0f, z));
		Vector3 up = base.transform.up;
		if (Vector2.SignedAngle(normal, up) > 0f)
		{
			gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
		}
		float num2 = Mathf.Max(base.transform.localScale.x, base.transform.localScale.y);
		_003C_003Ec__DisplayClass14_.dir = (Vector2)gameObject.transform.right.normalized * (float)((gameObject.transform.localScale.x > 0f) ? 1 : (-1));
		gameObject.transform.localScale *= num2;
		mainAudioSource.PlayOneShot(ImpactClips.PickRandom());
		CameraShakeBehaviour.main.Shake(CameraShakeIntensity * num2, base.transform.position);
		_003C_003Ec__DisplayClass14_.affectingForce = _003C_003Ec__DisplayClass14_.dir * ForceMultiplier * num2;
		_003C_003Ec__DisplayClass14_.affectingForce *= Mathf.Max(1f, physicalBehaviour.Charge);
		_003COnCollisionEnter2D_003Eg__applyForce_007C14_0(collision.collider, ref _003C_003Ec__DisplayClass14_);
		Vector2 pointA = point - normal;
		Vector2 pointB = point + _003C_003Ec__DisplayClass14_.dir * Range * num2 + normal * 3f;
		int num3 = Physics2D.OverlapAreaNonAlloc(pointA, pointB, collbuffer, LayersToConsider);
		for (int i = 0; i < num3; i++)
		{
			if (collbuffer[i].gameObject != base.gameObject)
			{
				_003COnCollisionEnter2D_003Eg__applyForce_007C14_0(collbuffer[i], ref _003C_003Ec__DisplayClass14_);
			}
		}
		ExplosionCreator.CreatePulseExplosion(point, 2f * (physicalBehaviour.Charge + 1f), 2f, soundAndEffects: false);
		lastImpactTime = Time.time;
	}

	[CompilerGenerated]
	private void _003COnCollisionEnter2D_003Eg__applyForce_007C14_0(Collider2D e, ref _003C_003Ec__DisplayClass14_0 P_1)
	{
		e.SendMessage("Break", P_1.dir, SendMessageOptions.DontRequireReceiver);
		if ((bool)e.attachedRigidbody)
		{
			e.attachedRigidbody.AddForce(P_1.affectingForce * e.attachedRigidbody.mass, ForceMode2D.Impulse);
		}
		if (Global.main.PhysicalObjectsInWorldByTransform.TryGetValue(e.transform, out PhysicalBehaviour value))
		{
			value.Charge += ImpactCharge;
		}
	}
}
