using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

namespace Mod
{
    public class kenbun : MonoBehaviour
    {

      public bool Activated = false;
      bool IsUsable = true;

        private GameObject hand;

        private GameObject handGlow;

        public void Awake()
        {
            hand = gameObject;

            BoxCollider2D bc;
            bc = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
            bc.size = new Vector2(30f, 30f);
            bc.isTrigger = true;
            bc.transform.parent = hand.transform;

            handGlow = new GameObject();
            handGlow.transform.parent = hand.transform;
            handGlow.transform.localPosition = new Vector3(0f, -0.09f);
            handGlow.transform.localScale = gameObject.transform.parent.localScale;

            var handSprite = handGlow.AddComponent<SpriteRenderer>();

            handSprite.sprite = ModAPI.LoadSprite("");
            handSprite.material = ModAPI.FindMaterial("Sprites-Default");
            handSprite.color = new Color(1f, 1f, 1f, 0f);
            handSprite.sortingLayerName = "Bottom";
        }

        public void OnTriggerStay2D(Collider2D other)
        {
          if (Activated)
          other.gameObject.GetComponent<Rigidbody2D>().velocity *= 0.5f;
        }

        public void FixedUpdate()
        {
            if (Activated)
            {
              var effect = ModAPI.CreateParticleEffect("Vapor", new Vector2(this.transform.position.x, this.transform.position.y));
              var main = effect.GetComponent<ParticleSystem>().main;main.startColor = new Color(0/255f, 255/255f, 255/255f);
              effect.transform.root.localScale *= 1f;
                handGlow.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, Mathf.Clamp(gameObject.GetComponent<Rigidbody2D>().velocity.magnitude / 1f, 1f, 1f));
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
