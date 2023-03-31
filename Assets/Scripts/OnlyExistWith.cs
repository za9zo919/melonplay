using UnityEngine;

public class OnlyExistWith : MonoBehaviour
{
	[SkipSerialisation]
	public Component Other;

	[SkipSerialisation]
	public Component AlsoDelete;

	private void Update()
	{
		if (!Other)
		{
			UnityEngine.Object.Destroy(AlsoDelete);
			UnityEngine.Object.Destroy(this);
		}
	}
}
