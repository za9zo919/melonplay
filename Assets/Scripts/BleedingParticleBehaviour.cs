using UnityEngine;

public class BleedingParticleBehaviour : MonoBehaviour
{
	public CirculationBehaviour CirculationBehaviour;

	public ParticleSystem BloodParticleSystem;

	public ParticleSystem WaterPuffSystem;

	public CirculationBehaviour PushingTo;

	public FancyBloodSplatController BloodSplatController;

	public bool IsOnlyForInternalBleeding;

	private ParticleSystem.MainModule main;

	private ParticleSystem.EmissionModule emission;

	public float SpeedMultiplier = 1f;

	public float RateMultiplier = 1f;

	public bool ShouldBecomeSmokeInWater;

	private void Awake()
	{
		BloodParticleSystem = GetComponent<ParticleSystem>();
		main = BloodParticleSystem.main;
		emission = BloodParticleSystem.emission;
	}

	private void Start()
	{
		if (!ShouldBecomeSmokeInWater && (bool)WaterPuffSystem)
		{
			Object.Destroy(WaterPuffSystem);
		}
	}

	private void Update()
	{
		float num = (IsOnlyForInternalBleeding ? CirculationBehaviour.InternalBleedingIntensity : CirculationBehaviour.BleedingRate);
		if ((!PushingTo || PushingTo.IsDisconnected) && num > 0.05f && CirculationBehaviour.ScaledLiquidAmount > 0.05f && CirculationBehaviour.Limb.PhysicalBehaviour.Temperature > 0f)
		{
			Color color = CirculationBehaviour.GetComputedColor(CirculationBehaviour.Limb.GetOriginalBloodType().Color);
			if (UserPreferenceManager.Current.GorelessMode)
			{
				color = Utils.ChangeRedToOrange(in color);
			}
			bool flag = WaterBehaviour.IsPointUnderWater(base.transform.position);
			main.startSpeedMultiplier = SpeedMultiplier * (CirculationBehaviour.BloodFlow * CirculationBehaviour.BloodFlow * CirculationBehaviour.BloodFlow * 2f) * CirculationBehaviour.BloodLossRateMultiplier;
			main.startColor = color;
			float num2 = ((CirculationBehaviour.TotalLiquidAmount > float.Epsilon) ? Mathf.Min(CirculationBehaviour.BloodLossRateMultiplier * num, 1f) : 0f);
			emission.rateOverTimeMultiplier = (flag ? 0f : (18f * num2 * RateMultiplier));
			emission.enabled = true;
			if ((bool)BloodSplatController)
			{
				BloodSplatController.DecalColourMultiplier = color;
				BloodSplatController.EjectionForce = new Vector2(0.25f, 0.35f) * main.startSpeedMultiplier;
				BloodSplatController.SpawningChance = (flag ? 0f : (CirculationBehaviour.TotalLiquidAmount * 0.5f));
			}
			if (!ShouldBecomeSmokeInWater || !WaterPuffSystem)
			{
				return;
			}
			ParticleSystem.MainModule mainModule = WaterPuffSystem.main;
			mainModule.startColor = color;
			if (flag)
			{
				ParticleSystem.EmissionModule emissionModule = WaterPuffSystem.emission;
				emissionModule.rateOverTimeMultiplier = num2;
				if (!WaterPuffSystem.isPlaying)
				{
					WaterPuffSystem.Play();
				}
			}
			else if (WaterPuffSystem.isPlaying)
			{
				WaterPuffSystem.Stop();
			}
		}
		else
		{
			main.startSpeedMultiplier = 0f;
			emission.rateOverTimeMultiplier = 0f;
			emission.enabled = false;
			if ((bool)BloodSplatController)
			{
				BloodSplatController.SpawningChance = 0f;
			}
			if (ShouldBecomeSmokeInWater && (bool)WaterPuffSystem && WaterPuffSystem.isPlaying)
			{
				WaterPuffSystem.Stop();
			}
		}
	}
}
