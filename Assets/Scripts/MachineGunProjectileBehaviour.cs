using System;
using UnityEngine;

[Obsolete]
public class MachineGunProjectileBehaviour : MonoBehaviour
{
	public float UnitsPerSecond = 1f;

	private LayerMask mask;

	private float f;

	private void Awake()
	{
		mask = LayerMask.GetMask("Objects", "Bounds");
	}

	private void Update()
	{
		Vector3 right = base.transform.right;
		right.y -= f;
		right.Normalize();
		float num = UnitsPerSecond * Time.deltaTime;
		RaycastHit2D hit = Physics2D.Raycast(base.transform.position, right, num, mask);
		if ((bool)hit)
		{
			Vector2 v = hit.point + hit.normal * 0.05f;
			UnityEngine.Object.Destroy(base.gameObject);
			ExplosionCreator.CreateFragmentationExplosion(8u, v, 2f, 4f, particleAndSound: true);
			hit.transform.SendMessage("Shot", new Shot(hit.normal, hit.point, 35f), SendMessageOptions.DontRequireReceiver);
			hit.transform.SendMessage("ExitShot", new Shot(hit.normal, hit.point, 35f), SendMessageOptions.DontRequireReceiver);
			hit.transform.SendMessage("Break", num * (Vector2)right, SendMessageOptions.DontRequireReceiver);
		}
		else
		{
			base.transform.position += right * num;
		}
		f += Time.deltaTime * 0.1f;
	}
}
