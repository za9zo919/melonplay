using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mod
{
    public class python2 : MonoBehaviour
    {
        GameObject spr;
        public float Speed = 160;
        public float ImpactStrength = 2000;
        public float Damage = 50000;
        public float Range = 10000000000;

        private RaycastHit2D hit;
        private PhysicalBehaviour hitPhys;

        private RaycastHit2D[] buffer = new RaycastHit2D[16];
        private LayerMask layerMask;

        private void Start()
        {
            spr = gameObject;
            spr.AddComponent<SpriteRenderer>();
            spr.GetComponent<SpriteRenderer>().sprite = powersprites.py;
            spr.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            spr.GetComponent<SpriteRenderer>().sharedMaterial = ModAPI.FindMaterial("Sprites-Default");
            layerMask = LayerMask.GetMask("Bounds", "Objects", "CollidingDebris");
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
                ModAPI.CreateParticleEffect("Vapor", transform.position).transform.up = up;
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
