using UnityEngine;

namespace Mod
{
    public class gravity : MonoBehaviour
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
            if(rb.velocity.magnitude >= -100000f)
            {
                  other.gameObject.GetComponent<PhysicalBehaviour>().rigidbody.gravityScale = 5f;
                other.gameObject.GetComponent<Rigidbody2D>().velocity = rb.velocity * 2;

            }
            else
            {
                other.gameObject.GetComponent<Rigidbody2D>().velocity = rb.velocity * 2;
            }
        }

        public void FixedUpdate()
        {
            if(hand.GetComponent<Rigidbody2D>().velocity.magnitude >= -100000f)
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
