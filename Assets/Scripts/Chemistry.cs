using System.Runtime.InteropServices;
using UnityEngine;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct Chemistry
{
	public class ExoticLiquid : Liquid
	{
		public const string ID = "EXOTIC LIQUID";

		public override string GetDisplayName()
		{
			return "Exotic liquid";
		}

		public ExoticLiquid()
		{
			Color = new Color(0f, 0f, 1f, 1f);
		}

		public override void OnEnterContainer(BloodContainer container)
		{
			StatManager.UnlockAchievement("CHEMIST");
		}

		public override void OnEnterLimb(LimbBehaviour limb)
		{
			if ((double)Random.value > 0.9 && limb.NodeBehaviour.IsConnectedToRoot)
			{
				limb.Person.AddPain(Random.value * 50f);
			}
			if ((double)Random.value > 0.9 && limb.RoughClassification == LimbBehaviour.BodyPart.Head)
			{
				limb.Person.Consciousness *= Random.value;
			}
		}

		public override void OnExitContainer(BloodContainer container)
		{
		}

		public override void OnUpdate(BloodContainer container)
		{
			if (Random.value > 0.8f / Mathf.Clamp(container.GetAmount(this), 0.5f, 2f) && Global.main.PhysicalObjectsInWorldByTransform.TryGetValue(container.transform, out PhysicalBehaviour phys))
			{
				container.StartCoroutine(Utils.DelayCoroutine(Random.value * 0.4f, delegate
				{
					phys.rigidbody.AddForce(Random.insideUnitCircle);
					Object.Instantiate(Resources.Load<GameObject>("Prefabs/Exotic flash"), (Vector2)container.transform.TransformPoint(phys.GetRandomGridPoint()) + Random.insideUnitCircle * 2f, Quaternion.identity);
				}));
				if ((double)Random.value > 0.8)
				{
					phys.Charge += 0.5f;
				}
				phys.Temperature -= Random.value * 5f;
			}
		}
	}

	public class InertLiquid : Liquid
	{
		public const string ID = "INERT LIQUID";

		public override string GetDisplayName()
		{
			return "Inert liquid";
		}

		public InertLiquid()
		{
			Color = new Color(1f, 1f, 1f, 0.1f);
		}

		public override void OnEnterContainer(BloodContainer container)
		{
		}

		public override void OnEnterLimb(LimbBehaviour limb)
		{
		}

		public override void OnExitContainer(BloodContainer container)
		{
		}
	}

	public class BeverageM04 : Liquid
	{
		public const string ID = "BEVERAGE M04";

		public override string GetDisplayName()
		{
			return "Beverage M04";
		}

		public BeverageM04()
		{
			Color = new Color(0.91f, 0.25f, 0f, 0.5f);
		}

		public override void OnEnterContainer(BloodContainer container)
		{
		}

		public override void OnEnterLimb(LimbBehaviour limb)
		{
		}

		public override void OnExitContainer(BloodContainer container)
		{
		}

		public override void OnUpdate(BloodContainer container)
		{
			base.OnUpdate(container);
			CirculationBehaviour circulationBehaviour = container as CirculationBehaviour;
			if ((object)circulationBehaviour == null)
			{
				return;
			}
			LimbBehaviour limb = circulationBehaviour.Limb;
			string speciesIdentity = limb.SpeciesIdentity;
			if (speciesIdentity == null)
			{
				return;
			}
			if (!(speciesIdentity == "Human"))
			{
				if (!(speciesIdentity == "Gorse"))
				{
					if (speciesIdentity == "Android")
					{
						limb.PhysicalBehaviour.Charge += Random.value;
					}
					return;
				}
				limb.SkinMaterialHandler.AcidProgress += 0.05f;
				if (limb.NodeBehaviour.IsConnectedToRoot)
				{
					limb.Person.Consciousness *= 0.8f;
				}
			}
			else if (limb.NodeBehaviour.IsConnectedToRoot)
			{
				limb.Person.AdrenalineLevel += 0.1f;
			}
		}
	}

	public class DebugDiscolorationLiquid : TemporaryBodyLiquid
	{
		public const string ID = "DEBUG LIQUID 001";

		public override string GetDisplayName()
		{
			return "Debug discoloration liquid";
		}

		public DebugDiscolorationLiquid()
		{
			Color = new Color(1f, 0f, 1f);
		}

		public override void OnEnterContainer(BloodContainer container)
		{
		}

		public override void OnEnterLimb(LimbBehaviour limb)
		{
			limb.Color = Color.magenta;
		}

		public override void OnExitContainer(BloodContainer container)
		{
		}
	}

	public class Tritium : Liquid
	{
		public const string ID = "TRITIUM";

		public override string GetDisplayName()
		{
			return "Tritium";
		}

		public Tritium()
		{
			Color = new Color(0.08f, 0.62f, 0.28f, 1f) * 2f;
		}

		public override void OnEnterContainer(BloodContainer container)
		{
			container.gameObject.GetOrAddComponent<GlowInTheDarkBehaviour>();
		}

		public override void OnEnterLimb(LimbBehaviour limb)
		{
			if (limb.HasBrain && limb.Person.Braindead)
			{
				limb.Health += 0.1f;
				limb.Person.Braindead = false;
			}
		}

		public override void OnExitContainer(BloodContainer container)
		{
			if (container.TryGetComponent(out GlowInTheDarkBehaviour component))
			{
				UnityEngine.Object.Destroy(component);
			}
		}

		public override void OnUpdate(BloodContainer container)
		{
			CirculationBehaviour circulationBehaviour = container as CirculationBehaviour;
			if ((object)circulationBehaviour == null)
			{
				return;
			}
			string speciesIdentity = circulationBehaviour.Limb.SpeciesIdentity;
			if (speciesIdentity != null && speciesIdentity == "Android")
			{
				circulationBehaviour.Limb.BaseStrength = Mathf.Lerp(circulationBehaviour.Limb.BaseStrength, 18f, 0.5f);
				return;
			}
			if (circulationBehaviour.Limb.PhysicalBehaviour.Temperature < 40f)
			{
				circulationBehaviour.Limb.PhysicalBehaviour.Temperature += Random.value;
			}
			if (circulationBehaviour.Limb.RoughClassification == LimbBehaviour.BodyPart.Head)
			{
				if (Random.value > 0.995f)
				{
					circulationBehaviour.Limb.Damage(circulationBehaviour.Limb.Health + 1f);
				}
				if ((double)Random.value > 0.9)
				{
					circulationBehaviour.Limb.Person.AddPain(Random.value * 60f);
				}
				circulationBehaviour.Limb.Person.Consciousness *= 0.99f;
			}
		}
	}
}
