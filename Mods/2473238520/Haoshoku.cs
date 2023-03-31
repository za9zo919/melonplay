using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mod
{
    public class Haoshoku : MonoBehaviour
    {

      public bool Activated = false;
      bool IsUsable = true;

        private GameObject Ruka;

        float oMass;

        private GameObject RukaGlow;



        public void Awake()
        {
            Ruka = gameObject;

            RukaGlow = new GameObject();
            RukaGlow.transform.parent = Ruka.transform;
            RukaGlow.transform.localPosition = new Vector3(0f, 0f);
            RukaGlow.transform.localScale = gameObject.transform.parent.localScale;


        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            var rb = Ruka.GetComponent<Rigidbody2D>();
            if (Activated)
            {
              var dr = other.gameObject.GetComponent<LimbBehaviour>();
              if (Ruka.GetComponent<Rigidbody2D>().velocity.magnitude >= 2f)
              {
                
              }
              
              dr.gameObject.SendMessage("Nullificator", SendMessageOptions.DontRequireReceiver);
              other.gameObject.GetComponent<Rigidbody2D>().velocity = rb.velocity * 0;
              var particle = ModAPI.CreateParticleEffect("Vapor", new Vector2(Ruka.transform.position.x, Ruka.transform.position.y + 0.1f));
              other.gameObject.SendMessage("Nullificator", SendMessageOptions.DontRequireReceiver);
              var Colder = particle.GetComponent<ParticleSystem>().main;
              Colder.startColor = Color.red;



            }

        }

        public void FixedUpdate()
        {


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

        private void Use()
        {
            SetActivated(!Activated);
        }

        private void SetActivated(bool a)
        {
        Activated = a;
         }
    }
}
