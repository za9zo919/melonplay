using System;
using UnityEngine;

namespace Mod
{
    public class ice2 : MonoBehaviour
    {
        private Vector2 barrelPosition = new Vector2(0f, -0.275f);
        private Vector2 barrelDirection = Vector2.down;

        private LayerMask layers;
        private LayerMask bounds;

        RaycastHit2D ray;
        AudioSource audio;
        public float power = 3000f;

        LineRenderer line;
        public void Awake()
        {
            layers = LayerMask.GetMask("Objects", "CollidingDebris", "Bounds");
            bounds = LayerMask.GetMask("Bounds");

            line = gameObject.AddComponent<LineRenderer>();
            line.material = ModAPI.FindMaterial("VeryBright");
            line.numCapVertices = 1;
            line.startColor = new Color(1f, 1f, 1.1f, 1f);
            line.endColor = new Color(1f, 1f, 1.1f, 1f);
            line.startWidth = 0.15f;
            line.endWidth = 0.15f;
            line.rendererPriority = 5;
        }

        public void Shoot()
        {
            line.startColor = new Color(1f, 1f, 1.1f, 1f);
            line.endColor = new Color(1f, 1f, 1.1f, 1f);
            line.startWidth = 0.15f;
            line.endWidth = 0.15f;

            if (ray.collider.gameObject.layer == 9)
            {
                  ray.transform.GetComponent<PhysicalBehaviour>().Temperature = -10000f;
                float mass = 0f;
                for (int i = 0; i < ray.collider.transform.root.GetComponentsInChildren<Rigidbody2D>().Length; i++)
                {
                    mass += ray.collider.transform.root.GetComponentsInChildren<Rigidbody2D>()[i].mass;
                }

                ray.collider.GetComponent<Rigidbody2D>().AddForceAtPosition((((BarrelPosition - ray.point).normalized * (power * mass)) * Time.deltaTime) * -0.02f, ray.point);
            }
        }

        void Update()
        {
            ray = Physics2D.Raycast(BarrelPosition, BarrelDirection, Mathf.Infinity);
            line.SetPosition(0, BarrelPosition);
            line.SetPosition(1, ray.point);
            line.startWidth = Mathf.MoveTowards(line.startWidth, 0f, Time.deltaTime);
            line.endWidth = Mathf.MoveTowards(line.endWidth, 0f, Time.deltaTime);
        }

        void UseContinuous()
        {
            Shoot();
        }

        public  Vector2 BarrelPosition { get { return transform.TransformPoint(barrelPosition); } }
        public Vector2 BarrelDirection { get { return transform.TransformDirection(barrelDirection) * transform.localScale.x; } }
    }
}
