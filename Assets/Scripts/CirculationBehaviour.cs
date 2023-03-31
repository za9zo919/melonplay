using NaughtyAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(LimbBehaviour))]
public class CirculationBehaviour : BloodContainer, Messages.IShot, Messages.IExitShot, Messages.IStabbed, Messages.IOnImpactCreated, Messages.IUnstabbed
{
	[SkipSerialisation]
	[HideInInspector]
	public LimbBehaviour Limb;

	[SkipSerialisation]
	[HideInInspector]
	public CirculationBehaviour Source;

	[SkipSerialisation]
	public CirculationBehaviour[] PushesTo;

	[SkipSerialisation]
	[HideInInspector]
	public List<GameObject> BleedingParticles = new List<GameObject>();

	[Header("Settings")]
	public bool IsPump;

	public float BloodLossRateMultiplier = 1f;

	[Header("Status")]
	[ReadOnly]
	public float BleedingRate;

	[ReadOnly]
	public bool IsDisconnected;

	[ReadOnly]
	public bool WasInitiallyPumping;

	[ReadOnly]
	public float BloodFlow;

	private const byte MaximumBleedingPoints = 8;

	public float BloodRegenerationPerSecond = 0.0025f;

	[HideInInspector]
	public byte BleedingPointCount;

	[HideInInspector]
	public ushort StabWoundCount;

	[HideInInspector]
	public ushort GunshotWoundCount;

	public float InternalBleedingIntensity;

	public const float ActualBloodLimit = 1f;

	public bool ImmuneToDamage;

	private bool diffuseOscillator;

	private bool canUnlockGlowingHumanAchievement = true;

	[ReadOnly]
	public bool NewlySpawned = true;

	public float ArtificialHeartbeat;

	[SkipSerialisation]
	public bool HasCirculation
	{
		get
		{
			if (BloodFlow > 0.01f)
			{
				return base.TotalLiquidAmount > 0.01f;
			}
			return false;
		}
	}

	[SkipSerialisation]
	public bool HasBloodFlow => BloodFlow > 0.05f;

	[Obsolete]
	public bool IsConnectedToMainBody
	{
		get
		{
			if (!Limb || !Limb.NodeBehaviour)
			{
				return HasBloodFlow;
			}
			return Limb.NodeBehaviour.IsConnectedToRoot;
		}
	}

	public override Vector2 Limits => new Vector2(0f, 1f);

	public override bool AllowsTransfer => true;

	public float GetAmountOfBlood()
	{
		return GetAmount(Limb.GetOriginalBloodType());
	}

	public float GetHeartRate()
	{
		if (!IsPump || !Limb.IsConsideredAlive)
		{
			return ArtificialHeartbeat;
		}
		bool isConnectedToRoot = Limb.NodeBehaviour.IsConnectedToRoot;
		float num = Mathf.Clamp01(BloodFlow);
		float t = Mathf.Clamp01(base.TotalLiquidAmount);
		float t2 = isConnectedToRoot ? Mathf.Clamp01(Limb.Person.OxygenLevel) : 0f;
		float num2 = isConnectedToRoot ? Mathf.Clamp01(Limb.Person.Consciousness) : 0f;
		float num3 = isConnectedToRoot ? Mathf.Clamp01(Limb.Person.PainLevel) : 0f;
		float num4 = isConnectedToRoot ? Mathf.Clamp01(Limb.Person.AdrenalineLevel) : 0f;
		float num5 = isConnectedToRoot ? Mathf.Clamp01(Limb.Person.ShockLevel) : 0f;
		float num6 = Mathf.Lerp(0f, 95f, num4 + num5 + num3);
		return Mathf.Max(ArtificialHeartbeat, (Mathf.Lerp(0f, 70f - (1f - num2) * 22f, t) + num6) * Mathf.Lerp(0.5f, 1f, t2) * num);
	}

	private void Awake()
	{
		NewlySpawned = true;
		WasInitiallyPumping = IsPump;
		BloodFlow = 1f;
		CirculationBehaviour[] pushesTo = PushesTo;
		for (int i = 0; i < pushesTo.Length; i++)
		{
			pushesTo[i].Source = this;
		}
	}

