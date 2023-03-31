using System.Collections;
using UnityEngine;

public class WeatherLightningBehaviour : MonoBehaviour
{
	public float Width;

	public float Interval = 0.1f;

	public float Chance;

	public AudioClip[] Thunder;

	public AudioSource AudioSource;

	public SpriteRenderer LightSprite;

	private LayerMask mask;

	private Vector3[] vertices;

	public LineRenderer LineRenderer;

	private float t;

	private void Awake()
	{
		mask = LayerMask.GetMask("Objects", "Bounds");
		vertices = new Vector3[LineRenderer.positionCount];
		LightSprite.enabled = false;
	}

	private void Update()
	{
		if (Mathf.Approximately(Chance, 0f))
		{
			return;
		}
		t += Time.deltaTime;
		if (t > Interval)
		{
			t = 0f;
			if (UnityEngine.Random.value < Chance / 100f)
			{
				StartCoroutine(FireBolt());
			}
		}
	}

	private IEnumerator FireBolt()
	{
		Vector3 vector = base.transform.position + UnityEngine.Random.value * Width * Vector3.right;
		RaycastHit2D hit = Physics2D.Raycast(vector, Vector3.down, 10000f, mask);
		if ((bool)hit)
		{
			float x = UnityEngine.Random.value * 10000f;
			float num = hit.distance * 0.2f;
			LightSprite.transform.position = vector;
			AudioSource.PlayOneShot(Thunder.PickRandom());
			int num2 = vertices.Length;
			for (int j = 0; j < num2; j++)
			{
				float num3 = (float)j / (float)num2;
				float d = 1f - Mathf.Abs(2f * num3 - 1f);
				Vector3 a = (Utils.GetPerlin2Mapped(x, num3 / num * 19f) + (Vector3)UnityEngine.Random.insideUnitCircle * 0.2f) * d;
				vertices[j] = Vector3.Lerp(vector, hit.point, num3) + num * a;
			}
			LineRenderer.SetPositions(vertices);
			ExplosionCreator.CreateExplosionWithWater(WaterBehaviour.IsPointUnderWater(hit.point), new ExplosionCreator.ExplosionParameters(16u, hit.point, 35f, 12f, createFx: true, big: true));
			if (Global.main.PhysicalObjectsInWorldByTransform.TryGetValue(hit.transform, out PhysicalBehaviour value))
			{
				value.Charge += 1500f;
			}
			CameraShakeBehaviour.main.Shake(150f, hit.point, 0.1f);
			for (int i = 0; i < UnityEngine.Random.Range(2, 5); i++)
			{
				LineRenderer.enabled = true;
				LightSprite.enabled = true;
				yield return new WaitForSeconds(0.032f);
				LineRenderer.enabled = false;
				LightSprite.enabled = false;
				yield return new WaitForSeconds(UnityEngine.Random.Range(0.032f, 0.3f));
			}
		}
	}
}
