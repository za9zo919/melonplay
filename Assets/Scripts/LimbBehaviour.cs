using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SkinMaterialHandler), typeof(CirculationBehaviour))]
public class LimbBehaviour : MonoBehaviour, Messages.IShot, Messages.IExitShot, Messages.ISlice, Messages.IDamage, Messages.IOnEMPHit, Messages.IWaterImpact, IManagedBehaviour
{
	public enum BodyPart
	{
		Head,
		Torso,
		Legs,
		Arms
	}

	[SkipSerialisation]
	public ConnectedNodeBehaviour NodeBehaviour;

	[SkipSerialisation]
	public BodyPart RoughClassification;

	[SkipSerialisation]
	[HideInInspector]
	public SkinMaterialHandler SkinMaterialHandler;

	[SkipSerialisation]
	[HideInInspector]
	public PhysicalBehaviour PhysicalBehaviour;

	[SkipSerialisation]
	[HideInInspector]
	public CirculationBehaviour CirculationBehaviour;

	[SkipSerialisation]
	[HideInInspector]
	public PersonBehaviour Person;

	[SkipSerialisation]
	[HideInInspector]
	public HingeJoint2D Joint;

	[SkipSerialisation]
	[HideInInspector]
	public Collider2D Collider;

	[SkipSerialisation]
	public Bounds[] VitalParts;

	[SkipSerialisation]
	public ParticleSystem KillShotParticles;

	[SkipSerialisation]
	public float GForcePassoutThreshold = 10f;

	[SkipSerialisation]
	public float GForceDamageThreshold = 10f;

	[HideInInspector]
	public bool KillShotParticlesEmitted;

	[SkipSerialisation]
	[HideInInspector]
	public GripBehaviour GripBehaviour;

	private GameObject myStatus;

	[Header("Settings")]
	[SkipSerialisation]
	public List<LimbBehaviour> ConnectedLimbs;

	[Space]
	public float Vitality;

	[HideInInspector]
	public float InitialHealth;

	public bool HasBrain;

	public float FreezingTemperature = -25f;

	public float DiscomfortingHeatTemperature = 40f;

	public float RegenerationSpeed;

	public float ImpactPainMultiplier;

	public float BreakingThreshold;

	public float BaseStrength = 5f;

	public float FakeUprightForce;

	public float BodyTemperature = 37f;

	public float ShotDamageMultiplier = 1f;

	public bool DoStumble;

	public bool IsLethalToBreak;

	public bool DoBalanceJerk;

	[Obsolete]
	public float ExplodeLiquidAmount = 5.357143f;

	[SkipSerialisation]
	public DecalDescriptor BloodDecal;

	private Color color;

	public float BloodMuscleStrengthRatio = 1f;

	[ShowIf("DoBalanceJerk")]
	public float BalanceMuscleMovement = 1f;

	[Header("Status")]
	public float Health;

	[ReadOnly]
	public float Numbness;

	public bool IsAndroid;

	[ReadOnly]
	public bool IsZombie;

	[ReadOnly]
	public bool HasJoint;

	[ReadOnly]
	public bool Broken;

	[ReadOnly]
	public bool Frozen;

	[ReadOnly]
	public bool IsDismembered;

	[SkipSerialisation]
	public string SpeciesIdentity = "Human";

	[SkipSerialisation]
	public string BloodLiquidType = "BLOOD";

	[SkipSerialisation]
	public LimbBehaviour NearestLimbToBrain;

	[SkipSerialisation]
	public int DistanceToBrain;

	[SkipSerialisation]
	public float InternalExternalTemperatureTransferRate = 0.01f;

	[HideInInspector]
	public float InternalTemperature;

	[HideInInspector]
	public bool IsActiveInCurrentPose;

	private Vector2 previousVelocity;

	[SkipSerialisation]
	public float FrictionBurnWoundMinSpeedSqrd = 62f;

	private float stumbleTime;

	private static readonly ContactPoint2D[] contactBuffer = new ContactPoint2D[8];

	[HideInInspector]
	[SkipSerialisation]
	public float randomOffset;

	[HideInInspector]
	public ushort BruiseCount;

	public const float DrownTimeInSeconds = 40f;

	[SkipSerialisation]
	public GameObject LimbStatus;

	public bool ImmuneToDamage;

	private float previousHealth;

	public bool HasLungs;

	[HideInInspector]
	public bool LungsPunctured;

	private float shotHeat;

	private Vector2 originalJointLimits;

	private GForceMeasureBehaviour gforce;

	[SkipSerialisation]
	public float RegenerateBurnProgressSpeed = 1f;

	[SkipSerialisation]
	public bool IsOnFloor
	{
		get;
		private set;
	}

	[SkipSerialisation]
	public bool IsParalysed
	{
		get
		{
			if (!IsAndroid && !IsZombie && (bool)NearestLimbToBrain)
			{
				if (NearestLimbToBrain.NodeBehaviour.IsConnectedToRoot)
				{
					if (!NearestLimbToBrain.Broken || NearestLimbToBrain.RoughClassification != BodyPart.Torso)
					{
						return NearestLimbToBrain.IsParalysed;
					}
					return true;
				}
				return false;
			}
			return false;
		}
	}

	[SkipSerialisation]
	public float JointStress
	{
		get;
		private set;
	}

	[SkipSerialisation]
	public Vector2 OriginalJointLimits
	{
		get
		{
			return originalJointLimits;
		}
		set
		{
			originalJointLimits = value;
		}
	}

	[SkipSerialisation]
	public bool IsCapable
	{
		get
		{
			if (Frozen || PhysicalBehaviour.Temperature <= FreezingTemperature)
			{
				return false;
			}
			if (NodeBehaviour.IsConnectedToRoot && Health > 1f && Person.Consciousness > 0.8f && Person.ShockLevel < 0.5f && Person.PainLevel < 0.5f && Numbness < 0.9f && CirculationBehaviour.InternalBleedingIntensity < 0.5f && CirculationBehaviour.HasCirculation && !Broken)
			{
				return CirculationBehaviour.BloodFlow > 0.25f;
			}
			return false;
		}
	}

	[SkipSerialisation]
	public bool IsConsideredAlive
	{
		get
		{
			if (NodeBehaviour.IsConnectedToRoot && CirculationBehaviour.BloodFlow > 0.25f)
			{
				return Health > 0.01f;
			}
			return false;
		}
	}