	private void Start()
	{
		if (Limb.SpeciesIdentity != "Human" || SerialisableDistributions.Any(_003CStart_003Eg__glowingCheck_007C33_0))
		{
			canUnlockGlowingHumanAchievement = false;
		}
		Liquid liquid = Liquid.GetLiquid(Limb.BloodLiquidType);
		if (NewlySpawned)
		{
			AddLiquid(liquid, 1f);
			NewlySpawned = false;
		}
		if (!Limb.PhysicalBehaviour.isDisintegrated)
		{
			CreateDismembermentBloodParticle();
		}
	}

	private void FixedUpdate()
	{
		float fixedDeltaTime = Time.fixedDeltaTime;
		if (Limb.PhysicalBehaviour.Temperature <= Limb.FreezingTemperature)
		{
			IsPump = false;
		}
		PumpBehaviour(fixedDeltaTime);
		HandleBleeding(fixedDeltaTime);
		HandlePenetrationBleeding();
		HandleDamageEdgeCases();
		BloodFlow = Mathf.Clamp01(BloodFlow);
		InternalBleedingIntensity = Mathf.Max(0f, InternalBleedingIntensity - fixedDeltaTime * 0.1f);
		DiffuseStep();
		FlowStep();
		if (BloodRegenerationPerSecond >= float.Epsilon && Limb.Health > 0.1f && GetAmountOfBlood() < 0.8f)
		{
			AddLiquid(Liquid.GetLiquid(Limb.BloodLiquidType), BloodRegenerationPerSecond * fixedDeltaTime);
		}
		if (canUnlockGlowingHumanAchievement && GetAmount(Liquid.GetLiquid("TRITIUM")) > float.Epsilon)
		{
			StatManager.UnlockAchievement("GLOWING_HUMAN");
		}
	}

	private void PumpBehaviour(float deltaTime)
	{
		if (IsPump && Limb.PhysicalBehaviour.Charge > 0.5f && (double)UnityEngine.Random.value > 0.995 - (double)(Limb.PhysicalBehaviour.Charge / 500f))
		{
			IsPump = false;
		}
		if (IsPump && Limb.NodeBehaviour.IsConnectedToRoot && !Limb.Person.Braindead)
		{
			BloodFlow = base.TotalLiquidAmount;
		}
		else
		{
			BloodFlow -= deltaTime / 20f;
			if (WasInitiallyPumping && (double)UnityEngine.Random.value > 0.999 && Limb.PhysicalBehaviour.Charge > 0.001f && BloodFlow < 0.1f)
			{
				IsPump = true;
			}
		}
		BloodFlow = Mathf.Max(0f, Mathf.Min(base.TotalLiquidAmount, BloodFlow));
	}

	private void HandleDamageEdgeCases()
	{
		float num = Mathf.Max(Limb.PhysicalBehaviour.BurnProgress, Limb.SkinMaterialHandler.AcidProgress);
		if (num > 0.8f && Limb.PhysicalBehaviour.Temperature > 0f)
		{
			Drain(Mathf.Lerp(0.02f, 0.1f, Utils.MapRange(0.8f, 1f, 0f, 1f, num)));
		}
	}

	private void HandlePenetrationBleeding()
	{
		foreach (PhysicalBehaviour.Penetration victimPenetration in Limb.PhysicalBehaviour.victimPenetrations)
		{
			if (victimPenetration.Active && victimPenetration.Stabber.StabCausesWound)
			{
				BleedingRate = Mathf.Max(BleedingRate, victimPenetration.GetCurrentDepth() * 4f);
			}
		}
	}

	private void HandleBleeding(float deltaTime)
	{
		if (BleedingRate > 0.05f && Limb.PhysicalBehaviour.Temperature > 0f)
		{
			if (BleedingRate < 1f)
			{
				BleedingRate -= Time.deltaTime * 0.05f;
			}
			Drain(deltaTime / Mathf.Lerp(60f, 20f, BloodFlow) * BleedingRate * 0.15f);
		}
	}

