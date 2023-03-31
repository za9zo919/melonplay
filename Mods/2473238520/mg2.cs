using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mod
{
    public class mg2 : MonoBehaviour
    {
        GameObject spr;
        TrailRenderer trail;
        LayerMask layers;
        public float Speed = 65;
        public float ImpactStrength = 100;
        public float Damage = 150000;
        public float Range = 15000;

        private RaycastHit2D hit;
        private PhysicalBehaviour hitPhys;

        private RaycastHit2D[] buffer = new RaycastHit2D[16];
        private LayerMask layerMask;

        private void Start()
        {
            spr = gameObject;
            spr.AddComponent<SpriteRenderer>();
            spr.GetComponent<SpriteRenderer>().sprite = powersprites.pellet;
            spr.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f, 00000.1f);
            spr.GetComponent<SpriteRenderer>().sharedMaterial = ModAPI.FindMaterial("VeryBright");
            layerMask = LayerMask.GetMask("Bounds", "Objects", "CollidingDebris");
        }

        void Awake()
                {
                    trail = gameObject.AddComponent<TrailRenderer>();
                    trail.time = 0.10f;
                    trail.startWidth = 4f;
                    trail.endWidth = 0f;
                    trail.material = ModAPI.FindMaterial("VeryBright").ShallowClone();
                    trail.startColor = new Color(1f, 0f, 0f, 0.01f);
                    trail.endColor = Color.clear;
                    trail.numCapVertices = 12;

                    layers = LayerMask.GetMask("Objects", "Bounds", "Debris");

                    gameObject.SetLayer(9);
                }


        private void Update()
        {
            var translation = Speed * Time.deltaTime;
            Vector2 up = default(Vector2);
            if (CastRay(translation, out up))
            {
            }
            else
            {
                MonoBehaviour.Destroy(gameObject);
                ExplosionCreator.Explode(transform.position, 1);
                ModAPI.CreateParticleEffect("BigExplosion", transform.position).transform.up = up;
            }
        }




        private bool CastRay(float distance, out Vector2 normal)
        {
            normal = Vector2.up;
            var pos = transform.position;
            var end = pos + transform.right * distance;
            var hitCount = Physics2D.LinecastNonAlloc(pos, end, buffer);

            for (int i = 0; i < hitCount; i++)
            {
                var hit = buffer[i];

                normal = hit.normal;
                hit.transform.SendMessage("Slice");
                var hitEffect = ModAPI.CreateParticleEffect("Vapor", transform.position);
                hitEffect.transform.SetParent(hit.transform);
                hitEffect.transform.position = hit.point;

                if (hit.collider.attachedRigidbody)
                    hit.collider.attachedRigidbody.AddForceAtPosition(hit.normal * -ImpactStrength, hit.point);
            }

            transform.position = end;
            return hitCount == 0;
        }
    }
}