	[SkipSerialisation]
	public float MotorStrength
	{
		get
		{
			if (Person.Consciousness < Mathf.Max(0.3f, 0.8f - Mathf.Clamp01(Person.AdrenalineLevel)))
			{
				return 0f;
			}
			Health = Mathf.Max(0f, Health);
			Numbness = Mathf.Clamp01(Numbness + Mathf.Min(CirculationBehaviour.InternalBleedingIntensity * 0.25f, 0.1f));
			if ((Broken || IsParalysed) && PhysicalBehaviour.Charge < 0.05f)
			{
				return 0f;
			}
			float a = (Health / InitialHealth + Mathf.Clamp01(Person.AdrenalineLevel)) * Mathf.Pow(CirculationBehaviour.GetAmountOfBlood(), 3f * BloodMuscleStrengthRatio) * Mathf.Pow(CirculationBehaviour.BloodFlow, 3f * BloodMuscleStrengthRatio) * Mathf.Clamp01(Person.Consciousness + Mathf.Clamp01(Person.AdrenalineLevel)) * Mathf.Clamp01(1f - PhysicalBehaviour.BurnProgress) * Mathf.Clamp01(1f - SkinMaterialHandler.AcidProgress) * Mathf.Clamp01(1f - (Numbness - Mathf.Clamp01(Person.AdrenalineLevel)));
			return BaseStrength * 1.5f * Mathf.Clamp01(Mathf.Max(a, PhysicalBehaviour.Charge * 0.5f)) * GetMassStrengthRatio();
		}
	}

	public Color Color
	{
		get
		{
			return color;
		}
		set
		{
			color = value;
			GetComponent<SpriteRenderer>().color = value;
		}
	}

	public Liquid GetOriginalBloodType()
	{
		return Liquid.GetLiquid(BloodLiquidType);
	}

	private float GetMassStrengthRatio()
	{
		return PhysicalBehaviour.rigidbody.mass / PhysicalBehaviour.TrueInitialMass;
	}

	private void Awake()
	{
		Color = Color.white;
		SkinMaterialHandler = GetComponent<SkinMaterialHandler>();
		PhysicalBehaviour = GetComponent<PhysicalBehaviour>();
		CirculationBehaviour = GetComponent<CirculationBehaviour>();
		NodeBehaviour = GetComponent<ConnectedNodeBehaviour>();
		GripBehaviour = GetComponent<GripBehaviour>();
		myStatus = UnityEngine.Object.Instantiate(LimbStatus, base.transform);
		myStatus.GetComponent<LimbStatusBehaviour>().limb = this;
		SkinMaterialHandler.limb = this;
		CirculationBehaviour.Limb = this;
		Collider = GetComponent<Collider2D>();
		Joint = GetComponent<HingeJoint2D>();
		InitialHealth = Health;
		HasJoint = Joint;
		randomOffset = UnityEngine.Random.Range(-10000, 10000);
		if (HasJoint)
		{
			SetupJoint();
		}
		InternalTemperature = BodyTemperature;
		PhysicalBehaviour.Temperature = BodyTemperature;
	}

	private void Start()
	{
		gforce = base.gameObject.GetOrAddComponent<GForceMeasureBehaviour>();
		LimbBehaviourManager.Limbs.Add(this);
		PhysicalBehaviour.OnDisintegration += PhysicalBehaviour_OnDisintegration;
		IsOnFloor = false;
		CreateContextMenuOptions();
		if (Broken)
		{
			BreakBoneInternal();
		}
		SynchroniseDismemberment();
		if (HasJoint)
		{
			originalJointLimits.x = Joint.limits.min;
			originalJointLimits.y = Joint.limits.max;
		}
		for (int i = 0; i < ConnectedLimbs.Count; i++)
		{
			LimbBehaviour limbBehaviour = ConnectedLimbs[i];
			if ((!NearestLimbToBrain || limbBehaviour.DistanceToBrain < NearestLimbToBrain.DistanceToBrain) && limbBehaviour.DistanceToBrain < DistanceToBrain)
			{
				NearestLimbToBrain = limbBehaviour;
			}
		}
	}

	private void PhysicalBehaviour_OnDisintegration(object sender, EventArgs e)
	{
		CirculationBehaviour.Disintegrate();
		for (int i = 0; i < ConnectedLimbs.Count; i++)
		{
			LimbBehaviour limbBehaviour = ConnectedLimbs[i];
			if (NodeBehaviour.IsConnectedTo(limbBehaviour.NodeBehaviour) && limbBehaviour.HasJoint && limbBehaviour.Joint.connectedBody == PhysicalBehaviour.rigidbody)
			{
				limbBehaviour.Joint.breakForce = 0f;
			}
		}
		if (TryGetComponent(out GoreStringBehaviour component))
		{
			component.DestroyJoint();
		}
		NodeBehaviour.DisconnectFromEverything();
		if (HasJoint)
		{
			Joint.breakForce = 0f;
			Joint.breakTorque = 0f;
		}
	}

