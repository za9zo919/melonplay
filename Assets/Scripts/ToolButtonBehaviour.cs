using UnityEngine;

public class ToolButtonBehaviour : MonoBehaviour
{
	public string BehaviourName = "DragTool";

	private ToolControllerBehaviour toolController;

	private void Awake()
	{
		toolController = UnityEngine.Object.FindObjectOfType<ToolControllerBehaviour>();
	}

	public void SetTool()
	{
		toolController.SetToolByTypeName(BehaviourName);
	}
}
