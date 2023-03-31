using UnityEngine;

public class DeregisterBehaviour : MonoBehaviour
{
	private void OnDestroy()
	{
		if (UndoControllerBehaviour.FindRelevantAction(base.gameObject, out IUndoableAction result))
		{
			UndoControllerBehaviour.DeregisterAction(result);
		}
	}
}
