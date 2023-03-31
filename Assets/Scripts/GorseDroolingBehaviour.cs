using UnityEngine;

public class GorseDroolingBehaviour : MonoBehaviour
{
	public ParticleSystem ParticleSystem;

	public LimbBehaviour LimbBehaviour;

	private ParticleSystem.EmissionModule emission;

	public LayerMask CanSee;

	private int step;

	private bool isAlive;

	public GameObject Projectile;

	public AudioClip[] FireClip;

	public float Range;

	public float Force;

	private static readonly Collider2D[] buffer = new Collider2D[32];

	private void Start()
	{
		emission = ParticleSystem.emission;
	}

	private void FixedUpdate()
	{
		step++;
		if (step > 30)
		{
			isAlive = LimbBehaviour.Person.IsAlive();
			emission.enabled = isAlive;
			if (isAlive && LimbBehaviour.IsCapable)
			{
				AttackNearby();
			}
		}
	}

	private void AttackNearby()
	{
		step = 0;
		int num = Physics2D.OverlapCircleNonAlloc(base.transform.position, Range, buffer, CanSee);
		if (num == 0)
		{
			return;
		}
		Collider2D collider2D = buffer[Random.Range(0, num)];
		AliveBehaviour value;
		if (AliveBehaviour.AliveByTransform.TryGetValue(collider2D.transform.root, out value) && !(value.transform.root.name == base.transform.root.name) && value.IsAlive())
		{
			Vector3 v = base.transform.position - collider2D.transform.position;
			Utils.LaserHit laserHit = Utils.MaterialAwareRaycast(collider2D.transform.position, v, Range, CanSee);
			if ((bool)laserHit.physicalBehaviour && laserHit.physicalBehaviour.transform.root == base.transform.root)
			{
				UnityEngine.Debug.DrawLine(base.transform.position, collider2D.transform.position);
				LimbBehaviour.Person.Wince(15f);
				Fire(-v.normalized, v.magnitude * Force);
			}
		}
	}

	private void Fire(Vector3 direction, float force)
	{
		LimbBehaviour.PhysicalBehaviour.PlayClipOnce(FireClip.PickRandom());
		GameObject gameObject = UnityEngine.Object.Instantiate(Projectile, base.transform.position, Quaternion.identity);
		gameObject.GetComponent<Rigidbody2D>().AddForce(direction * force, ForceMode2D.Impulse);
		Collider2D[] componentsInChildren = base.transform.root.GetComponentsInChildren<Collider2D>();
		foreach (Collider2D b in componentsInChildren)
		{
			IgnoreCollisionStackController.IgnoreCollisionSubstituteMethod(gameObject.GetComponent<Collider2D>(), b);
		}
	}
}
