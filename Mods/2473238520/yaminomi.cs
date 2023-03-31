using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mod
{
    public class yaminomi : MonoBehaviour
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

            handSprite.sprite = powersprites.bhole;
            handSprite.material = ModAPI.FindMaterial("Sprites-Default");
            handSprite.color = new Color(1f, 1f, 1f, 0f);
            handSprite.sortingLayerName = "Decals";

        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            var rb = hand.GetComponent<Rigidbody2D>();
            if (Activated)

            {

              var particle = ModAPI.CreateParticleEffect("Disintegration", new Vector2(hand.transform.position.x, hand.transform.position.y + 0.1f));
              other.gameObject.GetComponent<PhysicalBehaviour>().SendMessage("OnEMPHit", SendMessageOptions.DontRequireReceiver);
              other.gameObject.GetComponent<PhysicalBehaviour>().Disintegrate();
              var Colder = particle.GetComponent<ParticleSystem>().main;
              Colder.startColor = new Color(102/255f, 0/255f, 153/255f);
            }

        }

        public void FixedUpdate()
        {

            if(hand.GetComponent<Rigidbody2D>().velocity.magnitude >= 0f)
            if (Activated)
            {

                handGlow.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, Mathf.Clamp(gameObject.GetComponent<Rigidbody2D>().velocity.magnitude / 1f, 1f, 1f));
            }
            else
            {

                handGlow.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);
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
