using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace  Mod
{
    public class strongrege : MonoBehaviour
    {
      LimbBehaviour Limb;
      Liquid blood1;

      private void Awake()
      {
          Limb = gameObject.GetComponent<LimbBehaviour>();
          blood1 = Limb.GetOriginalBloodType();
          Limb.IsLethalToBreak = false;
          Limb.ImpactPainMultiplier = 0.00001f;
          Limb.ShotDamageMultiplier = 0.00001f;
      }

      private void Update()
      {
        Limb.HealBone();
    		Limb.CirculationBehaviour.HealBleeding();
        Limb.SkinMaterialHandler.ClearAllDamage();
        Limb.Person.Consciousness = float.PositiveInfinity;
        Limb.Person.OxygenLevel = float.PositiveInfinity;
        Limb.Person.ShockLevel = 0f;
        Limb.Person.PainLevel = 0f;
        Limb.ImpactPainMultiplier *= 0f;
        Limb.PhysicalBehaviour.BurnProgress = 0f;
        Limb.BodyTemperature = 37f;
        Limb.PhysicalBehaviour.Wetness = Mathf.Clamp(Limb.PhysicalBehaviour.Wetness,0f,0.2f);
        Limb.PhysicalBehaviour.Properties.Flammability = 0f;
        Limb.PhysicalBehaviour.Charge = 0f;
        Limb.gameObject.GetComponent<PhysicalBehaviour>().Temperature = 37f;
      }

      public void Nullificator()
      {
          Destroy(this);
      }

      public void Nullificatr()
      {
          Destroy(this);
      }
  }
}
