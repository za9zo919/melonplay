using UnityEngine;

namespace Mod
{
    public class eqp : MonoBehaviour
    {

        private GameObject hand;

        private GameObject handGlow;

        public void Awake()
        {
            hand = gameObject;

            handGlow = new GameObject();
            handGlow.transform.parent = hand.transform;
            handGlow.transform.localPosition = new Vector3(0f, 0f);
            handGlow.transform.localScale = gameObject.transform.parent.localScale;

            var handSprite = handGlow.AddComponent<SpriteRenderer>();

            handSprite.sprite = ModAPI.LoadSprite("");
            handSprite.material = ModAPI.FindMaterial("VeryBright");
            handSprite.color = new Color(0f, 0f, 0f, 0f);
            handSprite.sortingLayerName = "Top";
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            var rb = hand.GetComponent<Rigidbody2D>();
            if(rb.velocity.magnitude >= 5f)
            {
                other.gameObject.GetComponent<Rigidbody2D>().velocity = rb.velocity * 1;
                var particle = ModAPI.CreateParticleEffect("Ricochet", new Vector2(hand.transform.position.x, hand.transform.position.y + 0.1f));
                var Colder = particle.GetComponent<ParticleSystem>().main;
                Colder.startColor = Color.red;

            }
            else
            {
                other.gameObject.GetComponent<Rigidbody2D>().velocity = rb.velocity * 1;
            }
        }

        public void FixedUpdate()
        {
            if(hand.GetComponent<Rigidbody2D>().velocity.magnitude >= 5f)
            {
                handGlow.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, Mathf.Clamp(gameObject.GetComponent<Rigidbody2D>().velocity.magnitude / 250f, 0f, 1f));
            }
            else
            {
                handGlow.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);
            }
        }
    }
}
