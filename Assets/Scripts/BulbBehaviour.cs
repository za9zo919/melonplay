using NaughtyAttributes;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BulbBehaviour : MonoBehaviour, Messages.IUse, Messages.IOnFragmentHit, Messages.IOnEMPHit, Messages.IShot, Messages.IBreak
{
	[SkipSerialisation]
	[GradientUsage(true)]
	public Gradient FilamentColour;

	[SkipSerialisation]
	public float ChargeInfluence = 1f;

	[SkipSerialisation]
	public float MaximumTemperature = 300f;

	[SkipSerialisation]
	public GameObject OtherPart;

	[SkipSerialisation]
	public SpriteRenderer Filament;

	[SkipSerialisation]
	public SpriteRenderer LightSprite;

	[SkipSerialisation]
	public PhysicalBehaviour PhysicalBehaviour;

	[SkipSerialisation]
	public ParticleSystem Explosion;

	[SkipSerialisation]
	public Sprite BrokenSprite;

	[SkipSerialisation]
	public CircleCollider2D ColliderToDisable;

	[SkipSerialisation]
	public float MinimumImpactForce;

	[HideInInspector]
	public float FilamentHealth = 1f;

	[ReadOnly]
	public float FilamentTemp;

	[ReadOnly]
	public bool Broken;

	[ReadOnly]
	public bool Activated;

	private float seed;

	private void Start()
	{
		seed = UnityEngine.Random.Range(0, 1000);
		if (Broken)
		{
			Break(default(Vector2));
		}
	}

	private void Update()
	{
		FilamentTemp = Mathf.Max(0f, FilamentTemp);
		if (Mathf.Max(FilamentTemp, PhysicalBehaviour.Temperature) > MaximumTemperature)
		{
			Break(default(Vector2));
		}
	}

	private void FixedUpdate()
	{
		float filamentTemp = FilamentTemp;
		FilamentTemp = Mathf.Lerp(FilamentTemp, PhysicalBehaviour.Temperature, 0.005f);
		PhysicalBehaviour.Temperature = Mathf.Lerp(PhysicalBehaviour.Temperature, filamentTemp, 0.005f);
		if (Activated && !Broken && UnityEngine.Random.value > 0.005f)
		{
			FilamentTemp = Mathf.Max(FilamentTemp, Mathf.Lerp(FilamentTemp, MaximumTemperature * (0.5f + Mathf.Sqrt(PhysicalBehaviour.Charge * ChargeInfluence)), 0.5f));
		}
		else
		{
			FilamentTemp = Mathf.Lerp(FilamentTemp, 0f, 0.1f);
		}
	}

	private void OnWillRenderObject()
	{
		if (!Broken)
		{
			float num = FilamentTemp / MaximumTemperature;
			Color color = FilamentColour.Evaluate(num * num) * FilamentHealth;
			Filament.color = color;
			LightSprite.color = color;
		}
	}

	public void Use(ActivationPropagation activationPropagation)
	{
		Activated = !Activated;
	}

	public void OnFragmentHit(float force)
	{
		if (!Broken)
		{
			Break(default(Vector2));
		}
	}

	public void OnEMPHit()
	{
		FilamentHealth = 0f;
	}

	public void Shot(Shot shot)
	{
		if (!Broken)
		{
			StartCoroutine(_003CShot_003Eg__WaitAFrame_007C23_0());
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (!Broken && !(collision.contacts[0].normalImpulse < MinimumImpactForce))
		{
			if (Global.main.PhysicalObjectsInWorldByTransform.TryGetValue(collision.collider.transform, out PhysicalBehaviour value) && value.rigidbody.bodyType == RigidbodyType2D.Dynamic)
			{
				value.rigidbody.velocity = Vector2.Lerp(value.rigidbody.velocity, value.GetPreviousVel(), 1f);
			}
			Break(collision.otherRigidbody.velocity - collision.relativeVelocity);
		}
	}

	public void Break(Vector2 velocity)
	{
		if (!Broken)
		{
			Explosion.Play(withChildren: true);
			Explosion.GetComponentInChildren<ExplosionSoundBehviour>().Play();
			Broken = true;
		}
		if ((bool)OtherPart)
		{
			OtherPart.SetActive(value: true);
			OtherPart.transform.SetParent(null);
			OtherPart.GetOrAddComponent<DebrisComponent>();
			base.gameObject.GetOrAddComponent<DebrisComponent>();
		}
		PhysicalBehaviour.spriteRenderer.sprite = BrokenSprite;
		if ((bool)PhysicalBehaviour.selectionOutlineObject)
		{
			PhysicalBehaviour.selectionOutlineObject.GetComponent<SpriteRenderer>().sprite = BrokenSprite;
		}
		Filament.enabled = false;
		LightSprite.enabled = false;
		ColliderToDisable.enabled = false;
	}

	private void OnDestroy()
	{
		UnityEngine.Object.Destroy(OtherPart);
	}

	[CompilerGenerated]
	private IEnumerator _003CShot_003Eg__WaitAFrame_007C23_0()
	{
		yield return new WaitForSeconds(0.05f);
		Break(default(Vector2));
	}
}
