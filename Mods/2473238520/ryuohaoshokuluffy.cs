using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mod
{
    public class ryuohaoshokuluffy : MonoBehaviour
    {

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

            {

              var dr = other.gameObject.GetComponent<LimbBehaviour>();


              if (Ruka.GetComponent<Rigidbody2D>().velocity.magnitude >= 2f)
              {
                  dr.Health = 0f;
              }

              Vector3 position = transform.position;
              float force = 0.1f * (1 * other.relativeVelocity.magnitude);
              float oMass = 10000000f;
              float range = 1;
              bool breakObjects = true;
              CameraShakeBehaviour.main.Shake((float)((double)force * (double)range * 1.0), (Vector2)position);
              Vector2 point = (Vector2)position;
              double num1 = (double)range;
              int mask = LayerMask.GetMask("Objects");
              foreach (Collider2D collider2D in Physics2D.OverlapCircleAll(point, (float)num1, mask))
              {
              if ((bool)(UnityEngine.Object)collider2D.attachedRigidbody && !(collider2D.GetComponent<LimbBehaviour>() && GetComponent<LimbBehaviour>().Person.Limbs.Contains(collider2D.GetComponent<LimbBehaviour>())))
              {
                Vector3 vector3 = collider2D.transform.position - position;
                float num2 = (float)((-(double)vector3.magnitude + (double)range) * ((double)force / (double)range));
                if (breakObjects && (double)UnityEngine.Random.Range(1000000, 1000000) > (double)force)
                    collider2D.BroadcastMessage("Break", (object)(Vector2)(vector3 * num2 * 10000f), SendMessageOptions.DontRequireReceiver);
                collider2D.attachedRigidbody.AddForce((Vector2)(num2 * vector3.normalized), ForceMode2D.Impulse);
              }
              }

              foreach (var item in GetComponent<LimbBehaviour>().Person.Limbs)
              {
              item.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
              //        item.gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, new Color(1f, 0, 0.5156803f), KineticBuild / 200);
              }

              var particle = ModAPI.CreateParticleEffect("Ricochet", new Vector2(Ruka.transform.position.x, Ruka.transform.position.y + 0.1f));
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
    }
}
