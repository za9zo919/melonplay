using UnityEngine;

public class ActivateIfFancyEffects : MonoBehaviour
{
	private void Awake()
	{
		base.gameObject.SetActive(UserPreferenceManager.Current.FancyEffects);
	}
}
