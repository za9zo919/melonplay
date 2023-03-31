using UnityEngine;
using System.Collections;
namespace Mod
{
    public class Firebeh : MonoBehaviour
    {
        void FixedUpdate() {
            foreach (var p2 in this.gameObject.transform.parent.parent.GetComponent<PersonBehaviour>().Limbs) {
                var phys = p2.GetComponent<PhysicalBehaviour>();
                var properties = phys.Properties.ShallowClone();
                properties.Flammability = 0f;
                phys.Properties = properties;

                phys.burnIntensity = 0;
                phys.Ignite();
                //phys.Temperature = 200f;
            };
        }
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.transform.parent.parent.GetComponent<PersonBehaviour>()) {
                PersonBehaviour enemyperson = collision.gameObject.transform.parent.parent.GetComponent<PersonBehaviour>();
                foreach (LimbBehaviour enemylimb in enemyperson.Limbs) {
                    PhysicalBehaviour phys = enemylimb.GetComponent<PhysicalBehaviour>();
                    phys.burnIntensity = 1f;
                    phys.Properties.Flammability = 1f;

                    phys.Ignite();
                };
            };
        }
    }
}
