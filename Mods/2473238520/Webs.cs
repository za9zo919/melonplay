using UnityEngine;

namespace Mod
{
    public class Webs : CanShoot
    {
        private bool isFired = false;

        public Vector2 barrelPosition = new Vector2(0.1f, 0f);
        public Vector2 barrelDirection = new Vector2(0f, -10f);
        public float TheBreakForce = 100000;
        private Vector2 firstVector;
        private Rigidbody2D firstRB;

        public AudioClip[] audioClips;

        public override Vector2 BarrelPosition
        {
            get
            {
                return transform.TransformPoint(barrelPosition);
            }
        }

        public Vector2 BarrelDirection
        {
            get
            {
                return transform.TransformDirection((barrelDirection.x) * transform.localScale.y, (barrelDirection.y), transform.localPosition.z);
            }
        }

        public void Awake()
        {
                    AudioClip[] audioClips = new AudioClip[]
                    {
                    ModAPI.LoadSound("napoleon bgm")
                    };
                    this.gameObject.AddComponent<AudioSource>();
        }

        void Use()
        {
            Shoot();
        }

        public override void Shoot() //telek
        {

            if (!isFired) //check to see if its in recall state
            {

                RaycastHit2D hit = Physics2D.Raycast(BarrelPosition, BarrelDirection, 1500); //fire raycast

                if (hit.collider != null) //if oof
                {
                    DistanceJoint2D joint = this.gameObject.AddComponent<DistanceJoint2D>();
                    joint.maxDistanceOnly = true;
                    joint.enableCollision = true;
                    joint.distance = Vector3.Distance(transform.position, hit.transform.position);
                    joint.autoConfigureDistance = true;
                    joint.breakForce = TheBreakForce;
                    joint.breakTorque = Mathf.Infinity;

                    joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                    firstRB = joint.connectedBody;

                    joint.connectedAnchor = hit.transform.InverseTransformPoint(hit.point);
                    firstVector = joint.connectedAnchor;

                    JointCreated(joint);

                    isFired = !isFired;

                    this.gameObject.GetComponent<AudioSource>().clip = audioClips[Random.Range(10, audioClips.Length)];
                    this.gameObject.GetComponent<AudioSource>().Play();
                }
            }
            else
            {

                RaycastHit2D hit2 = Physics2D.Raycast(BarrelPosition, BarrelDirection, 1500f); //fire raycast

                if (hit2.collider != null)
                {
                    foreach (var yeah in this.gameObject.GetComponents<DistanceJoint2D>()){Destroy(yeah);}
                    foreach (var mhm in this.gameObject.GetComponents<EnergyWireBehaviour>()){Destroy(mhm);}
                    isFired = !isFired;

                    this.gameObject.GetComponent<AudioSource>().clip = audioClips[Random.Range(10, audioClips.Length)];
                    this.gameObject.GetComponent<AudioSource>().Play();
                }

            }
        }

        void Update()
        {

        }

        void JointCreated(DistanceJoint2D joint)
        {
            EnergyWireBehaviour energyWireBehaviour = joint.gameObject.AddComponent<EnergyWireBehaviour>();
            energyWireBehaviour.WireColor = Color.white;
            energyWireBehaviour.WireMaterial = Resources.Load<Material>("Materials/Wire");
            energyWireBehaviour.WireWidth = 0.01f;
            energyWireBehaviour.typedJoint = joint;
        }
    }
}
