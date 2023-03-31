using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mod
{
    public class yominomi : MonoBehaviour
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

            handSprite.sprite = powersprites.yomicon;
            handSprite.material = ModAPI.FindMaterial("VeryBright");
            handSprite.color = new Color(051f, 255f, 0f, 0.001f);
            handSprite.sortingLayerName = "Decals";

        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            var rb = hand.GetComponent<Rigidbody2D>();
            if (Activated)

            {
              other.gameObject.GetComponent<LimbBehaviour>().Damage(100f);
              other.gameObject.GetComponent<PhysicalBehaviour>().Temperature = -30f;
              other.gameObject.GetComponent<LimbBehaviour>().IsZombie = true;
              var particle = ModAPI.CreateParticleEffect("Vapor", new Vector2(hand.transform.position.x, hand.transform.position.y + 0.1f));
              var Colder = particle.GetComponent<ParticleSystem>().main;
              Colder.startColor = Color.green;

            }

        }

        public void FixedUpdate()
        {

            if(hand.GetComponent<Rigidbody2D>().velocity.magnitude >= 0f)
            if (Activated)
            {

                handGlow.GetComponent<SpriteRenderer>().color = new Color(0f, 255f, 0f, Mathf.Clamp(gameObject.GetComponent<Rigidbody2D>().velocity.magnitude / 0.0099f, 0.0099f, 0.0099f));
            }
            else
            {

                handGlow.GetComponent<SpriteRenderer>().color = new Color(0f, 255f, 0f, 0f);
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
