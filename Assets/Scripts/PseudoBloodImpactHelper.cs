using UnityEngine;

public class PseudoBloodImpactHelper : MonoBehaviour, Messages.IOnImpactCreated
{
	public Color Color;

	public void OnImpactCreated(GameObject gm)
	{
		if (gm.TryGetComponent(out BloodImpactBehaviour component))
		{
			component.SetColor(Color);
		}
	}
}
