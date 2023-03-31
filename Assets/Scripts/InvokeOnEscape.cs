using UnityEngine;
using UnityEngine.Events;

public class InvokeOnEscape : MonoBehaviour
{
	public UnityEvent OnEscapePress;

	private void Update()
	{
		if (UnityEngine.Input.GetKeyDown(KeyCode.Escape) && !TriggerEditorBehaviour.IsBeingEdited)
		{
			OnEscapePress?.Invoke();
		}
	}
}
