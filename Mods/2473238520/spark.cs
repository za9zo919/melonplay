using UnityEngine;

namespace Mod
{
    public class spark : MonoBehaviour
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
            handSprite.color = new Color(0f, 0.5f, 1f, 1f);
            handSprite.sortingLayerName = "Top";
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            var rb = hand.GetComponent<Rigidbody2D>();
            if(rb.velocity.magnitude >= -1000000000f)
            {
                other.gameObject.GetComponent<Rigidbody2D>().velocity = rb.velocity * 0;
                other.gameObject.GetComponent<PhysicalBehaviour>().charge += 1f;
                other.gameObject.GetComponent<PhysicalBehaviour>().charge += 1f;
                ModAPI.CreateParticleEffect("Spark", new Vector2(hand.transform.position.x, hand.transform.position.y + -0.5f));
            }
            else
            {
                other.gameObject.GetComponent<Rigidbody2D>().velocity = rb.velocity * 0;
            }
        }

        public void FixedUpdate()
        {
            if(hand.GetComponent<Rigidbody2D>().velocity.magnitude >= -1000000000f)
            {
                handGlow.GetComponent<SpriteRenderer>().color = new Color(0f, 0.5f, 1f, Mathf.Clamp(gameObject.GetComponent<Rigidbody2D>().velocity.magnitude / 1f, 0f, 1f));
            }
            else
            {
                handGlow.GetComponent<SpriteRenderer>().color = new Color(0f, 0.5f, 1f, 1f);
            }
        }
    }
}
