using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mod
{
    public class Releaseryuo : CanShoot
    {

        private GameObject Ruka;
        private PhysicalBehaviour physicalBehaviour;
        private GameObject RukaGlow;
        private Vector2 barrelPosition = new Vector2(0f, -0.3f);
        private Vector2 barrelDirection = new Vector2(0, -1);
        public bool upgraded = false;
        private LineRenderer laser;
        private LayerMask layers;
        private LayerMask bounds;
        private GameObject components;



        private RaycastHit2D[] victimBuffer = new RaycastHit2D[128];



        public void Start()
        {

            Ruka = gameObject;
            physicalBehaviour = GetComponent<PhysicalBehaviour>();

            layers = LayerMask.GetMask("Objects", "CollidingDebris", "Bounds");
            bounds = LayerMask.GetMask("Bounds");

            components = new GameObject("components", typeof(Optout));
            components.transform.SetParent(transform);
            components.transform.localPosition = new Vector3(0f, -0.3f);
            laser = components.AddComponent<LineRenderer>();
            laser.SetPositions(new[] { Vector3.zero, Vector3.right * 1500 });
            laser.useWorldSpace = false;
            laser.sharedMaterial = ModAPI.FindMaterial("VeryBright");
            laser.sortingLayerName = "Background";
            laser.startColor = new Color(1f, 0f, 0f, 1f);
            laser.endColor = new Color(1f, 1f, 0f, 1f);
            laser.widthMultiplier = 0f;
            laser.enabled = false;

            RukaGlow = new GameObject();
            RukaGlow.transform.parent = Ruka.transform;
            RukaGlow.transform.localPosition = new Vector3(0f, -0.13f);
            RukaGlow.transform.localScale = gameObject.transform.parent.localScale;
            RukaGlow.transform.localRotation = Quaternion.identity;
            var RukaSprite = RukaGlow.AddComponent<SpriteRenderer>();

            RukaSprite.sprite = ModAPI.LoadSprite("");
            RukaSprite.material = ModAPI.FindMaterial("VeryBright");
            RukaSprite.color = new Color(1f, 1f, 1f, 0f);
            RukaSprite.sortingLayerName = "Top";


        }
        private void Use()
        {
            Shoot();
        }


        public override void Shoot()
        {

                StartCoroutine(Fire());
        }




        private IEnumerator Fire()
        {
            const int iterations = 1;
            const float duration = 0.1f;

            const float interval = duration / iterations;

            laser.startColor = new Color(0f, 0f, 0f, 1f);
            laser.endColor = new Color(0f, 0f, 0f, 1f);
            laser.widthMultiplier = 0f;



            laser.enabled = true;
            for (int i = 0; i < iterations; i++)
            {
                var end = Physics2D.Raycast(BarrelPosition, BarrelDirection,1500, bounds);
                var endPos = end.transform == null ? (Vector3)BarrelPosition + (Vector3)BarrelDirection * 1500 : (Vector3)end.point;
                var victimCount = Physics2D.LinecastNonAlloc(BarrelPosition, endPos, victimBuffer, layers);
                laser.SetPosition(1, components.transform.InverseTransformPoint(endPos));

                for (int n = 0; n < victimCount; n++)
                {
                    var victim = victimBuffer[n];
ExplosionCreator.CreatePulseExplosion(victim.point, 3f, 1, true);
victim.transform.SendMessage("Disintegration", SendMessageOptions.DontRequireReceiver);
victim.transform.SendMessage("Slice", SendMessageOptions.DontRequireReceiver);
                    // phys.rigidbody.AddForceAtPosition(forward * DirectionalForce * phys.rigidbody.mass, hit.point, ForceMode2D.Impulse);
                }


                physicalBehaviour.rigidbody.AddRelativeForce(new Vector2(0f * transform.localScale.normalized.y, 0), ForceMode2D.Impulse);
                yield return new WaitForSeconds(interval);
            }
            laser.enabled = false;
            yield return new WaitForSeconds(2f);
        }










        public override Vector2 BarrelPosition { get { return transform.TransformPoint(barrelPosition); } }

        public Vector2 BarrelDirection { get { return transform.TransformDirection(barrelDirection) * transform.localScale.x; } }


    }
}
