using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class PinkSyringe : SyringeBehaviour
{
	public class PinkDormantLiquid : TemporaryBodyLiquid
	{
		public const string ID = "INERT PINK LIQUID";

		public override string GetDisplayName()
		{
			return "Inert pink liquid";
		}

		public PinkDormantLiquid()
		{
			Color = PinkSyringeColor;
		}

		public override void OnEnterLimb(LimbBehaviour limb)
		{
		}

		public override void OnEnterContainer(BloodContainer container)
		{
		}

		public override void OnExitContainer(BloodContainer container)
		{
		}
	}

	public class VestibularPoison : TemporaryBodyLiquid
	{
		public const string ID = "VESTIBULAR POISON";

		public override bool ShouldCallOnEnterEveryUpdate => false;

		public override string GetDisplayName()
		{
			return "Vestibular poison";
		}

		public VestibularPoison()
		{
			Color = PinkSyringeColor;
		}

		public override void OnEnterLimb(LimbBehaviour limb)
		{
			if (!(limb.SpeciesIdentity == "Android"))
			{
				limb.BalanceMuscleMovement += Random.Range(-1, 1);
				limb.DoBalanceJerk ^= ((float)Random.Range(-1, 1) > 0.7f);
				limb.DoStumble ^= ((float)Random.Range(-1, 1) > 0.7f);
				if (limb.HasBrain)
				{
					limb.CirculationBehaviour.InternalBleedingIntensity += Random.value;
				}
			}
		}

		public override void OnEnterContainer(BloodContainer container)
		{
		}

		public override void OnExitContainer(BloodContainer container)
		{
		}
	}

	public class MusclePoison : TemporaryBodyLiquid
	{
		public const string ID = "MUSCLE POISON";

		public override bool ShouldCallOnEnterEveryUpdate => false;

		public override string GetDisplayName()
		{
			return "Muscle poison";
		}

		public MusclePoison()
		{
			Color = PinkSyringeColor;
		}

		public override void OnEnterLimb(LimbBehaviour limb)
		{
			if (!(limb.SpeciesIdentity == "Android"))
			{
				limb.BloodMuscleStrengthRatio += Random.Range(-1, 1);
			}
		}

		public override void OnEnterContainer(BloodContainer container)
		{
		}

		public override void OnExitContainer(BloodContainer container)
		{
		}
	}

	public class NumbingPoison : TemporaryBodyLiquid
	{
		public const string ID = "NUMBING POISON";

		public override bool ShouldCallOnEnterEveryUpdate => false;

		public override string GetDisplayName()
		{
			return "Numbing poison";
		}

		public NumbingPoison()
		{
			Color = PinkSyringeColor;
		}

		public override void OnEnterLimb(LimbBehaviour limb)
		{
			if (!(limb.SpeciesIdentity == "Android"))
			{
				limb.Numbness += Random.Range(-1, 1);
			}
		}

		public override void OnEnterContainer(BloodContainer container)
		{
		}

		public override void OnExitContainer(BloodContainer container)
		{
		}
	}

	public class ReflectionPoison : TemporaryBodyLiquid
	{
		public const string ID = "MIRRORISING AGENT";

		public override bool ShouldCallOnEnterEveryUpdate => false;

		public override string GetDisplayName()
		{
			return "Mirrorising agent";
		}

		public ReflectionPoison()
		{
			Color = PinkSyringeColor;
		}

		public override void OnEnterLimb(LimbBehaviour limb)
		{
			if (!(limb.SpeciesIdentity == "Android"))
			{
				limb.PhysicalBehaviour.ReflectsLasers = true;
			}
		}

		public override void OnEnterContainer(BloodContainer container)
		{
		}

		public override void OnExitContainer(BloodContainer container)
		{
		}
	}

	public class TransparencyPoison : TemporaryBodyLiquid
	{
		public const string ID = "TRANSPARENCY AGENT";

		public override bool ShouldCallOnEnterEveryUpdate => false;

		public override string GetDisplayName()
		{
			return "Transparency agent";
		}

		public TransparencyPoison()
		{
			Color = PinkSyringeColor;
		}

		public override void OnEnterLimb(LimbBehaviour limb)
		{
			if (!(limb.SpeciesIdentity == "Android"))
			{
				limb.PhysicalBehaviour.AbsorbsLasers = false;
			}
		}

		public override void OnEnterContainer(BloodContainer container)
		{
		}

		public override void OnExitContainer(BloodContainer container)
		{
		}
	}

	public class CrushingPoison : TemporaryBodyLiquid
	{
		public const string ID = "CRUSHING POISON";

		public override bool ShouldCallOnEnterEveryUpdate => false;

		public override string GetDisplayName()
		{
			return "Crushing poison";
		}

		public CrushingPoison()
		{
			Color = PinkSyringeColor;
		}

		public override void OnEnterLimb(LimbBehaviour limb)
		{
			if (!(limb.SpeciesIdentity == "Android") && Random.value > 0.5f)
			{
				limb.Crush();
			}
		}

		public override void OnEnterContainer(BloodContainer container)
		{
		}

		public override void OnExitContainer(BloodContainer container)
		{
		}
	}

	public class MassManipulationPoison : TemporaryBodyLiquid
	{
		public const string ID = "MASS AGENT";

		public override bool ShouldCallOnEnterEveryUpdate => false;

		public override string GetDisplayName()
		{
			return "Mass agent";
		}

		public MassManipulationPoison()
		{
			Color = PinkSyringeColor;
		}

		public override void OnEnterLimb(LimbBehaviour limb)
		{
			if (!(limb.SpeciesIdentity == "Android"))
			{
				limb.PhysicalBehaviour.rigidbody.mass *= Random.Range(-1, 1);
				limb.PhysicalBehaviour.rigidbody.gravityScale *= Random.Range(-1, 1);
			}
		}

		public override void OnEnterContainer(BloodContainer container)
		{
		}

		public override void OnExitContainer(BloodContainer container)
		{
		}
	}

	public class ExplosionPoison : TemporaryBodyLiquid
	{
		public const string ID = "EXPLOSION POISON";

		public override bool ShouldCallOnEnterEveryUpdate => false;

		public override string GetDisplayName()
		{
			return "Explosion poison";
		}

		public ExplosionPoison()
		{
			Color = PinkSyringeColor;
		}

		public override void OnEnterLimb(LimbBehaviour limb)
		{
			if (!(limb.SpeciesIdentity == "Android"))
			{
				ExplosionCreator.CreateExplosionWithWater(WaterBehaviour.IsPointUnderWater(limb.transform.position), new ExplosionCreator.ExplosionParameters(32u, limb.transform.position, 9f, 25f, createFx: true, Random.value > 0.9f, Random.value));
			}
		}

		public override void OnEnterContainer(BloodContainer container)
		{
		}

		public override void OnExitContainer(BloodContainer container)
		{
		}
	}

	public class DurabilitySerum : TemporaryBodyLiquid
	{
		public const string ID = "DURABILITY SERUM";

		public override bool ShouldCallOnEnterEveryUpdate => false;

		public override string GetDisplayName()
		{
			return "Durability serum";
		}

		public DurabilitySerum()
		{
			Color = PinkSyringeColor;
		}

		public override void OnEnterLimb(LimbBehaviour limb)
		{
			if (!(limb.SpeciesIdentity == "Android"))
			{
				limb.InitialHealth += Random.value * 5f;
				limb.Health += limb.InitialHealth;
			}
		}

		public override void OnEnterContainer(BloodContainer container)
		{
		}

		public override void OnExitContainer(BloodContainer container)
		{
		}
	}

	public class RegenerationSerum : TemporaryBodyLiquid
	{
		public const string ID = "REGENERATION SERUM";

		public override bool ShouldCallOnEnterEveryUpdate => false;

		public override string GetDisplayName()
		{
			return "Regeneration serum";
		}

		public RegenerationSerum()
		{
			Color = PinkSyringeColor;
		}

		public override void OnEnterLimb(LimbBehaviour limb)
		{
			if (!(limb.SpeciesIdentity == "Android"))
			{
				limb.RegenerationSpeed += 1f;
			}
		}

		public override void OnEnterContainer(BloodContainer container)
		{
		}

		public override void OnExitContainer(BloodContainer container)
		{
		}
	}

	public class SizeManipulationPoison : TemporaryBodyLiquid
	{
		public const string ID = "DISTORTION POISON";

		public override bool ShouldCallOnEnterEveryUpdate => false;

		public override string GetDisplayName()
		{
			return "Distortion poison";
		}

		public SizeManipulationPoison()
		{
			Color = PinkSyringeColor;
		}

		public override void OnEnterLimb(LimbBehaviour limb)
		{
			if (!(limb.SpeciesIdentity == "Android"))
			{
				limb.transform.localScale = new Vector3(Random.Range(0.952381f, 1.05f) * limb.transform.localScale.x, Random.Range(0.952381f, 1.05f) * limb.transform.localScale.y);
			}
		}

		public override void OnEnterContainer(BloodContainer container)
		{
		}

		public override void OnExitContainer(BloodContainer container)
		{
		}
	}

	public class CirculationPoison : TemporaryBodyLiquid
	{
		public const string ID = "CIRCULATION POISON";

		public override bool ShouldCallOnEnterEveryUpdate => false;

		public override string GetDisplayName()
		{
			return "Circulation poison";
		}

		public CirculationPoison()
		{
			Color = PinkSyringeColor;
		}

		public override void OnEnterLimb(LimbBehaviour limb)
		{
			if (!(limb.SpeciesIdentity == "Android"))
			{
				CirculationBehaviour circulationBehaviour = limb.CirculationBehaviour;
				circulationBehaviour.BleedingRate *= Mathf.Abs(Random.Range(-1, 1));
				circulationBehaviour.BloodLossRateMultiplier += (float)Random.Range(-1, 1) * 0.2f;
				circulationBehaviour.IsPump ^= ((float)Random.Range(-1, 1) > 0.9f);
				circulationBehaviour.WasInitiallyPumping ^= ((float)Random.Range(-1, 1) > 0.7f);
				limb.CirculationBehaviour.InternalBleedingIntensity *= Random.Range(0, 8);
				limb.Vitality *= Random.Range(-1, 1) * 8;
				limb.ImpactPainMultiplier *= Random.Range(-1, 1) * 8;
				limb.SkinMaterialHandler.AcidProgress += (float)Random.Range(-1, 1) * 0.05f;
				limb.SkinMaterialHandler.intensityMultiplier += (float)Random.Range(-1, 1) * 0.5f;
				limb.SkinMaterialHandler.RottenProgress += (float)Random.Range(-1, 1) * 0.05f;
				limb.HasLungs ^= ((double)Random.value > 0.5);
				limb.LungsPunctured ^= ((double)Random.value > 0.5);
			}
		}

		public override void OnEnterContainer(BloodContainer container)
		{
		}

		public override void OnExitContainer(BloodContainer container)
		{
		}
	}

	public class CombustionAgent : Liquid
	{
		public const string ID = "COMBUSTION AGENT";

		public override string GetDisplayName()
		{
			return "Combustion agent";
		}

		public CombustionAgent()
		{
			Color = PinkSyringeColor;
		}

		public override void OnEnterLimb(LimbBehaviour limb)
		{
			if (!(limb.SpeciesIdentity == "Android") && Random.value > 0.95f)
			{
				limb.PhysicalBehaviour.Ignite(ignoreFlammability: true);
			}
		}

		public override void OnEnterContainer(BloodContainer container)
		{
		}

		public override void OnExitContainer(BloodContainer container)
		{
		}

		public override void OnUpdate(BloodContainer c)
		{
			CirculationBehaviour circulationBehaviour = c as CirculationBehaviour;
			if ((object)circulationBehaviour != null && circulationBehaviour.Limb.SpeciesIdentity != "Android")
			{
				circulationBehaviour.Limb.PhysicalBehaviour.Temperature += 10f;
			}
			base.OnUpdate(c);
		}
	}

	public class TissueDeconstructionAgent : TemporaryBodyLiquid
	{
		public const string ID = "TISSUE DECONSTRUCTION AGENT";

		public override bool ShouldCallOnEnterEveryUpdate => false;

		public override string GetDisplayName()
		{
			return "Tissue deconstruction agent";
		}

		public TissueDeconstructionAgent()
		{
			Color = PinkSyringeColor;
		}

		public override void OnEnterLimb(LimbBehaviour limb)
		{
			if (!(limb.SpeciesIdentity == "Android") && Random.value > 0.8f)
			{
				limb.Slice();
			}
		}

		public override void OnEnterContainer(BloodContainer container)
		{
		}

		public override void OnExitContainer(BloodContainer container)
		{
		}
	}

	public class MuscleEnhancementSerum : TemporaryBodyLiquid
	{
		public const string ID = "ENHANCING SERUM";

		public override bool ShouldCallOnEnterEveryUpdate => false;

		public override string GetDisplayName()
		{
			return "Enhancing serum";
		}

		public MuscleEnhancementSerum()
		{
			Color = PinkSyringeColor;
		}

		public override void OnEnterLimb(LimbBehaviour limb)
		{
			if (!(limb.SpeciesIdentity == "Android"))
			{
				limb.BreakingThreshold += Random.value;
				limb.BaseStrength += Random.Range(0, 8);
				limb.RegenerationSpeed += Random.Range(0f, 0.5f);
			}
		}

		public override void OnEnterContainer(BloodContainer container)
		{
		}

		public override void OnExitContainer(BloodContainer container)
		{
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003C_003Ec__DisplayClass3_0
	{
		public float totalAmount;

		public PinkSyringe _003C_003E4__this;
	}

	[HideInInspector]
	public float[] Fingerprint;

	private int fingerprintReadPos;

	public List<(Liquid l, float amount)> liquids = new List<(Liquid, float)>();

	public static readonly Color PinkSyringeColor = new Color(1f, 0.4196079f, 0.7944902f);

	protected override void Start()
	{
		_003C_003Ec__DisplayClass3_0 _003C_003Ec__DisplayClass3_ = default(_003C_003Ec__DisplayClass3_0);
		_003C_003Ec__DisplayClass3_._003C_003E4__this = this;
		if (Fingerprint == null || Fingerprint.Length == 0)
		{
			CreateNewFingerprint();
		}
		AddButtons();
		float item = Utils.MapRange(-1f, 1f, 0.05f, 0.4f, GetFingerprintValue());
		int num = 0;
		_003C_003Ec__DisplayClass3_.totalAmount = 0f;
		while (_003C_003Ec__DisplayClass3_.totalAmount < base.UpperLimit - float.Epsilon && num < 5000)
		{
			if (GetFingerprintValue() > 0.05f)
			{
				_003CStart_003Eg__addToList_007C3_0((Liquid.GetLiquid("INERT PINK LIQUID"), item), ref _003C_003Ec__DisplayClass3_);
			}
			if (GetFingerprintValue() > 0.6f)
			{
				_003CStart_003Eg__addToList_007C3_0((Liquid.GetLiquid("VESTIBULAR POISON"), item), ref _003C_003Ec__DisplayClass3_);
			}
			if (GetFingerprintValue() > 0.6f)
			{
				_003CStart_003Eg__addToList_007C3_0((Liquid.GetLiquid("MUSCLE POISON"), item), ref _003C_003Ec__DisplayClass3_);
			}
			if (GetFingerprintValue() > 0.6f)
			{
				_003CStart_003Eg__addToList_007C3_0((Liquid.GetLiquid("NUMBING POISON"), item), ref _003C_003Ec__DisplayClass3_);
			}
			if (GetFingerprintValue() > 0.85f)
			{
				_003CStart_003Eg__addToList_007C3_0((Liquid.GetLiquid("MIRRORISING AGENT"), item), ref _003C_003Ec__DisplayClass3_);
			}
			if (GetFingerprintValue() > 0.85f)
			{
				_003CStart_003Eg__addToList_007C3_0((Liquid.GetLiquid("TRANSPARENCY AGENT"), item), ref _003C_003Ec__DisplayClass3_);
			}
			if (GetFingerprintValue() > 0.95f)
			{
				_003CStart_003Eg__addToList_007C3_0((Liquid.GetLiquid("MASS AGENT"), item), ref _003C_003Ec__DisplayClass3_);
			}
			if (GetFingerprintValue() > 0.995f)
			{
				_003CStart_003Eg__addToList_007C3_0((Liquid.GetLiquid("EXPLOSION POISON"), item), ref _003C_003Ec__DisplayClass3_);
			}
			if (GetFingerprintValue() > 0.995f)
			{
				_003CStart_003Eg__addToList_007C3_0((Liquid.GetLiquid("CRUSHING POISON"), item), ref _003C_003Ec__DisplayClass3_);
			}
			if (GetFingerprintValue() > 0.9f)
			{
				_003CStart_003Eg__addToList_007C3_0((Liquid.GetLiquid("BONE EATING POISON"), item), ref _003C_003Ec__DisplayClass3_);
			}
			if (GetFingerprintValue() > 0.9f)
			{
				_003CStart_003Eg__addToList_007C3_0((Liquid.GetLiquid("LIFE SERUM"), item), ref _003C_003Ec__DisplayClass3_);
			}
			if (GetFingerprintValue() > 0.6f)
			{
				_003CStart_003Eg__addToList_007C3_0((Liquid.GetLiquid("ULTRA STRENGTH SERUM"), item), ref _003C_003Ec__DisplayClass3_);
			}
			if (GetFingerprintValue() > 0.6f)
			{
				_003CStart_003Eg__addToList_007C3_0((Liquid.GetLiquid("DURABILITY SERUM"), item), ref _003C_003Ec__DisplayClass3_);
			}
			if (GetFingerprintValue() > 0.8f)
			{
				_003CStart_003Eg__addToList_007C3_0((Liquid.GetLiquid("REGENERATION SERUM"), item), ref _003C_003Ec__DisplayClass3_);
			}
			if (GetFingerprintValue() > 0.9f)
			{
				_003CStart_003Eg__addToList_007C3_0((Liquid.GetLiquid("DISTORTION POISON"), item), ref _003C_003Ec__DisplayClass3_);
			}
			if (GetFingerprintValue() > 0.95f)
			{
				_003CStart_003Eg__addToList_007C3_0((Liquid.GetLiquid("FREEZE POISON"), item), ref _003C_003Ec__DisplayClass3_);
			}
			if (GetFingerprintValue() > 0.99f)
			{
				_003CStart_003Eg__addToList_007C3_0((Liquid.GetLiquid("INSTANT DEATH POISON"), item), ref _003C_003Ec__DisplayClass3_);
			}
			if (GetFingerprintValue() > 0.4f)
			{
				_003CStart_003Eg__addToList_007C3_0((Liquid.GetLiquid("CIRCULATION POISON"), item), ref _003C_003Ec__DisplayClass3_);
			}
			if (GetFingerprintValue() > 0.4f)
			{
				_003CStart_003Eg__addToList_007C3_0((Liquid.GetLiquid("ENHANCING SERUM"), item), ref _003C_003Ec__DisplayClass3_);
			}
			if (GetFingerprintValue() > 0.95f)
			{
				_003CStart_003Eg__addToList_007C3_0((Liquid.GetLiquid("COMBUSTION AGENT"), item), ref _003C_003Ec__DisplayClass3_);
			}
			if (GetFingerprintValue() > 0.95f)
			{
				_003CStart_003Eg__addToList_007C3_0((Liquid.GetLiquid("TISSUE DECONSTRUCTION AGENT"), item), ref _003C_003Ec__DisplayClass3_);
			}
			num++;
		}
		NewlySpawned = false;
	}

	protected override void FixedUpdate()
	{
		if (!Finite)
		{
			float num = base.UpperLimit - base.TotalLiquidAmount;
			float num2 = TransferRate * num;
			foreach (var liquid in liquids)
			{
				Liquid item = liquid.l;
				float item2 = liquid.amount;
				AddLiquid(item, item2 * num2);
			}
		}
		base.FixedUpdate();
	}

	private void CreateNewFingerprint()
	{
		fingerprintReadPos = 0;
		Fingerprint = new float[64];
		for (int i = 0; i < Fingerprint.Length; i++)
		{
			Fingerprint[i] = Random.Range(-1f, 1f);
		}
	}

	protected float GetFingerprintValue()
	{
		float result = Fingerprint[fingerprintReadPos];
		fingerprintReadPos++;
		if (fingerprintReadPos >= Fingerprint.Length)
		{
			fingerprintReadPos = 0;
		}
		return result;
	}

	public override string GetLiquidID()
	{
		return null;
	}

	[CompilerGenerated]
	private void _003CStart_003Eg__addToList_007C3_0((Liquid l, float amount) z, ref _003C_003Ec__DisplayClass3_0 P_1)
	{
		P_1.totalAmount += z.amount;
		liquids.Add(z);
		if (NewlySpawned)
		{
			AddLiquid(z.l, z.amount);
		}
	}
}
