using UnityEngine;

public class PinTool : ToolBehaviour
{
	private readonly Collider2D[] buffer = new Collider2D[8];

	private int bufferLength;

	private PhysicalBehaviour firstFound;

	private PhysicalBehaviour secondFound;

	public override void OnSelect()
	{
		if (!DialogBox.IsAnyDialogboxOpen && !Global.ActiveUiBlock)
		{
			GetFoundBodies();
			if ((bool)firstFound || (bool)secondFound)
			{
				PhysicalBehaviour physicalBehaviour = firstFound ? firstFound : secondFound;
				PhysicalBehaviour b = firstFound ? secondFound : null;
				CreatePin(physicalBehaviour.transform.InverseTransformPoint(GetPinPos()), physicalBehaviour, b, GetBreakingThreshold());
			}
		}
	}

	private Vector2 GetPinPos()
	{
		Vector3 v = Global.main.MousePosition;
		if (InputSystem.Held("snapToCenter"))
		{
			if ((bool)firstFound)
			{
				v = firstFound.GetWorldCenterOfMass();
			}
			else if ((bool)secondFound)
			{
				v = secondFound.GetWorldCenterOfMass();
			}
		}
		return v;
	}

	private void GetFoundBodies()
	{
		firstFound = null;
		secondFound = null;
		Vector2 pinPos = GetPinPos();
		bufferLength = Physics2D.OverlapPointNonAlloc(pinPos, buffer);
		for (int i = 0; i < bufferLength; i++)
		{
			if (!buffer[i].TryGetComponent(out PhysicalBehaviour component) || component.gameObject.HasComponent<Optout>())
			{
				continue;
			}
			if (!firstFound || firstFound == component)
			{
				firstFound = component;
				continue;
			}
			if (!secondFound || secondFound == component)
			{
				secondFound = component;
				continue;
			}
			break;
		}
	}

	public override void OnFixedHold()
	{
	}

	public override void OnHold()
	{
	}

	public override void OnDeselect()
	{
	}

	public override void OnToolChosen()
	{
	}

	public override void OnToolUnchosen()
	{
	}

	protected virtual float GetBreakingThreshold()
	{
		return float.PositiveInfinity;
	}

	public virtual void CreatePin(Vector2 anchor, PhysicalBehaviour a, PhysicalBehaviour b = null, float breakThreshold = float.PositiveInfinity)
	{
		PinBehaviour pinBehaviour = a.gameObject.AddComponent<PinBehaviour>();
		UndoControllerBehaviour.RegisterAction(new ObjectCreationAction(pinBehaviour, "pin"));
		pinBehaviour.LocalAnchor = anchor;
		pinBehaviour.Other = b;
		pinBehaviour.BreakingThreshold = breakThreshold;
		pinBehaviour.UsedToHaveConnectedBody = b;
		OnPinCreation(pinBehaviour);
	}

	protected virtual void OnPinCreation(PinBehaviour pin)
	{
	}
}
