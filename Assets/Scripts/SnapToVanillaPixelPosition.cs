using UnityEngine;

[ExecuteInEditMode]
public class SnapToVanillaPixelPosition : MonoBehaviour
{
	public float PixelSize = 0.0285714287f;

	public bool Half;

	private float snap
	{
		get
		{
			if (!Half)
			{
				return PixelSize;
			}
			return PixelSize / 2f;
		}
	}
}