	public void CreateDismembermentBloodParticle()
	{
		if (!Limb.IsAndroid && Limb.HasJoint)
		{
			Transform transform = Limb.Joint.connectedBody.transform;
			Vector3 position = transform.TransformPoint(Limb.Joint.connectedAnchor);
			Vector3 up = Limb.transform.position - transform.position;
			GameObject gameObject = UnityEngine.Object.Instantiate(Limb.Person.BleedingParticlePrefab, position, Quaternion.identity, transform);
			gameObject.AddComponent<Optout>();
			gameObject.transform.up = up;
			BleedingParticleBehaviour component = gameObject.GetComponent<BleedingParticleBehaviour>();
			component.CirculationBehaviour = transform.GetComponent<CirculationBehaviour>();
			component.PushingTo = this;
			component.ShouldBecomeSmokeInWater = true;
		}
	}

	private void FlowStep()
	{
		CirculationBehaviour[] pushesTo = PushesTo;
		foreach (CirculationBehaviour circulationBehaviour in pushesTo)
		{
			if (!circulationBehaviour.Limb.PhysicalBehaviour.isDisintegrated && Limb.NodeBehaviour.IsConnectedTo(circulationBehaviour.Limb.NodeBehaviour) && circulationBehaviour.BloodFlow < BloodFlow && !circulationBehaviour.IsDisconnected)
			{
				circulationBehaviour.BloodFlow = Mathf.Lerp(circulationBehaviour.BloodFlow, BloodFlow, 0.5f);
			}
		}
	}

	private void DiffuseStep()
	{
		float rate = Time.fixedDeltaTime * 1.5f;
		if (diffuseOscillator)
		{
			for (int i = 0; i < Limb.ConnectedLimbs.Count; i++)
			{
				DiffuseToLimb(Limb.ConnectedLimbs[i], rate);
			}
		}
		else
		{
			for (int num = Limb.ConnectedLimbs.Count - 1; num >= 0; num--)
			{
				DiffuseToLimb(Limb.ConnectedLimbs[num], rate);
			}
		}
		diffuseOscillator = !diffuseOscillator;
	}

	private void DiffuseToLimb(LimbBehaviour other, float rate)
	{
		if (!other.PhysicalBehaviour.isDisintegrated && !(other == Limb) && Limb.NodeBehaviour.IsConnectedTo(other.NodeBehaviour))
		{
			CirculationBehaviour circulationBehaviour = other.CirculationBehaviour;
			if (!(circulationBehaviour.TotalLiquidAmount > base.TotalLiquidAmount))
			{
				TransferTo(rate, circulationBehaviour);
			}
		}
	}

	public void Shot(Shot shot)
	{
		if (ImmuneToDamage)
		{
			return;
		}
		shot.damage *= Limb.ShotDamageMultiplier;
		if (!Limb.IsAndroid || !(shot.damage < 50f))
		{
			if (!Limb.IsZombie && UnityEngine.Random.value < Limb.PhysicalBehaviour.Properties.Softness + 0.001f)
			{
				BleedingRate += Mathf.Max(0.5f, shot.damage / 3.5f);
				CreateBleedingParticle(shot.point, shot.normal);
			}
			if (!Limb.IsAndroid && !Limb.IsZombie && UnityEngine.Random.value > 0.2f && Limb.IsWorldPointInVitalPart(shot.point))
			{
				IsPump = false;
			}
			GunshotWoundCount++;
		}
	}

	public void ExitShot(Shot shot)
	{
		if (ImmuneToDamage)
		{
			return;
		}
		shot.damage = Limb.ShotDamageMultiplier;
		if (!Limb.IsZombie && !Limb.IsAndroid)
		{
			BleedingRate += Mathf.Max(0.5f, shot.damage / 10f);
			CreateBleedingParticle(shot.point, shot.normal);
			if (!Limb.IsAndroid && UnityEngine.Random.value > 0.2f && Limb.IsWorldPointInVitalPart(shot.point))
			{
				IsPump = false;
			}
		}
	}

