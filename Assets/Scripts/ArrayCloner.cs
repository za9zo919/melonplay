using UnityEngine;

public class ArrayCloner : MonoBehaviour
{
	public int Amount;

	public Vector2 Delta;

	public void Start()
	{
		Vector2 a = base.transform.position;
		for (int i = 1; i < Amount; i++)
		{
			Vector2 v = a + Delta * i;
			GameObject gameObject = UnityEngine.Object.Instantiate(base.gameObject, v, base.transform.rotation);
			gameObject.transform.localScale = base.transform.lossyScale;
			UnityEngine.Object.Destroy(gameObject.GetComponent<ArrayCloner>());
			gameObject.transform.SetParent(base.transform.parent, worldPositionStays: true);
		}
	}

	private void OnDrawGizmosSelected()
	{
		Bounds bounds = GetComponent<SpriteRenderer>().bounds;
		Vector2 a = base.transform.position;
		for (int i = 1; i < Amount; i++)
		{
			Gizmos.DrawWireCube(a + Delta * i, bounds.size);
		}
	}
}
