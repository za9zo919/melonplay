﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mod
{
    public class Crush : MonoBehaviour
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

            RukaSprite.sprite = ModAPI.LoadSprite("image/magma.png", 54f);
            RukaSprite.material = ModAPI.FindMaterial("VeryBright");
            RukaSprite.color = new Color(255f, 200f, 0f, 0.001f);
            RukaSprite.sortingLayerName = "Top";
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            var rb = Ruka.GetComponent<Rigidbody2D>();
            if (Nullified == false)
            {
                if (Ruka.GetComponent<Rigidbody2D>().velocity.magnitude >= 2f & other.gameObject.GetComponent<LimbBehaviour>() != null)
                {
                  other.gameObject.GetComponent<Rigidbody2D>().velocity = rb.velocity * 2;
                  other.gameObject.GetComponent<LimbBehaviour>().BreakBone();
                  other.gameObject.GetComponent<LimbBehaviour>().Wince(30f);
                  other.gameObject.GetComponent<LimbBehaviour>().BreakingThreshold = 0f;
                }

            }

        }

        public void FixedUpdate()
        {
            if(Nullified == false)
            {
                if (Ruka.GetComponent<Rigidbody2D>().velocity.magnitude >= 0f)
                {
                    RukaGlow.GetComponent<SpriteRenderer>().color = new Color(0.88f, 0.34f, 0.13f, Mathf.Clamp(gameObject.GetComponent<Rigidbody2D>().velocity.magnitude / 250f, 0f, 1f));
                }
                else
                {
                    RukaGlow.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 0f);
                }
            }

        }
    }
}
