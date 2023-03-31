using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace  Mod
{
    public class luffyrege : MonoBehaviour
    {
        public LimbBehaviour limb;

        Liquid blood1;
        private GameObject Ruka;
        private float hpchela;

        public int power = 0;
        public float time = 1;
        public bool spec = false;

        public void Start()
        {
            Ruka = gameObject;
            limb = GetComponent<LimbBehaviour>();
            blood1 = limb.GetOriginalBloodType();

            PhysicalBehaviour physicalBehaviour = limb.PhysicalBehaviour;

            if (spec == false)
            {
                StartCoroutine(lechenie(limb));
            }
            else
            {
                StartCoroutine(noSleep(limb));

            }






        }

        protected void Update()
        	{
            limb.PhysicalBehaviour.Charge = 0f;
            limb.ImmuneToDamage = true;
            limb.Person.ShockLevel = 0f;
            limb.Person.PainLevel = 0f;
            limb.ImpactPainMultiplier *= 0f;
            limb.SkinMaterialHandler.ClearAllDamage();
            limb.PhysicalBehaviour.Wetness = Mathf.Clamp(limb.PhysicalBehaviour.Wetness,0f,0.2f);
            limb.PhysicalBehaviour.BurnProgress = 0f;
            limb.PhysicalBehaviour.Properties.Flammability = 0f;
          }

        public void Nullificator()
        {
            Destroy(this);
        }


        private IEnumerator lechenie(LimbBehaviour limb)
        {


            while (true)
            {
                limb.HealBone();
                limb.Health = limb.InitialHealth * 20f;
                limb.Numbness = 0f;
                limb.CirculationBehaviour.HealBleeding();
                limb.CirculationBehaviour.IsPump = limb.CirculationBehaviour.WasInitiallyPumping;
                limb.CirculationBehaviour.BloodFlow = 30f;
                if(limb.CirculationBehaviour.GetAmount(blood1) <= 1f)
                {
                    limb.CirculationBehaviour.AddLiquid(blood1, 1f);
                }

                limb.BruiseCount = (ushort)0;
                limb.CirculationBehaviour.GunshotWoundCount = (ushort)0;
                limb.CirculationBehaviour.StabWoundCount = (ushort)0;
                limb.Person.ShockLevel = 0f;
                limb.Person.Consciousness = 1f;
                limb.Person.OxygenLevel = 1f;

                limb.Person.AdrenalineLevel = 0f;
                StartCoroutine(naxuipuli(limb));
                StartCoroutine(naxuirani(limb));
                StartCoroutine(naxuiogon(limb));
                StartCoroutine(naxuignoi(limb));
                StartCoroutine(naxuikisloty(limb));


                yield return new WaitForSeconds(time);
            }






        }

        public IEnumerator noSleep(LimbBehaviour limb)
        {
            while (true)
            {
                limb.Person.AdrenalineLevel = 0f;
                limb.Person.ShockLevel = 0f;
                yield return new WaitForSeconds(time);
            }
        }



        private IEnumerator naxuirani(LimbBehaviour limb)
        {
            while ((double)((IEnumerable<Vector4>)limb.SkinMaterialHandler.damagePoints).Min<Vector4>((Func<Vector4, float>)(c => c.z)) < 50.0)
            {
                for (int index = 0; index < limb.SkinMaterialHandler.damagePoints.Length; ++index)
                    limb.SkinMaterialHandler.damagePoints[index].z += Time.deltaTime * 0.1f;
                limb.SkinMaterialHandler.Sync();
                yield return (object)new WaitForEndOfFrame();
            }
        }
        public void him()
        {
            StopCoroutine(lechenie(limb));
            StartCoroutine(noSleep(limb));
        }

        private IEnumerator naxuiogon(LimbBehaviour limb)
        {
            while ((double)limb.PhysicalBehaviour.BurnProgress > 0.100000001490116)
            {
                limb.PhysicalBehaviour.BurnProgress -= Time.deltaTime * 0.1f;
                yield return (object)new WaitForEndOfFrame();
            }
            limb.PhysicalBehaviour.BurnProgress = 0.0f;
        }

        private IEnumerator naxuikisloty(LimbBehaviour limb)
        {
            while ((double)limb.SkinMaterialHandler.AcidProgress > 0.100000001490116)
            {
                limb.SkinMaterialHandler.AcidProgress -= Time.deltaTime * 0.1f;
                yield return (object)new WaitForEndOfFrame();
            }
            limb.SkinMaterialHandler.AcidProgress = 0.0f;
        }

        private IEnumerator naxuignoi(LimbBehaviour limb)
        {
            while ((double)limb.SkinMaterialHandler.RottenProgress > 0.100000001490116)
            {
                limb.SkinMaterialHandler.RottenProgress -= Time.deltaTime * 0.1f;
                yield return (object)new WaitForEndOfFrame();
            }
            limb.SkinMaterialHandler.RottenProgress = 0.0f;
        }


        private IEnumerator naxuipuli(LimbBehaviour limb)
        {
            while ((double)((IEnumerable<Vector4>)limb.SkinMaterialHandler.bulletHolePoints).Min<Vector4>((Func<Vector4, float>)(c => c.z)) < 50.0)
            {
                for (int index = 0; index < limb.SkinMaterialHandler.bulletHolePoints.Length; ++index)
                {
                    limb.SkinMaterialHandler.bulletHolePoints[index].z = Mathf.Max(limb.SkinMaterialHandler.bulletHolePoints[index].z, 0.05f);
                    limb.SkinMaterialHandler.bulletHolePoints[index].z += Time.deltaTime * 0.1f;
                }
                limb.SkinMaterialHandler.Sync();
                yield return (object)new WaitForEndOfFrame();
            }
        }


    }




    public class fire : MonoBehaviour
    {

        public LimbBehaviour limb;


        public void Start()
        {
            limb = GetComponent<LimbBehaviour>();
            PhysicalBehaviour physicalBehaviour = limb.PhysicalBehaviour;
            StartCoroutine(lechenie(limb));



        }



        private IEnumerator lechenie(LimbBehaviour limb)
        {
            while (true)
            {
                limb.Person.Consciousness = 1f;
                limb.Person.OxygenLevel = 1f;
                limb.Person.AdrenalineLevel = 0f;
                limb.Person.ShockLevel = 0f;
                limb.Person.PainLevel = 0f;
                limb.PhysicalBehaviour.Temperature = 36f;
                StartCoroutine(naxuiogon(limb));
                yield return new WaitForEndOfFrame();
            }





        }

        private IEnumerator naxuiogon(LimbBehaviour limb)
        {
            while ((double)limb.PhysicalBehaviour.BurnProgress > 0.100000001490116)
            {
                limb.PhysicalBehaviour.BurnProgress -= Time.deltaTime * 0.1f;
                yield return (object)new WaitForEndOfFrame();
            }
            limb.PhysicalBehaviour.BurnProgress = 0.0f;
        }

        public void Nullificator()
        {
            Destroy(this);
        }


    }
}