	private void CreateContextMenuOptions()
	{
		PhysicalBehaviour.ContextMenuOptions.Buttons.Add(new ContextMenuButton("inspectLimb", "Inspect", "Inspect", delegate
		{
			LimbStatusViewBehaviour.Main.Limbs = new List<LimbBehaviour>();
			foreach (PhysicalBehaviour selectedObject in SelectionController.Main.SelectedObjects)
			{
				if (selectedObject.TryGetComponent(out LimbBehaviour component))
				{
					LimbStatusViewBehaviour.Main.Limbs.Add(component);
				}
			}
			LimbStatusViewBehaviour.Main.gameObject.SetActive(value: true);
		}));
		PhysicalBehaviour.ContextMenuOptions.Buttons.Add(new ContextMenuButton("breakBones", () => (!Broken) ? "Break bone" : "Mend bone", "Mend or break bone", delegate
		{
			if (Broken)
			{
				HealBone();
			}
			else
			{
				BreakBone();
			}
		}));
		List<ContextMenuButton> buttons = PhysicalBehaviour.ContextMenuOptions.Buttons;
		ContextMenuButton item = new ContextMenuButton(() => Person.OverridePoseIndex != -1, "clearOverride", "Clear animation override", "Resets the animation to be controlled by the algorithm again", delegate
		{
			Person.OverridePoseIndex = -1;
		})
		{
			LabelWhenMultipleAreSelected = "Reset all animations"
		};
		buttons.Add(item);
		List<ContextMenuButton> buttons2 = PhysicalBehaviour.ContextMenuOptions.Buttons;
		item = new ContextMenuButton(() => Person.OverridePoseIndex != 3, "startStumbling", "Stumble", "Forces the stumbling animation override", delegate
		{
			Person.OverridePoseIndex = 3;
		})
		{
			LabelWhenMultipleAreSelected = "Stumble"
		};
		buttons2.Add(item);
		List<ContextMenuButton> buttons3 = PhysicalBehaviour.ContextMenuOptions.Buttons;
		item = new ContextMenuButton(() => Person.OverridePoseIndex != 6, "startWalking", "Walk", "Forces the walking animation override", delegate
		{
			Person.OverridePoseIndex = 6;
		})
		{
			LabelWhenMultipleAreSelected = "Walk"
		};
		buttons3.Add(item);
		List<ContextMenuButton> buttons4 = PhysicalBehaviour.ContextMenuOptions.Buttons;
		item = new ContextMenuButton(() => Person.OverridePoseIndex != 1, "startProtect", "Cower", "Forces the protection animation override", delegate
		{
			Person.OverridePoseIndex = 1;
		})
		{
			LabelWhenMultipleAreSelected = "Cower"
		};
		buttons4.Add(item);
		List<ContextMenuButton> buttons5 = PhysicalBehaviour.ContextMenuOptions.Buttons;
		item = new ContextMenuButton(() => Person.OverridePoseIndex != 7, "startSit", "Sit", "Forces the sitting animation override", delegate
		{
			Person.OverridePoseIndex = 7;
		})
		{
			LabelWhenMultipleAreSelected = "Sit"
		};
		buttons5.Add(item);
		List<ContextMenuButton> buttons6 = PhysicalBehaviour.ContextMenuOptions.Buttons;
		item = new ContextMenuButton(() => Person.OverridePoseIndex != 8, "startPetrified", "Flat pose", "Forces the resting animation override", delegate
		{
			Person.OverridePoseIndex = 8;
		})
		{
			LabelWhenMultipleAreSelected = "Flat pose"
		};
		buttons6.Add(item);
	}

	public void ManagedFixedUpdate()
	{
		shotHeat = 0f;
		for (int i = 0; i < ConnectedLimbs.Count; i++)
		{
			LimbBehaviour limbBehaviour = ConnectedLimbs[i];
			if ((bool)limbBehaviour && !limbBehaviour.PhysicalBehaviour.isDisintegrated && NodeBehaviour.IsConnectedTo(limbBehaviour.NodeBehaviour))
			{
				Utils.TransferEnergyFixedRate(limbBehaviour.PhysicalBehaviour, PhysicalBehaviour);
				Utils.AverageTemperature(limbBehaviour.PhysicalBehaviour, PhysicalBehaviour);
			}
		}
		float temperature = PhysicalBehaviour.Temperature;
		float internalTemperature = InternalTemperature;
		PhysicalBehaviour.Temperature = Mathf.Lerp(temperature, internalTemperature, InternalExternalTemperatureTransferRate);
		InternalTemperature = Mathf.Lerp(internalTemperature, temperature, InternalExternalTemperatureTransferRate);
		if (HasBrain && Health < InitialHealth / 2f)
		{
			LimbBehaviour[] limbs = Person.Limbs;
			foreach (LimbBehaviour limbBehaviour2 in limbs)
			{
				if (limbBehaviour2.NodeBehaviour.IsConnectedToRoot)
				{
					limbBehaviour2.InfluenceMotorSpeed(0f, 0.9f);
				}
			}
		}
		if (!IsZombie && !IsAndroid && CirculationBehaviour.InternalBleedingIntensity > 0.2f)
		{
			float internalBleedingIntensity = CirculationBehaviour.InternalBleedingIntensity;
			switch (RoughClassification)
			{
			case BodyPart.Head:
				Damage(((UnityEngine.Random.value > 5f / internalBleedingIntensity) ? 20f : 0.0004f) * internalBleedingIntensity);
				Person.OxygenLevel -= 0.0001f * internalBleedingIntensity;
				Person.Consciousness -= 0.0001f * internalBleedingIntensity;
				break;
			case BodyPart.Torso:
				Damage(0.0015f * internalBleedingIntensity);
				break;
			case BodyPart.Legs:
			case BodyPart.Arms:
				Numbness += 0.2f * internalBleedingIntensity;
				Damage(0.001f * internalBleedingIntensity);
				break;
			}
			if (NodeBehaviour.IsConnectedToRoot)
			{
				if (UnityEngine.Random.value > 0.9999f)
				{
					Person.Consciousness -= 0.001f * internalBleedingIntensity;
				}
				if ((double)UnityEngine.Random.value > 0.99)
				{
					Person.Wince(UnityEngine.Random.value * CirculationBehaviour.InternalBleedingIntensity * 60f);
				}
			}
		}
		CalculateJointStress();
		if (Mathf.Abs(InternalTemperature - BodyTemperature) >= 3f)
		{
			Numbness += 0.005f * UnityEngine.Random.value;
			Damage(0.005f * UnityEngine.Random.value);
		}
		if (InternalTemperature >= DiscomfortingHeatTemperature || InternalTemperature <= BodyTemperature - 20f)
		{
			if (InternalTemperature >= 100f)
			{
				CirculationBehaviour.HealBleeding();
			}
			if (NodeBehaviour.IsConnectedToRoot && !IsParalysed)
			{
				if (InternalTemperature > BodyTemperature)
				{
					Person.AddPain(20f);
				}
				Person.Consciousness *= 0.99995f;
			}
			Damage(0.0015f);
		}
		if (PhysicalBehaviour.Charge > float.Epsilon && !IsZombie)
		{
			Damage(PhysicalBehaviour.Charge * 0.01f);
		}
		if (PhysicalBehaviour.Temperature > PhysicalBehaviour.Properties.BurningTemperatureThreshold)
		{
			Wince(0.1f);
			Damage(0.0015f + (PhysicalBehaviour.Temperature - PhysicalBehaviour.Properties.BurningTemperatureThreshold) / 1000f);
		}
		if (PhysicalBehaviour.Wetness > 0.25f && IsAndroid)
		{
			PhysicalBehaviour.Charge += 0.5f;
		}
		if (IsConsideredAlive)
		{
			float t = (Mathf.Abs(PhysicalBehaviour.Temperature - BodyTemperature) < 40f) ? 0.05f : 0.01f;
			InternalTemperature = Mathf.Lerp(InternalTemperature, BodyTemperature, t);
			if (PhysicalBehaviour.OnFire)
			{
				Health -= Time.deltaTime * 0.5f * (IsZombie ? 0.01f : 1f);
				if (!IsZombie && NodeBehaviour.IsConnectedToRoot && !IsParalysed)
				{
					if (UserPreferenceManager.Current.StopAnimationOnDamage)
					{
						Person.OverridePoseIndex = -1;
					}
					Person.AddPain(PhysicalBehaviour.BurnIntensity * Time.deltaTime);
				}
			}
			if (UserPreferenceManager.Current.AutoHealWounds && RegenerateBurnProgressSpeed > float.Epsilon && PhysicalBehaviour.BurnProgress > 0f)
			{
				PhysicalBehaviour.BurnProgress -= Time.fixedDeltaTime * RegenerateBurnProgressSpeed * 0.001f;
				PhysicalBehaviour.BurnProgress = Mathf.Max(0f, PhysicalBehaviour.BurnProgress);
			}
		}
		if (CirculationBehaviour.BloodFlow > Mathf.Max(0.25f, 0.9f - Mathf.Clamp01(Person.AdrenalineLevel)) && Person.IsTouchingFloor && Person.ActivePose.ShouldStandUpright && IsCapable)
		{
			if (FakeUprightForce > 0.001f)
			{
				FakeStandUpright();
			}
			if (PhysicalBehaviour.rigidbody.bodyType == RigidbodyType2D.Dynamic)
			{
				PhysicalBehaviour.rigidbody.angularVelocity *= Mathf.Lerp(1f, 0.92f, Person.ActivePose.DragInfluence);
				PhysicalBehaviour.rigidbody.velocity *= Mathf.Lerp(1f, 0.94f, Person.ActivePose.DragInfluence);
			}
		}
		if (HasJoint)
		{
			if (Frozen || PhysicalBehaviour.Temperature <= FreezingTemperature)
			{
				SetMotorStrength(10f);
				InfluenceMotorSpeed(0f, 1f);
			}
			else
			{
				if (IsConsideredAlive && PhysicalBehaviour.Temperature <= BodyTemperature - 32f)
				{
					InfluenceMotorSpeed(UnityEngine.Random.Range(-45, 45));
				}
				SetMotorStrengthToMuscleStrength();
				if (!ApplyPoseOverrides() && IsActiveInCurrentPose && IsConsideredAlive)
				{
					MoveIntoPose(Person.ActivePose);
				}
			}
			if (IsConsideredAlive && PhysicalBehaviour.Charge > float.Epsilon)
			{
				InfluenceMotorSpeed(-50f * base.transform.root.localScale.x, PhysicalBehaviour.Charge * 0.5f);
			}
			if (!IsZombie || !IsConsideredAlive)
			{
				InfluenceMotorSpeed(0f, SkinMaterialHandler.RottenProgress);
			}
		}
		if (ImmuneToDamage || PhysicalBehaviour.rigidbody.bodyType != 0 || !(SpeciesIdentity == "Human") || !(GForcePassoutThreshold > float.Epsilon))
		{
			return;
		}
		float sqrMagnitude = gforce.SustainedAcceleration.sqrMagnitude;
		if (sqrMagnitude > GForcePassoutThreshold * GForcePassoutThreshold)
		{
			if (HasBrain)
			{
				Person.Consciousness *= 0.5f;
			}
			if (sqrMagnitude > GForceDamageThreshold * GForceDamageThreshold)
			{
				Damage(sqrMagnitude / 250f);
			}
		}
	}

