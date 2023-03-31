using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mod
{
    public class GunBeh : CanShoot
    {

        private GameObject Ruka;
        private PhysicalBehaviour physicalBehaviour;
        private GameObject RukaGlow;
        private Vector2 barrelPosition = new Vector2(0f, 0f);
        private Vector2 barrelDirection = new Vector2(0, -1);
        public bool upgraded = false;
        private LineRenderer beam;
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
            components.transform.localPosition = new Vector3(0, 0);
            beam = components.AddComponent<LineRenderer>();
            beam.SetPositions(new[] { Vector3.zero, Vector3.right * 1000 });
            beam.useWorldSpace = false;
            beam.sharedMaterial = ModAPI.FindMaterial("VeryBright");
            beam.sortingLayerName = "Background";
            beam.startColor = Color.red;
            beam.endColor = Color.red;
            beam.widthMultiplier = 0.1f;
            beam.enabled = false;

            RukaGlow = new GameObject();
            RukaGlow.transform.parent = Ruka.transform;
            RukaGlow.transform.localPosition = new Vector3(0f, -0.13f);
            RukaGlow.transform.localScale = gameObject.transform.parent.localScale;
            RukaGlow.transform.localRotation = Quaternion.identity;
            var RukaSprite = RukaGlow.AddComponent<SpriteRenderer>();

            RukaSprite.sprite = ModAPI.LoadSprite("");
            RukaSprite.material = ModAPI.FindMaterial("VeryBright");
            RukaSprite.color = new Color(138f, 43f, 226f, 0.15f);
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

            beam.startColor = Color.yellow;
            beam.endColor = Color.yellow;
            beam.widthMultiplier = 0.1f;



            beam.enabled = true;
            for (int i = 0; i < iterations; i++)
            {
                var end = Physics2D.Raycast(BarrelPosition, BarrelDirection, 10000, bounds);
                var endPos = end.transform == null ? (Vector3)BarrelPosition + (Vector3)BarrelDirection * 10000 : (Vector3)end.point;
                var victimCount = Physics2D.LinecastNonAlloc(BarrelPosition, endPos, victimBuffer, layers);
                beam.SetPosition(1, components.transform.InverseTransformPoint(endPos));

                for (int n = 0; n < victimCount; n++)
                {
                    var victim = victimBuffer[n];
                    ExplosionCreator.CreatePulseExplosion(victim.point, 0.5f, 1, true);
                    victim.transform.SendMessage("Break", BarrelDirection, SendMessageOptions.DontRequireReceiver);
                    victim.transform.SendMessage("Slice", SendMessageOptions.DontRequireReceiver);
                    // phys.rigidbody.AddForceAtPosition(forward * DirectionalForce * phys.rigidbody.mass, hit.point, ForceMode2D.Impulse);
                }

                CameraShakeBehaviour.main.Shake(2, transform.position);
                physicalBehaviour.rigidbody.AddRelativeForce(new Vector2(-0.1f * transform.localScale.normalized.x, 0), ForceMode2D.Impulse);
                yield return new WaitForSeconds(interval);
            }
            beam.enabled = false;
            yield return new WaitForSeconds(2.8f);
        }










        public override Vector2 BarrelPosition { get { return transform.TransformPoint(barrelPosition); } }

        public Vector2 BarrelDirection { get { return transform.TransformDirection(barrelDirection) * transform.localScale.x; } }


    }
}