	public void HealBleeding()
	{
		foreach (GameObject bleedingParticle in BleedingParticles)
		{
			UnityEngine.Object.Destroy(bleedingParticle);
		}
		BleedingRate = 0f;
		BleedingParticles.Clear();
		BleedingPointCount = 0;
		InternalBleedingIntensity = 0f;
	}

	public void CreateBleedingParticle(Vector2 worldPosition, Vector2 direction)
	{
		if (!Limb.IsAndroid && !Limb.IsZombie && BleedingPointCount < 8)
		{
			worldPosition = Limb.PhysicalBehaviour.spriteRenderer.bounds.ClosestPoint(worldPosition);
			GameObject gameObject = UnityEngine.Object.Instantiate(Limb.Person.BleedingParticlePrefab, worldPosition - direction * 0.1f, Quaternion.identity, base.transform);
			gameObject.transform.up = direction;
			BleedingParticleBehaviour component = gameObject.GetComponent<BleedingParticleBehaviour>();
			component.ShouldBecomeSmokeInWater = (BleedingPointCount == 0);
			component.CirculationBehaviour = this;
			BleedingParticles.Add(gameObject);
			BleedingPointCount++;
		}
	}

	public void Stabbed(Stabbing stabbing)
	{
		if (!ImmuneToDamage && !Limb.IsZombie && stabbing.stabber.StabCausesWound)
		{
			StabWoundCount++;
			InternalBleedingIntensity += 0.1f;
			if (IsPump && UnityEngine.Random.value < 0.6f && Limb.IsWorldPointInVitalPart(stabbing.point))
			{
				IsPump = false;
			}
		}
	}

	public void Unstabbed(Stabbing stabbing)
	{
		if (!ImmuneToDamage && stabbing.stabber.StabCausesWound)
		{
			CreateBleedingParticle(stabbing.point, stabbing.normal);
			BleedingRate += 1f;
		}
	}

	public void Cut(Vector2 point, Vector2 direction)
	{
		if (!ImmuneToDamage)
		{
			BleedingRate += 0.25f;
			CreateBleedingParticle(point, direction);
		}
	}

	public void ActOnJointBreak2D(Joint2D joint)
	{
		if (!(joint != Limb.Joint))
		{
			BleedingRate += 10f;
			if ((bool)Source && Limb.NodeBehaviour.IsConnectedTo(Source.Limb.NodeBehaviour))
			{
				Source.BleedingRate += 10f;
			}
			IsDisconnected = true;
		}
	}

	public void Disintegrate()
	{
		Limb.BreakingThreshold = 0f;
		BleedingRate += 20f;
		CirculationBehaviour[] pushesTo = PushesTo;
		foreach (CirculationBehaviour circulationBehaviour in pushesTo)
		{
			if (Limb.NodeBehaviour.IsConnectedTo(circulationBehaviour.Limb.NodeBehaviour) && !circulationBehaviour.Limb.PhysicalBehaviour.isDisintegrated)
			{
				circulationBehaviour.BleedingRate += 20f;
			}
		}
		if ((bool)Source && Limb.NodeBehaviour.IsConnectedTo(Source.Limb.NodeBehaviour))
		{
			Source.BleedingRate += 20f;
		}
		IsDisconnected = true;
	}

	protected override void OnLiquidEnter(Liquid type)
	{
		base.OnLiquidEnter(type);
		type.OnEnterLimb(Limb);
	}

	public void OnImpactCreated(GameObject gm)
	{
		if (gm.TryGetComponent(out BloodImpactBehaviour component))
		{
			if (ScaledLiquidAmount > 0.05f)
			{
				component.SetColor(GetComputedColor(Limb.GetOriginalBloodType().Color));
			}
			else
			{
				component.SetColor(Limb.GetOriginalBloodType().Color);
			}
		}
	}

	[CompilerGenerated]
	private static bool _003CStart_003Eg__glowingCheck_007C33_0(SerialisableDistribution s)
	{
		if (s.LiquidID == "TRITIUM")
		{
			return s.Amount > float.Epsilon;
		}
		return false;
	}
}
