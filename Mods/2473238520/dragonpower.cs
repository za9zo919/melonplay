﻿using System;
using UnityEngine;

namespace Mod
{
    public class dragonpower : MonoBehaviour
    {
        private Vector2 barrelPosition = new Vector2(0f, -0.275f);
        private Vector2 barrelDirection = Vector2.down;

        RaycastHit2D ray;
        AudioSource audio;
        public float power = 3000f;

        LineRenderer line;
        public void Awake()
        {
            line = gameObject.AddComponent<LineRenderer>();
            line.material = ModAPI.FindMaterial("VeryBright");
            line.numCapVertices = 2;
            line.startColor = new Color(0f, 0.2f, 1f, 0.25f);
            line.endColor = new Color(0f, 0.2f, 1f, 0.25f);
            line.startWidth = 0f;
            line.endWidth = 0f;
            line.rendererPriority = 5;
        }

        public void Shoot()
        {
            line.startColor = new Color(0f, 0.2f, 1f, 0.25f);
            line.endColor = new Color(0f, 0.2f, 1f, 0.25f);
            line.startWidth = 0f;
            line.endWidth = 0f;

            if (ray.collider.gameObject.layer == 9)
            {
                     ray.transform.SendMessage("Pull", SendMessageOptions.DontRequireReceiver);
                float mass = -30f;


                for (int i = 0; i < ray.collider.transform.root.GetComponentsInChildren<Rigidbody2D>().Length; i++)
                {
                    mass += ray.collider.transform.root.GetComponentsInChildren<Rigidbody2D>()[i].mass;
                }

                ray.collider.GetComponent<Rigidbody2D>().AddForceAtPosition((((BarrelPosition - ray.point).normalized * (power * mass)) * Time.deltaTime) * 0.1f, ray.point);
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
