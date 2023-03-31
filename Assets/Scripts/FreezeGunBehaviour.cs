using UnityEngine;

public class FreezeGunBehaviour : EffectGunBehaviour
{
	public Color SkinColour;

	protected override void Affect(Collider2D coll)
	{
		if (TryGetLimb(coll, out LimbBehaviour limb) && !limb.IsAndroid)
		{
			limb.Frozen = true;
			limb.Color = SkinColour;
		}
	}
}
