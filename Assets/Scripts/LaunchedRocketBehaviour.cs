using UnityEngine;

public class LaunchedRocketBehaviour : MonoBehaviour
{
	public float UnitsPerSecond = 1f;

	public float AccelerationPerSecond = 0.5f;

	public float MaxSpeed = 80f;

	private float Seed;

	public ParticleSystem relevantSystem;

	public float WaterSlowdown = 0.8f;

	public float ImmobilityFieldSlowdown = 0.8f;

	private LayerMask mask;

	private float f;

	public LayerMask ImmobiltyFieldLayer;

	private float speedMultiplier = 1f;

	public float WobbleIntensity = 1f;

	public ExplosionCreator.ExplosionParameters Explosion = new ExplosionCreator.ExplosionParameters(24u, Vector2.zero, 24f, 4f, createFx: true, big: true, 0.2f);

	private void Awake()
	{
		Seed = UnityEngine.Random.value * 1000f;
		mask = LayerMask.GetMask("Objects", "Bounds");
	}

	private void FixedUpdate()
	{
		if ((bool)Physics2D.OverlapPoint(base.transform.position, ImmobiltyFieldLayer))
		{
			speedMultiplier *= ImmobilityFieldSlowdown;
		}
		else
		{
			speedMultiplier = 1f;
		}
	}

	private void Update()
	{
		Vector3 vector = base.transform.right;
		if (WobbleIntensity > float.Epsilon)
		{
			vector += 0.25f * WobbleIntensity * new Vector3(Mathf.PerlinNoise(0f, 2f * Time.time + Seed) * 2f - 1f, Mathf.PerlinNoise(2f * Time.time - Seed, 5f) * 2f - 1f, 0f);
			vector.Normalize();
		}
		float num = (WaterBehaviour.IsPointUnderWater(base.transform.position) ? WaterSlowdown : 1f) * speedMultiplier;
		float num2 = Mathf.Min(MaxSpeed, (UnitsPerSecond + AccelerationPerSecond * f) * num) * Time.deltaTime;
		RaycastHit2D hit = Physics2D.Raycast(base.transform.position, vector, num2, mask);
		if ((bool)hit)
		{
			Vector2 v = hit.point + hit.normal * 0.05f;
			relevantSystem.transform.SetParent(null);
			relevantSystem.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
			relevantSystem.gameObject.AddComponent<DeleteAfterTime>().Life = 5f;
			UnityEngine.Object.Destroy(base.gameObject);
			Explosion.Position = v;
			ExplosionCreator.Explode(Explosion);
			hit.transform.SendMessage("Shot", new Shot(hit.normal, hit.point, 35f), SendMessageOptions.DontRequireReceiver);
			hit.transform.SendMessage("ExitShot", new Shot(hit.normal, hit.point, 35f), SendMessageOptions.DontRequireReceiver);
			hit.transform.SendMessage("Break", num2 * (Vector2)vector, SendMessageOptions.DontRequireReceiver);
		}
		else
		{
			base.transform.position += vector * num2;
		}
		f += Time.deltaTime;
	}
}
