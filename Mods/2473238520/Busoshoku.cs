using UnityEngine;

namespace Mod
{
    public class Busoshoku : MonoBehaviour
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
            handSprite.sortingLayerName = "Top";
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            var rb = hand.GetComponent<Rigidbody2D>();
            if(rb.velocity.magnitude >= 10f)
            {
                other.gameObject.GetComponent<Rigidbody2D>().velocity = rb.velocity * 0;
                var particle = ModAPI.CreateParticleEffect("Vapor", new Vector2(hand.transform.position.x, hand.transform.position.y + 0.1f));
                other.gameObject.SendMessage("Nullificator", SendMessageOptions.DontRequireReceiver);

                var Colder = particle.GetComponent<ParticleSystem>().main;
                Colder.startColor = Color.green;
            }
            else
            {
                other.gameObject.GetComponent<Rigidbody2D>().velocity = rb.velocity * 0;
                other.gameObject.SendMessage("Nullificator", SendMessageOptions.DontRequireReceiver);
            }
        }

    }
}
