using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Mod
{
    public class undeath : MonoBehaviour
    {
        public LimbBehaviour limb;
		const bool untrue = false;
		float oStrength;
		float oMass;
		Vector3 oScale;
		Vector3 oLScale;

    protected void Start()
        {
            limb = GetComponent<LimbBehaviour>();
			oScale = limb.gameObject.transform.parent.localScale;
			oLScale = limb.gameObject.transform.localScale;
			limb.PhysicalBehaviour.RecalculateMassBasedOnSize();
			oMass = limb.PhysicalBehaviour.InitialMass*1;
			limb.PhysicalBehaviour.rigidbody.mass = oMass;
			oStrength = 1f*(limb.PhysicalBehaviour.rigidbody.mass/limb.PhysicalBehaviour.TrueInitialMass);

        }

protected void Update()
	{
		limb.HealBone();
			limb.CirculationBehaviour.HealBleeding();
			limb.PhysicalBehaviour.BurnProgress = 0f;
            limb.SkinMaterialHandler.ClearAllDamage();
			limb.InitialHealth = float.MaxValue;
			limb.Health = float.PositiveInfinity;
			limb.RegenerationSpeed = float.PositiveInfinity;
			limb.IsLethalToBreak = false;
			limb.Numbness = float.NegativeInfinity;
			limb.CirculationBehaviour.AddLiquid(limb.GetOriginalBloodType(), float.PositiveInfinity);
			limb.CirculationBehaviour.ForceSetAllLiquid(float.PositiveInfinity);
			limb.ExplodeLiquidAmount = float.PositiveInfinity;
			limb.Person.ShockLevel = 0f;
			limb.Person.PainLevel = 0f;
			limb.GetComponent<LimbBehaviour>().Frozen = false;
			limb.BreakingThreshold = float.PositiveInfinity;
			limb.ImmuneToDamage = true;
			limb.CirculationBehaviour.ImmuneToDamage = true;
			limb.IsDismembered = false;
			limb.PhysicalBehaviour.Charge = 0f;
			limb.Person.AdrenalineLevel = float.PositiveInfinity;
			limb.BruiseCount = (ushort)0;
			limb.CirculationBehaviour.GunshotWoundCount = (ushort)0;
			limb.CirculationBehaviour.StabWoundCount = (ushort)0;
			limb.BloodDecal = null;
			limb.PhysicalBehaviour.Disintegratable = false;
			limb.PhysicalBehaviour.ChargeBurns = false;
			limb.Person.Consciousness = float.PositiveInfinity;
			limb.Person.OxygenLevel = float.PositiveInfinity;
			limb.PhysicalBehaviour.SimulateTemperature = false;
			limb.Wince(0f);
			limb.Vitality = 50f;
			limb.CirculationBehaviour.IsPump = limb.CirculationBehaviour.WasInitiallyPumping;
			limb.CirculationBehaviour.BloodFlow = 100f;
			limb.DoStumble = true;
			limb.DoBalanceJerk = true;
			limb.BodyTemperature = 37f;
			limb.PhysicalBehaviour.Properties.Flammability = 0f;
			limb.gameObject.GetComponent<PhysicalBehaviour>().Temperature = 37f;
			Component[] components = limb.gameObject.GetComponents(typeof(Component));
			foreach(Component component in components)
			{
				if(component != GetComponent<undeath>() & component != GetComponent<Transform>() & component != GetComponent<SpriteRenderer>() & component != GetComponent<BoxCollider2D>() & component != GetComponent<Rigidbody2D>() & component != GetComponent<PhysicalBehaviour>() & component != GetComponent<LimbBehaviour>() & component != GetComponent<HingeJoint2D>() & component != GetComponent<SkinMaterialHandler>() & component != GetComponent<CirculationBehaviour>() & component != GetComponent<ShotMessagePropagator>() & component != GetComponent<ContextMenuOptionComponent>() & component != GetComponent<AudioSource>() & component != GetComponent<SerialisableIdentity>() & component != GetComponent<GripBehaviour>() & component != GetComponent<FixedJoint2D>())
				{

				}
			}
	}

 protected void FixedUpdate()
	{
		limb.PhysicalBehaviour.Wetness = Mathf.Clamp(limb.PhysicalBehaviour.Wetness,0f,0f);
	}
protected void OnDestroy()
	{
			limb.gameObject.AddComponent<undeath>();
	}
protected void OnDisable()
	{
		this.gameObject.SetActive(true);
		GetComponent<undeath>().enabled = true;
	}
    }
}
