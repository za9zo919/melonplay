using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviour : MonoBehaviour, IManagedBehaviour
{
	internal static List<WaterBehaviour> waters = new List<WaterBehaviour>();

	public float Drag;

	public float Buoyancy;

	public float LocalSurfaceLevel;

	public GameObject[] ObjectsToBeActiveIfWater;

	public GameObject Splash;

	public GameObject BoilingWaterSound;

	public SpriteRenderer SpriteRenderer;

	public Collider2D Trigger;

	public LayerMask Layers;

	public PhysicalBehaviour Ice;

	private bool wasFrozen;

	private AudioClip[] waterSizzles;

	private HashSet<PhysicalBehaviour> frozenInIce = new HashSet<PhysicalBehaviour>();

	private Material mat;

	private static List<ParticleSystem> buffer = new List<ParticleSystem>(4);

	public bool IsEvaporated => PhysicalBehaviour.AmbientTemperature > 200f;

	public bool IsFrozen => PhysicalBehaviour.AmbientTemperature < 0f;

	public float GetGlobalSurfaceLevel()
	{
		return base.transform.TransformPoint(new Vector3(0f, LocalSurfaceLevel)).y;
	}

	private void Awake()
	{
		waters.Add(this);
	}

	private void OnDestroy()
	{
		waters.Remove(this);
	}

	private void Start()
	{
		SpriteRenderer = GetComponent<SpriteRenderer>();
		if (base.gameObject.activeInHierarchy)
		{
			waterSizzles = Resources.LoadAll<AudioClip>("Audio/water_sizzle");
		}
		UpdateTemperatureState();
	}

	public static bool IsPointUnderWater(Vector3 point)
	{
		for (int i = 0; i < waters.Count; i++)
		{
			WaterBehaviour waterBehaviour = waters[i];
			if (waterBehaviour.gameObject.activeInHierarchy && !waterBehaviour.IsEvaporated && !waterBehaviour.IsFrozen && waterBehaviour.IsPointInsideWater(point))
			{
				return true;
			}
		}
		return false;
	}

	public static WaterBehaviour GetWaterAtPoint(Vector3 point)
	{
		for (int i = 0; i < waters.Count; i++)
		{
			WaterBehaviour waterBehaviour = waters[i];
			if (waterBehaviour.gameObject.activeInHierarchy && waterBehaviour.IsPointInsideWater(point))
			{
				return waterBehaviour;
			}
		}
		return null;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!IsEvaporated && !IsFrozen)
		{
			DoSplash(collision);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (!IsEvaporated && !IsFrozen)
		{
			DoSplash(collision);
		}
	}

	private void DoSplash(Collider2D collision)
	{
		if (!UserPreferenceManager.Current.FancyEffects || collision.isTrigger || !Global.main.PhysicalObjectsInWorldByTransform.TryGetValue(collision.transform, out PhysicalBehaviour value))
		{
			return;
		}
		Rigidbody2D rigidbody = value.rigidbody;
		Vector2 velocity = rigidbody.velocity;
		if (Mathf.Abs(velocity.y) < 0.75f)
		{
			return;
		}
		GameObject gameObject = Splash.CompareTag("Poolable") ? PoolGenerator.Instance.RequestPrefab(Splash, Trigger.bounds.ClosestPoint(collision.transform.position)) : UnityEngine.Object.Instantiate(Splash, Trigger.bounds.ClosestPoint(collision.transform.position), Quaternion.identity);
		if (!gameObject)
		{
			return;
		}
		velocity.y = 0f - Mathf.Abs(velocity.y);
		gameObject.transform.up = Vector2.Reflect(velocity, Vector2.up);
		float num = Mathf.Min(collision.bounds.extents.x, 4f);
		float num2 = Mathf.Clamp(rigidbody.velocity.magnitude * 0.5f * rigidbody.mass, 0.2f, 25f);
		gameObject.GetComponent<AudioSource>().volume = num2 / 15f;
		gameObject.GetComponentsInChildren(buffer);
		for (int i = 0; i < buffer.Count; i++)
		{
			ParticleSystem particleSystem = buffer[i];
			if ((bool)particleSystem)
			{
				ParticleSystem.ShapeModule shape = particleSystem.shape;
				ParticleSystem.MainModule main = particleSystem.main;
				shape.radius = num;
				main.startSizeMultiplier = num * 2.5f * UnityEngine.Random.Range(1f, 1.4f);
				main.startSpeedMultiplier = num2;
			}
		}
	}

	private void UpdateObjectsToBeActiveIfWater(bool active)
	{
		for (int i = 0; i < ObjectsToBeActiveIfWater.Length; i++)
		{
			ObjectsToBeActiveIfWater[i].SetActive(active);
		}
		SpriteRenderer.enabled = active;
		GetComponent<SpriteMask>().enabled = active;
	}

	public void UpdateTemperatureState()
	{
		Ice.gameObject.SetActive(value: false);
		if (IsFrozen)
		{
			SetFrozen();
			return;
		}
		if (wasFrozen)
		{
			foreach (PhysicalBehaviour item in frozenInIce)
			{
				if ((bool)item && item.TryGetComponent(out FrozenInIceBehaviour component))
				{
					UnityEngine.Object.Destroy(component);
					FreezeStackController.RequestUnfreeze(item.rigidbody);
				}
			}
		}
		wasFrozen = false;
		frozenInIce.Clear();
		if (IsEvaporated)
		{
			SetEvaporated();
			return;
		}
		BoilingWaterSound.SetActive(PhysicalBehaviour.AmbientTemperature >= 100f);
		UpdateObjectsToBeActiveIfWater(active: true);
	}

	private void SetEvaporated()
	{
		BoilingWaterSound.SetActive(value: false);
		UpdateObjectsToBeActiveIfWater(active: false);
	}

	private void SetFrozen()
	{
		BoilingWaterSound.SetActive(value: false);
		wasFrozen = true;
		LayerMask mask = LayerMask.GetMask("Bounds");
		for (int i = 0; i < Global.main.PhysicalObjectsInWorld.Count; i++)
		{
			PhysicalBehaviour physicalBehaviour = Global.main.PhysicalObjectsInWorld[i];
			if (mask.HasLayer(physicalBehaviour.gameObject.layer) || frozenInIce.Contains(physicalBehaviour))
			{
				continue;
			}
			int num = 0;
			int num2 = physicalBehaviour.LocalColliderGridPoints.Length;
			for (int j = 0; j < physicalBehaviour.LocalColliderGridPoints.Length; j++)
			{
				Vector2 v = physicalBehaviour.LocalColliderGridPoints[j];
				Vector3 v2 = physicalBehaviour.transform.TransformPoint(v);
				if (IsPointInsideWater(v2))
				{
					num++;
					if ((float)num / (float)num2 >= 0.05f)
					{
						physicalBehaviour.rigidbody.velocity = default(Vector2);
						physicalBehaviour.rigidbody.angularVelocity = 0f;
						FreezeStackController.RequestFreeze(physicalBehaviour.rigidbody);
						frozenInIce.Add(physicalBehaviour);
						physicalBehaviour.gameObject.AddComponent<FrozenInIceBehaviour>();
						physicalBehaviour.Temperature = Mathf.Min(physicalBehaviour.Temperature, PhysicalBehaviour.AmbientTemperature);
						break;
					}
				}
			}
		}
		UpdateObjectsToBeActiveIfWater(active: false);
		SpriteRenderer.enabled = true;
		Ice.gameObject.SetActive(value: true);
	}

	public void ManagedFixedUpdate()
	{
		if (IsFrozen)
		{
			Ice.Temperature = PhysicalBehaviour.AmbientTemperature;
			bool flag = Time.frameCount % 2 == 0;
			foreach (PhysicalBehaviour item in frozenInIce)
			{
				if ((bool)item)
				{
					if (item.OnFire)
					{
						item.Extinguish();
					}
					if (flag)
					{
						bool flag2 = false;
						for (int i = 0; i < item.LocalColliderGridPoints.Length; i++)
						{
							Vector2 v = item.LocalColliderGridPoints[i];
							Vector3 v2 = item.transform.TransformPoint(v);
							if (IsPointInsideWater(v2))
							{
								flag2 = true;
								break;
							}
						}
						if (!flag2 && item.TryGetComponent(out FrozenInIceBehaviour component))
						{
							UnityEngine.Object.Destroy(component);
							FreezeStackController.RequestUnfreeze(item.rigidbody);
						}
					}
				}
			}
		}
		else
		{
			if (IsEvaporated)
			{
				return;
			}
			Vector3 a = Vector3.up * Buoyancy;
			float globalSurfaceLevel = GetGlobalSurfaceLevel();
			float num = Mathf.Min(PhysicalBehaviour.AmbientTemperature, 100f);
			bool flag3 = PhysicalBehaviour.AmbientTemperature >= 100f;
			for (int j = 0; j < Global.main.PhysicalObjectsInWorld.Count; j++)
			{
				PhysicalBehaviour physicalBehaviour = Global.main.PhysicalObjectsInWorld[j];
				if (!physicalBehaviour)
				{
					continue;
				}
				float num2 = Mathf.Clamp(Mathf.Pow(Mathf.Abs(physicalBehaviour.transform.position.y - globalSurfaceLevel), 0.25f), 1f, 8f);
				float num3 = Mathf.Clamp01((num2 - 1f) / 7f) + 1f;
				Vector2 force = physicalBehaviour.rigidbody.mass / (float)physicalBehaviour.LocalGridPointLength * num2 * (physicalBehaviour.Properties.Buoyancy * physicalBehaviour.BuoyancyModifier) * a;
				bool flag4 = false;
				physicalBehaviour.CurrentWaterSurfaceLevel = globalSurfaceLevel;
				for (int k = 0; k < physicalBehaviour.LocalColliderGridPoints.Length; k++)
				{
					Vector2 v3 = physicalBehaviour.LocalColliderGridPoints[k];
					Vector3 v4 = physicalBehaviour.transform.TransformPoint(v3);
					if (IsPointInsideWater(v4))
					{
						flag4 = true;
						if (!flag3)
						{
							physicalBehaviour.rigidbody.AddForceAtPosition(force, v4);
						}
						Vector2 pointVelocity = physicalBehaviour.rigidbody.GetPointVelocity(v4);
						physicalBehaviour.rigidbody.AddForceAtPosition(0.4f * num3 * GetDragFactor(pointVelocity) * physicalBehaviour.rigidbody.mass * -pointVelocity, v4);
					}
				}
				bool flag5 = !physicalBehaviour.IsUnderWater;
				if (flag4)
				{
					physicalBehaviour.underwaterMarkings++;
				}
				if (flag4)
				{
					if (flag3 && AliveBehaviour.AliveByTransform.TryGetValue(physicalBehaviour.transform.root, out AliveBehaviour value))
					{
						physicalBehaviour.BurnProgress = Mathf.Max(physicalBehaviour.BurnProgress, 0.5f);
						value.SendMessage("AddPain", 15f, SendMessageOptions.DontRequireReceiver);
					}
					physicalBehaviour.Temperature = Mathf.Lerp(physicalBehaviour.Temperature, num, 0.05f * physicalBehaviour.Properties.HeatTransferSpeedMultiplier);
					if (flag5 && physicalBehaviour.Temperature >= 100f && physicalBehaviour.Temperature > num * 2f)
					{
						physicalBehaviour.PlayClipOnce(waterSizzles.PickRandom());
						physicalBehaviour.Sizzle(withSound: false);
					}
					physicalBehaviour.Wetness += 0.1f;
					physicalBehaviour.SendMessage("WaterImpact", physicalBehaviour.rigidbody.velocity.magnitude, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}

	private float GetDragFactor(Vector2 velocity)
	{
		float num = velocity.sqrMagnitude * 0.1f;
		return Mathf.Clamp(Mathf.Pow(num + 1f, num * Drag), 0.2f, 1f);
	}

	private void OnWillRenderObject()
	{
		if (!mat)
		{
			mat = SpriteRenderer.material;
		}
		if ((bool)mat)
		{
			mat.SetFloat(ShaderProperties.Get("_Temperature"), PhysicalBehaviour.AmbientTemperature);
		}
	}

	private bool IsPointInsideWater(Vector2 point)
	{
		return Trigger.OverlapPoint(point);
	}

	public void ManagedUpdate()
	{
	}

	public void ManagedLateUpdate()
	{
	}

	public bool ShouldUpdate()
	{
		if (base.gameObject.activeInHierarchy)
		{
			return base.enabled;
		}
		return false;
	}
}
