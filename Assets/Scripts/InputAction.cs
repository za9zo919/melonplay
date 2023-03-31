using System;
using UnityEngine;

[Serializable]
public class InputAction
{
	public bool HoldRequired
	{
		get;
		set;
	}

	public KeyCode Key
	{
		get;
		set;
	}

	public KeyCode SecondaryKey
	{
		get;
		set;
	}

	public ActionRepresentation.ActionUniverse Universe
	{
		get;
		set;
	}

	private bool IsInCurrentUniverse => InputSystem.IsInUniverse(Universe);

	public InputAction(KeyCode key, KeyCode secondary = KeyCode.None)
	{
		Key = key;
		SecondaryKey = secondary;
	}

	public bool Evaluate()
	{
		if (!IsInCurrentUniverse)
		{
			return false;
		}
		if (!HoldRequired)
		{
			return IsReleased();
		}
		return IsHeld();
	}

	public bool IsHeld()
	{
		if (!IsInCurrentUniverse)
		{
			return false;
		}
		bool key = UnityEngine.Input.GetKey(Key);
		bool flag = SecondaryKey == KeyCode.None || UnityEngine.Input.GetKey(SecondaryKey);
		return key & flag;
	}

	public bool IsReleased()
	{
		if (!IsInCurrentUniverse)
		{
			return false;
		}
		bool keyUp = UnityEngine.Input.GetKeyUp(Key);
		bool flag = SecondaryKey == KeyCode.None || UnityEngine.Input.GetKey(SecondaryKey);
		return keyUp & flag;
	}

	public bool IsPressed()
	{
		if (!IsInCurrentUniverse)
		{
			return false;
		}
		bool keyDown = UnityEngine.Input.GetKeyDown(Key);
		bool flag = SecondaryKey == KeyCode.None || UnityEngine.Input.GetKey(SecondaryKey);
		return keyDown & flag;
	}

	public string GetDisplayText()
	{
		if (SecondaryKey != 0)
		{
			return KeyToString(Key) + "+" + KeyToString(SecondaryKey);
		}
		return KeyToString(Key);
	}

	private static string KeyToString(KeyCode key)
	{
		switch (key)
		{
		case KeyCode.Mouse0:
			return "Left Mouse";
		case KeyCode.Mouse1:
			return "Right Mouse";
		case KeyCode.Mouse2:
			return "Middle Mouse";
		default:
			return key.ToString();
		}
	}

	[Obsolete]
	public void SimulateDown()
	{
	}

	[Obsolete]
	public void SimulateUp()
	{
	}
}
