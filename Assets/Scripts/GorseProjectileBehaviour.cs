using UnityEngine;

public class GorseProjectileBehaviour : MonoBehaviour
{
	public float Damage;

	public Rigidbody2D Rigidbody2D;

	public GameObject DisperseEffect;

	public float AcidChance = 0.2f;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if ((bool)collision.transform && collision.transform.TryGetComponent(out LimbBehaviour component))
		{
			component.Wince(Damage);
			component.Damage(Damage);
			if (!component.IsAndroid && AcidChance > UnityEngine.Random.value)
			{
				component.CirculationBehaviour.AddLiquid(Liquid.GetLiquid("GORSE BLOOD"), 25f);
				if (component.NodeBehaviour.IsConnectedToRoot)
				{
					component.Person.AddPain(50f);
				}
			}
		}
		Object.Instantiate(DisperseEffect, base.transform.position, Quaternion.identity);
		UnityEngine.Object.Destroy(base.gameObject);
	}
}