	private bool ApplyPoseOverrides()
	{
		if (IsCapable && Person.IsTouchingFloor && Person.ActivePose.ShouldStumble)
		{
			float num = Mathf.Abs(Person.BalanceOffset);
			float num2 = Mathf.Clamp(MotorStrength, 0f, num * 2f);
			if (DoBalanceJerk)
			{
				InfluenceMotorSpeed(Mathf.DeltaAngle(Joint.jointAngle, 0f - Mathf.DeltaAngle(base.transform.eulerAngles.z, 0f)) * 1f * BalanceMuscleMovement, 0.5f * num2);
			}
			if (IsActiveInCurrentPose && Person.ShockLevel < 0.5f && DoStumble && num > 0.3f && num < 1f)
			{
				stumbleTime += Mathf.Clamp(Person.BalanceOffset * -0.1f, -1.7f, 1.7f);
				MoveIntoPoseAt(Person.LinkedPoses[PoseState.Stumbling], stumbleTime, Mathf.Pow(num, 1.5f) * 1.3f * num2);
				return true;
			}
		}
		return false;
	}

	public void ManagedUpdate()
	{
		SetJointFragility();
		float deltaTime = Time.deltaTime;
		bool flag = Health > float.Epsilon;
		if (HasBrain)
		{
			if (Person.Braindead)
			{
				Person.Consciousness = 0f;
				Person.ShockLevel = 0f;
				Person.PainLevel = 0f;
				Health = 0f;
			}
			else
			{
				Person.Braindead = !flag;
			}
		}
		if (flag && Health < InitialHealth)
		{
			Health += RegenerationSpeed * deltaTime;
		}
		HandleDrowning();
		Numbness -= deltaTime / 20f;
		if (!NodeBehaviour.IsConnectedToRoot && Health > 0f)
		{
			Health -= deltaTime / 20f * InitialHealth;
		}
		if ((bool)GripBehaviour && GripBehaviour.isHolding && UserPreferenceManager.Current.DropOnDeath && !IsConsideredAlive)
		{
			GripBehaviour.DropObject();
		}
		if (PhysicalBehaviour.isDisintegrated)
		{
			RegenerationSpeed = 0f;
			Health = 0f;
		}
		if (HasLungs && LungsPunctured && NodeBehaviour.IsConnectedToRoot)
		{
			if (!IsZombie)
			{
				Person.AddPain(2f);
			}
			Person.OxygenLevel -= deltaTime * 0.5f;
		}
		if (PhysicalBehaviour.IsBeingStabbed)
		{
			for (int i = 0; i < PhysicalBehaviour.beingStabbedBy.Count; i++)
			{
				PhysicalBehaviour physicalBehaviour = PhysicalBehaviour.beingStabbedBy[i];
				if ((bool)physicalBehaviour && physicalBehaviour.StabCausesWound && physicalBehaviour.GetRelativeStabSpeed(PhysicalBehaviour) > 0.05f)
				{
					physicalBehaviour.SendMessage("Decal", new DecalInstruction(BloodDecal, physicalBehaviour.GetGlobalStabPoint(PhysicalBehaviour), CirculationBehaviour.GetComputedColor(GetOriginalBloodType().Color)), SendMessageOptions.DontRequireReceiver);
				}
			}
		}
		if (Health > float.Epsilon && previousHealth <= float.Epsilon)
		{
			KillShotParticlesEmitted = false;
		}
		previousHealth = Health;
	}

