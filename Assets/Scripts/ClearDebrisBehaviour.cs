using UnityEngine;

public class ClearDebrisBehaviour : MonoBehaviour
{
	public LayerMask Debris;

	public void Clear()
	{
		DecalControllerBehaviour[] array = UnityEngine.Object.FindObjectsOfType<DecalControllerBehaviour>();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Clear();
		}
		DebrisComponent[] array2 = UnityEngine.Object.FindObjectsOfType<DebrisComponent>();
		foreach (DebrisComponent obj in array2)
		{
			UnityEngine.Object.Destroy(obj.gameObject);
			if (UndoControllerBehaviour.FindRelevantAction(obj.gameObject, out IUndoableAction result))
			{
				UndoControllerBehaviour.DeregisterAction(result);
			}
		}
		NotificationControllerBehaviour.Show("Cleared debris");
	}
}
