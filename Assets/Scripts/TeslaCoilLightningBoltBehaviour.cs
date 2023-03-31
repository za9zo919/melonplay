using UnityEngine;

public class TeslaCoilLightningBoltBehaviour : MonoBehaviour
{
	[SkipSerialisation]
	public GameObject Spark;

	[SkipSerialisation]
	public Material LightningMaterial;

	[SkipSerialisation]
	public LineRenderer lineRenderer;

	public float seed;

	public float life;

	public LayerMask layer;

	[SkipSerialisation]
	public AnimationCurve curve;

	public float Radius = 6f;

	private PhysicalBehaviour target;

	private float t;

	private Vector2 randomOffset;

	[SkipSerialisation]
	public TeslaCoilBehaviour parent;

	private readonly Collider2D[] overlapBuffer = new Collider2D[32];

	private readonly Vector3[] positions = new Vector3[64];

	private Collider2D[] colliderArray;

	private void Awake()
	{
		lineRenderer = base.gameObject.GetComponent<LineRenderer>();
		lineRenderer.useWorldSpace = true;
		lineRenderer.sharedMaterial = LightningMaterial;
		lineRenderer.positionCount = positions.Length;
	}

	private void Init()
	{
		FindNewTarget();
		seed = UnityEngine.Random.Range(-9000f, 9000f);
		life = (((double)UnityEngine.Random.value > 0.95) ? UnityEngine.Random.Range(0.1f, 0.3f) : UnityEngine.Random.Range(0.02f, 0.08f));
		lineRenderer.widthMultiplier = UnityEngine.Random.Range(1f, 2f);
		randomOffset = UnityEngine.Random.insideUnitCircle * 4f;
	}

	private void FindNewTarget()
	{
		target = null;
		int num = Physics2D.OverlapCircleNonAlloc(base.transform.position, Radius, overlapBuffer, layer);
		if (num == 0)
		{
			return;
		}
		float num2 = 1E+07f;
		for (int i = 0; i < num; i++)
		{
			Collider2D collider2D = overlapBuffer[i];
			PhysicalBehaviour value;
			if ((bool)collider2D && !(collider2D.transform.root == base.transform.root) && Global.main.PhysicalObjectsInWorldByTransform.TryGetValue(collider2D.transform, out value) && value.Properties.Conducting)
			{
				float sqrMagnitude = (collider2D.transform.position - (base.transform.position + UnityEngine.Random.insideUnitSphere)).sqrMagnitude;
				if (sqrMagnitude < num2)
				{
					target = value;
					num2 = sqrMagnitude;
				}
			}
		}
		if ((bool)target)
		{
			colliderArray = target.GetComponents<Collider2D>();
		}
	}

	private void Update()
	{
		t += Time.smoothDeltaTime;
		if (t > life)
		{
			t = 0f;
			Init();
		}
		float num = t;
		Vector3 position = base.transform.position;
		Vector3 vector;
		if ((bool)target)
		{
			vector = target.transform.position;
			float num2 = float.MaxValue;
			Vector3 b = base.transform.position + (Vector3)randomOffset;
			Collider2D[] array = colliderArray;
			foreach (Collider2D collider2D in array)
			{
				if ((bool)collider2D)
				{
					Vector3 vector2 = collider2D.ClosestPoint(base.transform.position);
					float sqrMagnitude = (vector2 - b).sqrMagnitude;
					if (sqrMagnitude < num2)
					{
						num2 = sqrMagnitude;
						vector = vector2;
					}
				}
			}
			target.Charge += Time.deltaTime * 4f;
			target.rigidbody.AddForce(UnityEngine.Random.insideUnitCircle * 0.01f, ForceMode2D.Impulse);
			if (SmoothRandom(10f).x > 0.99f)
			{
				if ((bool)parent)
				{
					parent.PlaySparkSound();
				}
				Object.Instantiate(Spark, vector, Quaternion.identity);
			}
		}
		else
		{
			vector = UnityEngine.Random.insideUnitCircle * Radius + (Vector2)position;
		}
		for (int j = 0; j < lineRenderer.positionCount; j++)
		{
			float time = (float)j / (float)(lineRenderer.positionCount - 1);
			Vector3 vector3 = Vector3.Lerp(position, vector, time);
			Vector2 v = new Vector2(Mathf.PerlinNoise(vector3.x * 2f - seed, vector3.y * 2f + seed) * 2f - 1f, Mathf.PerlinNoise(vector3.x * 2f + seed, vector3.y * 2f - seed));
			Vector2 v2 = curve.Evaluate(time) * new Vector2(Mathf.PerlinNoise(vector3.x * 0.1f - seed, vector3.y * 0.1f + seed) * 2f - 1f, Mathf.PerlinNoise(vector3.x * 0.1f + seed, vector3.y * 0.1f - seed) * 2f - 1f);
			Vector3 b2 = 5.25f * num * (Vector3)v + (Vector3)v2 * 1.3f;
			positions[j] = vector3 + b2 + (Vector3)SmoothRandom(5f) * 0.02f;
		}
		lineRenderer.SetPositions(positions);
	}

	private Vector2 SmoothRandom(float frq = 1f)
	{
		float num = frq * Time.time;
		return new Vector2(Mathf.PerlinNoise(num, seed) * 2f - 1f, Mathf.PerlinNoise(seed, num) * 2f - 1f);
	}
}
