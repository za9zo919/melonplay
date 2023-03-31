using UnityEngine;

public abstract class ToolBehaviour : MonoBehaviour
{
	public PhysicalBehaviour ActiveSingleSelected;

	public Rigidbody2D Rigidbody;

	public virtual bool UsesEmptyDrag => true;

	public abstract void OnToolChosen();

	public abstract void OnToolUnchosen();

	public abstract void OnSelect();

	public abstract void OnHold();

	public abstract void OnFixedHold();

	public abstract void OnDeselect();
}