	private void HandleDrowning()
	{
		if (!NodeBehaviour.IsConnectedToRoot || IsAndroid)
		{
			return;
		}
		float deltaTime = Time.deltaTime;
		if (Person.OxygenLevel < 0.05f)
		{
			Damage(deltaTime * 4f);
		}
		if (HasBrain && !(PhysicalBehaviour.Wetness < 0.5f))
		{
			Person.OxygenLevel -= deltaTime / 40f;
			if (Person.OxygenLevel < 0.9f)
			{
				Person.Consciousness -= deltaTime / 40f * 0.5f;
				Person.AddPain(deltaTime * 0.9f);
			}
		}
	}

	private void CalculateJointStress()
	{
		if (HasJoint && !Broken && Joint.useLimits)
		{
			if (Joint.jointAngle - 5f > OriginalJointLimits.y || Joint.jointAngle + 5f < OriginalJointLimits.x)
			{
				JointStress += (IsAndroid ? 0.1f : 0.25f);
			}
			if (JointStress > BreakingThreshold * GetMassStrengthRatio())
			{
				BreakBone();
			}
			JointStress *= 0.982f;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		IsOnFloor = true;
		int contacts = collision.GetContacts(contactBuffer);
		float num = Utils.GetAverageImpulseRemoveOutliers(contactBuffer, contacts) / GetMassStrengthRatio();
		Vector2 point = contactBuffer[0].point;
		PhysicalBehaviour value;
		if (IsAndroid)
		{
			num *= 0.1f;
		}
		else if (Global.main.PhysicalObjectsInWorldByTransform.TryGetValue(collision.transform, out value) && value.SimulateTemperature && value.Temperature >= 70f)
		{
			Damage(value.Temperature / 140f);
			SkinMaterialHandler.AddDamagePoint(DamageType.Burn, point, value.Temperature * 0.01f);
			if (NodeBehaviour.IsConnectedToRoot && !IsParalysed)
			{
				Person.AddPain(1f);
			}
			Wince(150f);
			if (value.Temperature >= 100f)
			{
				CirculationBehaviour.HealBleeding();
			}
		}
		if (HasBrain && num > 0.6f && (double)UnityEngine.Random.value > 0.8)
		{
			CirculationBehaviour.InternalBleedingIntensity += num;
		}
		if (!(num < 2f))
		{
			BruiseCount++;
			ActOnImpact(num, point);
			if (!(num < 1f) && !IsAndroid && !(CirculationBehaviour.GetAmountOfBlood() < 0.2f) && (!(num < 3f) || !(Health > InitialHealth * 0.2f)))
			{
				collision.gameObject.SendMessage("Decal", new DecalInstruction(BloodDecal, point, CirculationBehaviour.GetComputedColor(GetOriginalBloodType().Color)), SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (!IsAndroid)
		{
			int contacts = collision.GetContacts(contactBuffer);
			ContactPoint2D firstValidContact = Utils.GetFirstValidContact(contactBuffer, contacts);
			float massStrengthRatio = GetMassStrengthRatio();
			if (collision.relativeVelocity.sqrMagnitude / massStrengthRatio > FrictionBurnWoundMinSpeedSqrd)
			{
				Damage(1f);
				SkinMaterialHandler.AddDamagePoint(DamageType.Burn, firstValidContact.point, 2f);
			}
			if (UserPreferenceManager.Current.LimbCrushing && !(Utils.GetMinImpulse(contactBuffer, contacts) * UserPreferenceManager.Current.CrushForceMultiplier / massStrengthRatio < Mathf.Max(10f, BreakingThreshold) * Mathf.Lerp((float)Physics2D.positionIterations / 16f, 1f, 0.2f)))
			{
				collision.gameObject.SendMessage("Decal", new DecalInstruction(BloodDecal, base.transform.position, CirculationBehaviour.GetComputedColor(GetOriginalBloodType().Color)), SendMessageOptions.DontRequireReceiver);
				Crush();
			}
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		IsOnFloor = false;
	}

	private void ActOnImpact(float impulse, Vector3 globalPosition)
	{
		if (!ImmuneToDamage)
		{
			float num = BreakingThreshold * GetMassStrengthRatio();
			if (impulse > num && (double)UnityEngine.Random.value > 0.5)
			{
				BreakBone();
			}
			float num2 = Mathf.Max(1f, Vitality);
			if (impulse > num * 0.5f / num2 && UnityEngine.Random.value > 0.8f / num2)
			{
				CirculationBehaviour.InternalBleedingIntensity += Mathf.Clamp(impulse * num2, 0f, 1f);
			}
			Damage(impulse * impulse * 2.8f);
			SkinMaterialHandler.AddDamagePoint(DamageType.Blunt, globalPosition, impulse * 4f);
			float num3 = impulse * (Vitality + 1f) * 0.25f;
			if (HasBrain && num3 > 1f && !IsAndroid && UnityEngine.Random.value > 0.5f)
			{
				Person.Consciousness *= UnityEngine.Random.value * 0.8f;
			}
			if (NodeBehaviour.IsConnectedToRoot && num3 > 0.2f && !IsZombie)
			{
				Person.ShockLevel += num3 * 0.04f;
			}
		}
	}

	private void FakeStandUpright()
	{
		if (PhysicalBehaviour.rigidbody.bodyType != 0 || !NodeBehaviour.IsConnectedToRoot || Vector2.Dot(base.transform.up, Vector2.down) > 0.1f)
		{
			return;
		}
		float num = Mathf.DeltaAngle(base.transform.eulerAngles.z, 0f) * FakeUprightForce * MotorStrength * Mathf.Lerp(GetMassStrengthRatio(), 1f, 0.8f);
		if (!float.IsNaN(num))
		{
			if (IsAndroid)
			{
				num *= 7.2f;
			}
			PhysicalBehaviour.rigidbody.AddTorque(num * 1.05f * Person.ActivePose.UprightForceMultiplier);
		}
	}

	private void SetupJoint()
	{
		Joint.useMotor = true;
		Joint.motor = new JointMotor2D
		{
			maxMotorTorque = MotorStrength,
			motorSpeed = 0f
		};
	}

	private void MoveIntoPose(RagdollPose activePose, float speedModifier = 1f, float rigidityMultiplier = 1f)
	{
		RagdollPose.LimbPose limbPose = activePose.AngleDictionary[this];
		float num = (PhysicalBehaviour.Temperature <= FreezingTemperature + 10f || PhysicalBehaviour.Temperature >= DiscomfortingHeatTemperature) ? 0.5f : 1f;
		if (activePose.State == PoseState.Walking)
		{
			num *= (float)((Person.DesiredWalkingDirection >= 0f) ? 1 : (-1));
		}
		speedModifier /= Mathf.Lerp(GetMassStrengthRatio(), 1f, 0.9f);
		InfluenceMotorSpeed(Mathf.DeltaAngle(Joint.jointAngle, Joint.referenceAngle + limbPose.EvaluateAngle(activePose.AnimationSpeedMultiplier * speedModifier * num) * Person.AngleOffset) * rigidityMultiplier * activePose.Rigidity * (1f + limbPose.PoseRigidityModifier));
	}

	private void MoveIntoPoseAt(RagdollPose activePose, float timeOverride, float rigidityMultiplier = 1f)
	{
		RagdollPose.LimbPose limbPose = activePose.AngleDictionary[this];
		InfluenceMotorSpeed(Mathf.DeltaAngle(Joint.jointAngle, Joint.referenceAngle + limbPose.EvaluateAngleAt(timeOverride) * Person.AngleOffset) * rigidityMultiplier * activePose.Rigidity * (1f + limbPose.PoseRigidityModifier));
	}

	public void BreakBone()
	{
		if (!Broken)
		{
			BreakBoneInternal();
		}
	}

	private void BreakBoneInternal()
	{
		Broken = true;
		if (HasJoint)
		{
			if (IsLethalToBreak)
			{
				Health = 0f;
			}
			if (NodeBehaviour.IsConnectedToRoot)
			{
				Person.ShockLevel += UnityEngine.Random.value * 5f;
				Person.Wince(UnityEngine.Random.value * 150f);
			}
			if ((double)UnityEngine.Random.value > 0.9)
			{
				CirculationBehaviour.InternalBleedingIntensity += UnityEngine.Random.value;
			}
			PhysicalBehaviour.PlayClipOnce(Person.BoneBreakClips.PickRandom());
			if (Joint.useLimits)
			{
				JointAngleLimits2D limits = Joint.limits;
				limits.max = Mathf.Lerp(limits.max, 180f, 0.5f);
				limits.min = Mathf.Lerp(limits.min, -180f, 0.5f);
				Joint.limits = limits;
			}
		}
	}

	public void HealBone()
	{
		Broken = false;
		if ((bool)Joint && Joint.useLimits)
		{
			JointStress = 0f;
			JointAngleLimits2D limits = Joint.limits;
			limits.min = OriginalJointLimits.x;
			limits.max = OriginalJointLimits.y;
			Joint.limits = limits;
		}
	}

	private void SetMotorStrength(float strength)
	{
		JointMotor2D motor = Joint.motor;
		float num = 1f;
		if (IsActiveInCurrentPose)
		{
			RagdollPose.LimbPose limbPose = Person.ActivePose.AngleDictionary[this];
			num = Mathf.Clamp01(1f + limbPose.PoseRigidityModifier);
		}
		motor.maxMotorTorque = strength * (IsAndroid ? 6f : 1f) * num;
		Joint.motor = motor;
	}

	private void SetMotorStrengthToMuscleStrength()
	{
		SetMotorStrength(Mathf.Max(MotorStrength, SkinMaterialHandler.RottenProgress * 0.8f));
	}

	private void SetJointFragility()
	{
		if (!HasJoint)
		{
			return;
		}
		if (PhysicalBehaviour.isDisintegrated)
		{
			Joint.breakForce = 0f;
			return;
		}
		float num = BreakingThreshold * 120f * Mathf.Clamp(1f - SkinMaterialHandler.RottenProgress, 0.1f, 1f) * GetMassStrengthRatio();
		if (!IsAndroid)
		{
			num *= Mathf.Clamp(Utils.MapRange(-100f, 0f, 0.1f, 1f, PhysicalBehaviour.Temperature), 0.1f, 1f);
		}
		if (float.IsInfinity(num))
		{
			num = float.MaxValue;
		}
		Joint.breakForce = num * (IsAndroid ? 80f : 2.5f);
		Joint.breakTorque = num * 5000f;
	}

	public void InfluenceMotorSpeed(float value, float influence = 0.5f)
	{
		if (HasJoint)
		{
			JointMotor2D motor = Joint.motor;
			motor.motorSpeed = Mathf.Lerp(motor.motorSpeed, value, influence);
			Joint.motor = motor;
		}
	}

	private void OnJointBreak2D(Joint2D joint)
	{
		if (!(joint != Joint))
		{
			CirculationBehaviour.ActOnJointBreak2D(joint);
			if (IsLethalToBreak)
			{
				Health = 0f;
			}
			if (NodeBehaviour.IsConnectedToRoot && !IsParalysed)
			{
				Person.AddPain(15f);
			}
			if (Joint.connectedBody.TryGetComponent(out ConnectedNodeBehaviour component))
			{
				NodeBehaviour.DisconnectFrom(component);
			}
			GoreStringBehaviour component2;
			if (!UserPreferenceManager.Current.GorelessMode && UserPreferenceManager.Current.DismembermentLooseTissue && UnityEngine.Random.value > 0.5f && SkinMaterialHandler.AcidProgress < 0.7f && PhysicalBehaviour.BurnProgress < 0.8f && TryGetComponent(out component2) && component2.enabled && !component2.Joint)
			{
				component2.CreateJoint();
			}
			IsDismembered = true;
			Vector3 v = base.transform.TransformPoint(Joint.anchor);
			SkinMaterialHandler.AddDamagePoint(DamageType.Dismemberment, v, 15f);
			PhysicalBehaviour.PlayClipOnce(Person.DismembermentClips.PickRandom());
			SynchroniseDismemberment();
		}
	}

	private void SynchroniseDismemberment()
	{
		if (!IsDismembered)
		{
			return;
		}
		if ((bool)Joint)
		{
			UnityEngine.Object.Destroy(Joint);
		}
		HasJoint = false;
		for (int i = 0; i < ConnectedLimbs.Count; i++)
		{
			LimbBehaviour limbBehaviour = ConnectedLimbs[i];
			limbBehaviour.ConnectedLimbs.Remove(this);
			if (limbBehaviour.CirculationBehaviour.Source == this)
			{
				limbBehaviour.CirculationBehaviour.Source = null;
			}
		}
		if ((bool)CirculationBehaviour.Source)
		{
			ConnectedLimbs.Remove(CirculationBehaviour.Source.Limb);
			CirculationBehaviour.Source.Limb.ConnectedLimbs.Remove(this);
		}
	}

	public void Damage(float damage)
	{
		if (UserPreferenceManager.Current.StopAnimationOnDamage && !IsZombie && damage > 15.5f && NodeBehaviour.IsConnectedToRoot)
		{
			Person.OverridePoseIndex = -1;
		}
		Health -= damage;
		if (Health < 0f)
		{
			CirculationBehaviour.IsPump = false;
		}
	}

	public void Shot(Shot shot)
	{
		if (ImmuneToDamage)
		{
			return;
		}
		shot.damage /= GetMassStrengthRatio();
		if (IsAndroid)
		{
			if (shot.damage < 40f)
			{
				return;
			}
			shot.damage *= 0.2f;
		}
		else
		{
			shotHeat += 1f;
		}
		if (HasLungs && !IsAndroid && UnityEngine.Random.value > 0.9f)
		{
			LungsPunctured = true;
		}
		bool flag = IsWorldPointInVitalPart(shot.point) && UnityEngine.Random.value > 0.05f;
		float num = (flag ? 7f : 0.1f) * shot.damage;
		if (!UserPreferenceManager.Current.GorelessMode && UserPreferenceManager.Current.ChunkyShotParticles && (bool)Person.PoolableImpactEffect && (double)PhysicalBehaviour.BurnProgress < 0.6 && SkinMaterialHandler.AcidProgress < 0.7f && num > Person.ImpactEffectShotDamageThreshold && UnityEngine.Random.value > 0.8f)
		{
			GameObject gameObject = PoolGenerator.Instance.RequestPrefab(Person.PoolableImpactEffect, shot.point);
			if ((bool)gameObject)
			{
				gameObject.transform.right = shot.normal;
			}
		}
		if (NodeBehaviour.IsConnectedToRoot)
		{
			Person.AdrenalineLevel += 0.5f;
			if (!IsAndroid && !IsZombie)
			{
				Person.ShockLevel += num * UnityEngine.Random.value * 0.0025f;
				Person.Wince(300f);
				Numbness = 1f;
				if (UnityEngine.Random.value * Vitality > 0.9f && !IsParalysed)
				{
					Person.AddPain(UnityEngine.Random.value * 2f);
				}
				if (num > 5f * UnityEngine.Random.value)
				{
					if (shot.normal.x > 0f == Person.transform.localScale.x > 0f)
					{
						Person.DesiredWalkingDirection -= UnityEngine.Random.value * 2f;
					}
					else
					{
						Person.DesiredWalkingDirection += UnityEngine.Random.value * 2f;
					}
				}
				Person.SendMessage("Shot", shot);
			}
			if ((HasBrain && !IsAndroid) & flag)
			{
				if (IsZombie && UnityEngine.Random.value > 0.2f)
				{
					return;
				}
				if (UnityEngine.Random.value > 0.5f)
				{
					Health = 0f;
				}
				if (UnityEngine.Random.value > 0.5f)
				{
					Person.Consciousness = 0f;
				}
			}
		}
		if (UserPreferenceManager.Current.LimbCrushing && shotHeat > 5f && (double)UnityEngine.Random.value > 0.5)
		{
			if (UserPreferenceManager.Current.StopAnimationOnDamage)
			{
				Person.OverridePoseIndex = -1;
			}
			StartCoroutine(_003CShot_003Eg__crushNextFrame_007C118_0());
		}
		if (IsZombie || UnityEngine.Random.value < 0.01f)
		{
			Damage(num * ShotDamageMultiplier * 0.01f);
		}
		else
		{
			if (!IsAndroid)
			{
				CirculationBehaviour.InternalBleedingIntensity += num;
				if (flag)
				{
					CirculationBehaviour.InternalBleedingIntensity += 5f;
				}
			}
			Damage(Mathf.Min(InitialHealth / 2f, num * ShotDamageMultiplier * 2f));
		}
		float b = shot.damage * 0.1f;
		SkinMaterialHandler.AddDamagePoint(DamageType.Bullet, shot.point, Mathf.Max(50f, b));
	}

	public void ExitShot(Shot shot)
	{
		if (ImmuneToDamage)
		{
			return;
		}
		shot.damage /= GetMassStrengthRatio();
		SkinMaterialHandler.AddDamagePoint(DamageType.Bullet, shot.point, Mathf.Max(60f, shot.damage * 0.4f));
		if (!UserPreferenceManager.Current.GorelessMode && UserPreferenceManager.Current.ChunkyShotParticles && (bool)Person.PoolableImpactEffect && (double)PhysicalBehaviour.BurnProgress < 0.6 && SkinMaterialHandler.AcidProgress < 0.7f && shot.damage > Person.ImpactEffectShotDamageThreshold && UnityEngine.Random.value > 0.6f)
		{
			GameObject gameObject = PoolGenerator.Instance.RequestPrefab(Person.PoolableImpactEffect, shot.point);
			if ((bool)gameObject)
			{
				gameObject.transform.right = shot.normal;
			}
		}
		if (HasLungs && !IsAndroid && UnityEngine.Random.value > 0.9f)
		{
			LungsPunctured = true;
		}
		if (UserPreferenceManager.Current.StopAnimationOnDamage && NodeBehaviour.IsConnectedToRoot)
		{
			Person.OverridePoseIndex = -1;
		}
		if (!UserPreferenceManager.Current.GorelessMode && !KillShotParticlesEmitted && Health <= float.Epsilon && (bool)KillShotParticles && UnityEngine.Random.value > 0.7f)
		{
			KillShotParticles.transform.right = shot.normal;
			KillShotParticles.Play();
			PhysicalBehaviour.PlayClipOnce(Person.DismembermentClips.PickRandom());
			KillShotParticlesEmitted = true;
		}
		if (IsAndroid || CirculationBehaviour.GetAmountOfBlood() < 0.05f)
		{
			return;
		}
		Color computedColor = CirculationBehaviour.GetComputedColor(GetOriginalBloodType().Color);
		for (int i = 0; i < UnityEngine.Random.Range(1, 4); i++)
		{
			RaycastHit2D hit = Physics2D.Raycast(shot.point, shot.normal + UnityEngine.Random.insideUnitCircle * 0.4f, 3f);
			if ((bool)hit && (bool)hit.transform)
			{
				hit.transform.gameObject.SendMessage("Decal", new DecalInstruction(BloodDecal, hit.point, computedColor), SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	public void WaterImpact(float magnitude)
	{
		if (!ImmuneToDamage && magnitude > 30f)
		{
			Damage(magnitude * 0.06f);
			if (!IsAndroid)
			{
				SkinMaterialHandler.AcidProgress = Mathf.Min(SkinMaterialHandler.AcidProgress + magnitude * 0.05f, 0.6f);
			}
		}
	}

	public void Wince(float intensity = 1f)
	{
		if (HasJoint && NodeBehaviour.IsConnectedToRoot && !(Health < 0.1f))
		{
			float value = 60f * intensity * (Mathf.PerlinNoise(Time.time * 8f, randomOffset) * 2f - 1f);
			InfluenceMotorSpeed(Mathf.Clamp(value, -450f, 450f));
		}
	}

	public void OnEMPHit()
	{
		if (IsAndroid)
		{
			Health = 0f;
		}
	}

	public bool IsWorldPointInVitalPart(Vector2 worldPoint, float mindistance = 4f / 35f)
	{
		if (VitalParts == null)
		{
			return false;
		}
		float num = mindistance * mindistance;
		Vector3 vector = base.transform.InverseTransformPoint(worldPoint);
		for (int i = 0; i < VitalParts.Length; i++)
		{
			if ((VitalParts[i].ClosestPoint(vector) - vector).sqrMagnitude <= num)
			{
				return true;
			}
		}
		return false;
	}

	public void Stabbed(Stabbing stab)
	{
		if (ImmuneToDamage || !stab.stabber.StabCausesWound)
		{
			return;
		}
		if (CirculationBehaviour.GetAmountOfBlood() > 0.2f)
		{
			stab.stabber.SendMessage("Decal", new DecalInstruction(BloodDecal, stab.point, CirculationBehaviour.GetComputedColor(GetOriginalBloodType().Color)), SendMessageOptions.DontRequireReceiver);
		}
		if (HasLungs && !IsAndroid && UnityEngine.Random.value > 0.9f)
		{
			LungsPunctured = true;
		}
		bool flag = IsWorldPointInVitalPart(stab.point) && UnityEngine.Random.value > 0.05f;
		Damage(Health * 0.5f * (IsZombie ? 0.1f : 1f) * (float)((!flag) ? 1 : 2));
		if (flag && !IsZombie)
		{
			CirculationBehaviour.InternalBleedingIntensity += 5f * UnityEngine.Random.value;
		}
		Wince(165f);
		if (!IsZombie && NodeBehaviour.IsConnectedToRoot)
		{
			Person.ShockLevel += UnityEngine.Random.value;
		}
		Numbness = 1f;
		Person.AdrenalineLevel += 1f;
		if (HasBrain && flag && (!IsZombie || !(UnityEngine.Random.value > 0.5f)))
		{
			Person.AddPain(90f);
			CirculationBehaviour.InternalBleedingIntensity += 5f * UnityEngine.Random.value;
			Health = 0f;
			if (UnityEngine.Random.value > 0.25f)
			{
				Person.Consciousness = 0f;
			}
		}
	}

	public void Slice()
	{
		if (ImmuneToDamage)
		{
			return;
		}
		if (UserPreferenceManager.Current.StopAnimationOnDamage && NodeBehaviour.IsConnectedToRoot)
		{
			Person.OverridePoseIndex = -1;
		}
		Person.AdrenalineLevel += 1f;
		if (!HasJoint)
		{
			return;
		}
		RegenerationSpeed = 0f;
		Health = 0f;
		ActOnImpact(15f, base.transform.TransformPoint(Joint.anchor));
		BreakingThreshold = 0f;
		if (IsAndroid)
		{
			for (int i = 0; i < Person.Limbs.Length; i++)
			{
				LimbBehaviour obj = Person.Limbs[i];
				obj.CirculationBehaviour.IsPump = false;
				obj.RegenerationSpeed = 0f;
				obj.Health = 0f;
			}
		}
	}

	public void Crush()
	{
		if (PhysicalBehaviour.isDisintegrated)
		{
			return;
		}
		if (UserPreferenceManager.Current.StopAnimationOnDamage && NodeBehaviour.IsConnectedToRoot)
		{
			Person.OverridePoseIndex = -1;
		}
		if (!UserPreferenceManager.Current.GorelessMode)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(Person.BloodExplosionPrefab, base.transform.position, Quaternion.identity);
			if (!IsAndroid)
			{
				gameObject.GetComponentInChildren<BloodExplosionBehaviour>().SetColor(CirculationBehaviour.GetComputedColor(GetOriginalBloodType().Color));
			}
		}
		if (!PhysicalBehaviour.isDisintegrated)
		{
			PhysicalBehaviour.Disintegrate();
		}
	}

	public void StunImpact()
	{
		if (IsAndroid)
		{
			PhysicalBehaviour.Charge += 10f;
			return;
		}
		PhysicalBehaviour.Charge += 1f;
		if (NodeBehaviour.IsConnectedToRoot && !IsParalysed)
		{
			Person.AddPain(150f);
			if (UserPreferenceManager.Current.StopAnimationOnDamage)
			{
				Person.OverridePoseIndex = -1;
			}
		}
		StartCoroutine(Utils.DelayCoroutine(UnityEngine.Random.value * 0.8f, delegate
		{
			Numbness = 1f;
			if (NodeBehaviour.IsConnectedToRoot)
			{
				Person.Consciousness = 0f;
			}
		}));
	}

	public void OnDestroy()
	{
		LimbBehaviourManager.Limbs.Remove(this);
		UnityEngine.Object.Destroy(myStatus);
	}

	public void ManagedLateUpdate()
	{
	}

	public bool ShouldUpdate()
	{
		return base.enabled;
	}

	[CompilerGenerated]
	private IEnumerator _003CShot_003Eg__crushNextFrame_007C118_0()
	{
		yield return new WaitForEndOfFrame();
		yield return new WaitForFixedUpdate();
		SkinMaterialHandler.AddDamagePoint(DamageType.Dismemberment, base.transform.position, 15f);
		Crush();
	}
}
