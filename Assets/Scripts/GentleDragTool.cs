using UnityEngine;

public class GentleDragTool : DragTool
{
	private const float maxForce = 0.5f;

	protected override float DragStrengthFunction()
	{
		return 0.008f;
	}

	protected override float GetDragFunction()
	{
		return 0.2f;
	}

	protected override float GetDraggerMassFunction()
	{
		return 0.01f;
	}

	public override void OnSelect()
	{
		base.OnSelect();
		Rigidbody.drag = 15f;
		Rigidbody.angularDrag = 15f;
	}

	protected override void MoveToMouse()
	{
		Vector3 a = (base.IsSnapping ? base.MousePosWithSnap : Global.main.MousePosition) - base.transform.position;
		float magnitude = a.magnitude;
		if (magnitude > 0.5f)
		{
			a /= magnitude;
			a *= 0.5f;
		}
		Rigidbody.AddForce(Time.deltaTime * 60f * 0.0001f * 1.95E+07f * DragStrengthFunction() * a);
	}
}
