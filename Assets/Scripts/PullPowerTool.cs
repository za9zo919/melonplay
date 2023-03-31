using UnityEngine;

public class PullPowerTool : AOEPowerTool
{
	protected override void HandleObject(PhysicalBehaviour phys)
	{
		Vector2 a = Global.main.MousePosition - phys.transform.position;
		float num = Mathf.Max(0.25f, a.magnitude);
		if (num < DampeningRadius)
		{
			phys.rigidbody.velocity *= 0.92f;
			phys.rigidbody.angularVelocity *= 0.92f;
		}
		Vector2 a2 = a / num;
		phys.rigidbody.AddForce((GetFalloff(Force, a.sqrMagnitude, MaxForce) * a2 + GetFalloff(1f, a.sqrMagnitude, 1f) * mouseMovement) * phys.rigidbody.mass, ForceMode2D.Force);
	}

	protected override GameObject CreateEffectObject()
	{
		return Object.Instantiate(Resources.Load<GameObject>("Prefabs/Pull tool effect"));
	}
}
