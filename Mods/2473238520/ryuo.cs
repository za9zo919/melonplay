using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mod
{
    public class ryuo : MonoBehaviour
    {

      public bool Activated = false;
      bool IsUsable = true;

        private GameObject hand;

        private GameObject handGlow;

        public void Awake()
        {
            hand = gameObject;
            handGlow = new GameObject();
            handGlow.transform.parent = hand.transform;
            handGlow.transform.localPosition = new Vector3(0f, -0.09f);
            handGlow.transform.localScale = gameObject.transform.parent.localScale;

            var handSprite = handGlow.AddComponent<SpriteRenderer>();

            handSprite.sprite = ModAPI.LoadSprite("");
            handSprite.material = ModAPI.FindMaterial("VeryBright");
            handSprite.color = new Color(051f, 255f, 255f, 0.001f);
            handSprite.sortingLayerName = "Top";

        }

        public void OnCollisionEnter2D(Collision2D other)
        {

            if (Activated)

            {

              var effect = ModAPI.CreateParticleEffect("Vapor", new Vector2(this.transform.position.x, this.transform.position.y));
              var main = effect.GetComponent<ParticleSystem>().main;main.startColor = new Color(255/255f, 153/255f, 0/255f);
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

              other.gameObject.GetComponent<LimbBehaviour>().SendMessage("OnEMPHit", SendMessageOptions.DontRequireReceiver);

              var particle = ModAPI.CreateParticleEffect("Ricochet", new Vector2(hand.transform.position.x, hand.transform.position.y + 0.1f));
              other.gameObject.SendMessage("Nullificator", SendMessageOptions.DontRequireReceiver);
              var Colder = particle.GetComponent<ParticleSystem>().main;
              Colder.startColor = new Color(255/255f, 153/255f, 0/255f);
            }

        }

        public void FixedUpdate()
        {

          
            if (Activated)
            {
              var effect = ModAPI.CreateParticleEffect("Vapor", new Vector2(this.transform.position.x, this.transform.position.y));
              var main = effect.GetComponent<ParticleSystem>().main;main.startColor = new Color(255/255f, 153/255f, 0/255f);
                handGlow.GetComponent<SpriteRenderer>().color = new Color(5f, 5f, 5f, Mathf.Clamp(gameObject.GetComponent<Rigidbody2D>().velocity.magnitude / 0.0099f, 0.0099f, 0.0099f));
            }
            else
            {

                handGlow.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
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
