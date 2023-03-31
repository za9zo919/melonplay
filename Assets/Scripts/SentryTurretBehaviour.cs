using UnityEngine;

public class SentryTurretBehaviour : MonoBehaviour, Messages.IOnEMPHit, Messages.IShot
{
	[SkipSerialisation]
	public SentryTurretControllable turretGun;

	[Space]
	[SkipSerialisation]
	public AudioClip[] TargetAcquired;

	[SkipSerialisation]
	public AudioClip[] TargetLost;

	[SkipSerialisation]
	public AudioClip[] Flying;

	[SkipSerialisation]
	public AudioClip[] ShotAt;

	[SkipSerialisation]
	public AudioClip[] OnFire;

	[SkipSerialisation]
	public AudioClip[] Tipped;

	[SkipSerialisation]
	public AudioClip[] Retiring;

	[Space]
	[SkipSerialisation]
	public AudioClip Alarm;

	[SkipSerialisation]
	public AudioClip Ping;

	[SkipSerialisation]
	public AudioClip Active;

	[SkipSerialisation]
	public AudioClip PistonDeploy;

	[SkipSerialisation]
	public AudioClip PistonRetract;

	[Space]
	[SkipSerialisation]
	public Collider2D SeeTrigger;

	[SkipSerialisation]
	public LayerMask BlockingLayers;

	[Space]
	[SkipSerialisation]
	public AudioSource AudioSource;

	public AliveBehaviour target;

	public LimbBehaviour limbTarget;

	public PhysicalBehaviour phys;

	public Transform directTarget;

	private Rigidbody2D rb;

	private Vector2 oldVelocity;

	public SentryTurretAIState State;

	private float soundTimer;

	private float deathTimer;

	[HideInInspector]
	public float timeStartedSearching;

