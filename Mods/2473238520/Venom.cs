using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mod
{
    public class Venom : MonoBehaviour
    {

        private GameObject Ruka;

        private GameObject RukaGlow;
        public Boolean Nullified = false;

        public void Awake()
        {
            Ruka = gameObject;

            RukaGlow = new GameObject();
            RukaGlow.transform.parent = Ruka.transform;
            RukaGlow.transform.localPosition = new Vector3(0f, 0f);
            RukaGlow.transform.localScale = gameObject.transform.parent.localScale;

            var RukaSprite = RukaGlow.AddComponent<SpriteRenderer>();

            RukaSprite.sprite = ModAPI.LoadSprite("Fragments/Snejinka.png", 40f);
            RukaSprite.material = ModAPI.FindMaterial("VeryBright");
            RukaSprite.color = new Color(0f, 255f, 255f, 0f);
            RukaSprite.sortingLayerName = "Top";
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            var rb = Ruka.GetComponent<Rigidbody2D>();

            if (Nullified == false)
            {
                if (Ruka.GetComponent<Rigidbody2D>().velocity.magnitude >= 3f)
                {

                    other.gameObject.GetComponent<LimbBehaviour>().Frozen = true;
                    other.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(255f, 0f, 255f, 1f);
                    other.gameObject.GetComponent<LimbBehaviour>().SkinMaterialHandler.AcidProgress += 0.2f;
                    other.gameObject.GetComponent<LimbBehaviour>().CirculationBehaviour.AddLiquid(Liquid.GetLiquid("ACID"), 1f);
                }

            }

        }

        public void FixedUpdate()
        {
            if (Nullified == false)
            {
                if (Ruka.GetComponent<Rigidbody2D>().velocity.magnitude >= 3f)
                {
                    RukaGlow.GetComponent<SpriteRenderer>().color = new Color(0f, 255f, 255f, Mathf.Clamp(gameObject.GetComponent<Rigidbody2D>().velocity.magnitude / 250f, 0f, 1f));
                }
                else
                {
                    RukaGlow.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0f, 0f);
                }
            }

        }
    }
}
