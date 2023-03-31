using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Mod
{
    public class regene : MonoBehaviour
    {
        public LimbBehaviour limb;
        bool boo = false;
        public Boolean Nullified = false;
        public int power = 0;

        public void Start()
        {
            limb = GetComponent<LimbBehaviour>();
            PhysicalBehaviour physicalBehaviour = limb.PhysicalBehaviour;
            StartCoroutine(lechenie(limb));
        }

        private IEnumerator lechenie(LimbBehaviour limb)
        {
            while (Nullified == false)
            {
                limb.HealBone();
                limb.Health = limb.InitialHealth * 100f;
                limb.Numbness = 0f;
                limb.CirculationBehaviour.HealBleeding();
                limb.CirculationBehaviour.IsPump = limb.CirculationBehaviour.WasInitiallyPumping;
                limb.CirculationBehaviour.BloodFlow = 60f;
                limb.CirculationBehaviour.BloodAmount = 60f;
                limb.BruiseCount = (ushort)0;
                limb.CirculationBehaviour.GunshotWoundCount = (ushort)0;
                limb.CirculationBehaviour.StabWoundCount = (ushort)0;
                StartCoroutine(naxuiogon(limb));
                limb.Person.Consciousness = 1f;
                limb.Person.OxygenLevel = 1f;
                limb.Person.AdrenalineLevel = 0f;
                limb.Person.ShockLevel = 0f;
                StartCoroutine(naxuirani(limb));
                StartCoroutine(naxuignoi(limb));
                StartCoroutine(naxuikisloty(limb));
                yield return new WaitForSeconds(2f);
            }
        }

        private IEnumerator naxuirani(LimbBehaviour limb)
        {
            while (limb.SkinMaterialHandler.damagePoints.Max(c => c.z) > 0.1f)
            {
                for (int index = 0; index < limb.SkinMaterialHandler.damagePoints.Length; ++index)
                    limb.SkinMaterialHandler.damagePoints[index].z -= Time.deltaTime * 0.4f;
                limb.SkinMaterialHandler.Sync();
                yield return new WaitForEndOfFrame();
            }
        }

        private IEnumerator naxuiogon(LimbBehaviour limb)
        {
            while (limb.PhysicalBehaviour.BurnProgress > 0.1f)
            {
                limb.PhysicalBehaviour.BurnProgress -= Time.deltaTime * 0.4f;
                yield return new WaitForEndOfFrame();
            }
            limb.PhysicalBehaviour.BurnProgress = 0.0f;
        }

        private IEnumerator naxuikisloty(LimbBehaviour limb)
        {
            while (limb.SkinMaterialHandler.AcidProgress > 0.1f)
            {
                limb.SkinMaterialHandler.AcidProgress -= Time.deltaTime * 0.4f;
                yield return new WaitForEndOfFrame();
            }
            limb.SkinMaterialHandler.AcidProgress = 0.0f;
        }

        private IEnumerator naxuignoi(LimbBehaviour limb)
        {
            while (limb.SkinMaterialHandler.RottenProgress > 0.1f)
            {
                limb.SkinMaterialHandler.RottenProgress -= Time.deltaTime * 0.4f;
                yield return new WaitForEndOfFrame();
            }
            limb.SkinMaterialHandler.RottenProgress = 0.0f;
        }
    }
}