	[HideInInspector]
	public bool disabled;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		phys = GetComponent<PhysicalBehaviour>();
		State = SentryTurretAIState.Idle;
	}

	private void Start()
	{
		if (disabled)
		{
			Disable();
		}
	}

	private void Update()
	{
		soundTimer += Time.deltaTime;
		if (State == SentryTurretAIState.Panicking)
		{
			deathTimer += Time.deltaTime;
		}
		else
		{
			deathTimer = 0f;
		}
	}

	public void OnEMPHit()
	{
		Explode();
	}

	private void FixedUpdate()
	{
		if (phys.OnFire && UnityEngine.Random.value > 0.9f && !AudioSource.isPlaying)
		{
			PlaySound(OnFire);
		}
		if (phys.BurnProgress > 0.9f || phys.Temperature > 2500f || phys.Charge > 500f)
		{
			Explode();
		}
		if (disabled)
		{
			State = SentryTurretAIState.Idle;
			return;
		}
		switch (State)
		{
		case SentryTurretAIState.Idle:
			if (target != null)
			{
				Activate();
			}
			break;
		case SentryTurretAIState.Firing:
			if (target == null)
			{
				timeStartedSearching = Time.time;
				Searching();
			}
			else
			{
				Vector3 v = directTarget.position - base.transform.position;
				Utils.LaserHit laserHit = Utils.MaterialAwareRaycast(turretGun.BarrelPosition, v, 100f, BlockingLayers);
				bool num = (bool)laserHit.physicalBehaviour && laserHit.physicalBehaviour.transform.root != target.transform.root;
				bool flag = !limbTarget.IsConsideredAlive || !target.IsAlive();
				if (num | flag)
				{
					if (flag)
					{
						State = SentryTurretAIState.Idle;
						PlaySound(Retiring);
						AudioSource.PlayOneShot(PistonRetract);
					}
					target = null;
				}
			}
			if (soundTimer > 0.135f)
			{
				AudioSource.PlayOneShot(Alarm, 0.2f);
				soundTimer = 0f;
			}
			break;
		case SentryTurretAIState.Searching:
			if (soundTimer > 1.1f)
			{
				AudioSource.PlayOneShot(Ping);
				soundTimer = 0f;
			}
			if (Time.time - timeStartedSearching > 4f)
			{
				State = SentryTurretAIState.Idle;
				PlaySound(Retiring);
				AudioSource.PlayOneShot(PistonRetract);
			}
			if (target != null)
			{
				Activate();
			}
			break;
		case SentryTurretAIState.Panicking:
			if (soundTimer > 0.135f)
			{
				AudioSource.PlayOneShot(Alarm, 0.2f);
				soundTimer = 0f;
			}
			break;
		}
		if ((rb.velocity - oldVelocity).sqrMagnitude > 110f && oldVelocity.sqrMagnitude < rb.velocity.sqrMagnitude)
		{
			Panic();
		}
		if (Mathf.Abs(Vector2.Dot(base.transform.up, Vector2.up)) < 0.8f)
		{
			State = SentryTurretAIState.Panicking;
			if (deathTimer > 1f)
			{
				PlaySound(Tipped);
				Disable();
			}
		}
		else if (deathTimer > 1f)
		{
			State = SentryTurretAIState.Idle;
		}
		oldVelocity = rb.velocity;
	}

	private void Explode()
	{
		CameraShakeBehaviour.main.Shake(10f, base.transform.position);
		Object.Instantiate(Resources.Load<GameObject>("Prefabs/Explosion"), base.transform.position, Quaternion.identity);
		GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load<GameObject>("Prefabs/SentryTurretDebris"), base.transform.position, base.transform.rotation);
		gameObject.transform.localScale = base.transform.localScale;
		DestroyableBehaviour.ApplyAncestorProperties(rb, phys, default(Vector2), gameObject);
		DestroyableBehaviour.ReplaceUndoEntryWith(base.transform, gameObject);
		UnityEngine.Object.Destroy(base.gameObject);
	}

	private void Disable()
	{
		disabled = true;
		turretGun.Disable();
	}

	public void Shot(Shot shot)
	{
		if (!disabled)
		{
			PlaySound(ShotAt);
		}
	}

	private void Panic()
	{
		PlaySound(Flying);
	}

	private void Searching()
	{
		State = SentryTurretAIState.Searching;
		if ((double)UnityEngine.Random.value > 0.2)
		{
			PlaySound(TargetLost);
		}
	}

	private void Activate()
	{
		State = SentryTurretAIState.Firing;
		AudioSource.PlayOneShot(Active);
		AudioSource.PlayOneShot(PistonDeploy);
		if ((double)UnityEngine.Random.value > 0.2)
		{
			PlaySound(TargetAcquired);
		}
	}

	private void PlaySound(AudioClip[] set)
	{
		AudioSource.clip = set.PickRandom();
		AudioSource.Play();
	}

	private void OnTriggerStay2D(Collider2D collider)
	{
		LimbBehaviour component;
		if (disabled || !collider.TryGetComponent(out component) || !component.IsConsideredAlive)
		{
			return;
		}
		AliveBehaviour component2 = collider.transform.root.GetComponent<AliveBehaviour>();
		if (!component2 || !component2.IsAlive())
		{
			return;
		}
		Vector3 v = collider.transform.position - base.transform.position;
		Utils.LaserHit laserHit = Utils.MaterialAwareRaycast(turretGun.BarrelPosition, v, 100f, BlockingLayers);
		if (!laserHit.physicalBehaviour || laserHit.physicalBehaviour.isDisintegrated || laserHit.physicalBehaviour.transform != collider.transform)
		{
			return;
		}
		if ((bool)target)
		{
			if (component.RoughClassification == LimbBehaviour.BodyPart.Torso)
			{
				SetTarget(component);
			}
			else if (!(component2 == target) && Vector2.Distance(collider.transform.position, base.transform.position) < Vector2.Distance(target.transform.position, base.transform.position))
			{
				SetTarget(component);
			}
		}
		else
		{
			SetTarget(component);
		}
	}

	private void SetTarget(LimbBehaviour limb)
	{
		target = limb.Person;
		limbTarget = limb;
		directTarget = limb.transform;
	}

	private void OnTriggerExit2D(Collider2D collider)
	{
		if (!disabled && (bool)target && collider.transform == directTarget)
		{
			target = null;
		}
	}
}
