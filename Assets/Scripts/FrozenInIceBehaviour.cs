using UnityEngine;

public class FrozenInIceBehaviour : MonoBehaviour
{
	private SkinMaterialHandler skin;

	private bool shouldRotOriginal;

	private void Awake()
	{
		if (TryGetComponent(out skin))
		{
			shouldRotOriginal = skin.ShouldRot;
			skin.ShouldRot = false;
		}
	}

	private void OnDestroy()
	{
		if ((bool)skin)
		{
			skin.ShouldRot = shouldRotOriginal;
		}
	}
}
