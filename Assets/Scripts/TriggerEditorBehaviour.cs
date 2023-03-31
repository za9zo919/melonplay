using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TriggerEditorBehaviour : MonoBehaviour
{
	public string ActionName = "";

	public KeyCode SetKey;

	public KeyCode SetSecondaryKey;

	public Button UnbindButton;

	public TextMeshProUGUI Text;

	private Button button;

	public Image Image;

	public ActionRepresentation.ActionUniverse Universe;

	private static bool someoneIsWaiting;

	public static bool IsBeingEdited
	{
		get;
		private set;
	}

	private void Awake()
	{
		button = GetComponent<Button>();
	}

	private void Start()
	{
		SetText();
	}

	public void StartWaiting()
	{
		if (!someoneIsWaiting)
		{
			someoneIsWaiting = true;
			button.interactable = false;
			StartCoroutine(WaitForUserInput());
		}
	}

	private IEnumerator WaitForUserInput()
	{
		KeyCode oldKey = SetKey;
		Vector3 oldPos = UnityEngine.Input.mousePosition;
		Text.text = "Press any button...";
		Cursor.visible = false;
		IsBeingEdited = true;
		yield return new WaitUntil(() => !Input.anyKey);
		yield return new WaitUntil(() => (!HasReceivedUserInput()) ? ((oldPos - UnityEngine.Input.mousePosition).magnitude > 200f) : true);
		if ((oldPos - UnityEngine.Input.mousePosition).magnitude <= 200f)
		{
			SetText();
			yield return new WaitUntil(() => !Input.anyKey);
		}
		else
		{
			SetKey = oldKey;
			SetText();
		}
		button.interactable = true;
		someoneIsWaiting = false;
		Cursor.visible = true;
		IsBeingEdited = false;
		InputSystem.Actions[ActionName].Key = SetKey;
		InputSystem.Actions[ActionName].SecondaryKey = SetSecondaryKey;
		InputSystem.Save();
	}

	private void Update()
	{
		Image.color = (InputSystem.Actions.Any((KeyValuePair<string, InputAction> c) => AreConflicting(this, c.Value) && ActionName != c.Key) ? (Color.red * 0.25f) : (Color.black * 0.25f));
	}

	public void Unbind()
	{
		SetKey = KeyCode.None;
		SetSecondaryKey = KeyCode.None;
		InputSystem.Actions[ActionName].Key = SetKey;
		InputSystem.Actions[ActionName].SecondaryKey = SetSecondaryKey;
		InputSystem.Save();
		SetText();
	}

	private bool AreConflicting(TriggerEditorBehaviour a, InputAction b)
	{
		if (!a.Universe.UniverseMatches(b.Universe))
		{
			return false;
		}
		if (a.SetKey == KeyCode.None || b.Key == KeyCode.None)
		{
			return false;
		}
		if (a.SetKey == b.Key)
		{
			return true;
		}
		if (a.SetSecondaryKey == b.Key)
		{
			return true;
		}
		if (a.SetKey == b.SecondaryKey)
		{
			return true;
		}
		if (a.SetSecondaryKey == KeyCode.None)
		{
			return false;
		}
		if (b.SecondaryKey == KeyCode.None)
		{
			return false;
		}
		if (a.SetSecondaryKey == b.SecondaryKey)
		{
			return true;
		}
		return false;
	}

	private void SetText()
	{
		Text.text = ((SetSecondaryKey == KeyCode.None) ? "" : (SetSecondaryKey.ToString() + " + ")) + SetKey.ToString();
		UnbindButton.gameObject.SetActive(SetKey != KeyCode.None);
	}

	private bool HasReceivedUserInput()
	{
		SetSecondaryKey = KeyCode.None;
		IList values = Enum.GetValues(typeof(KeyCode));
		for (int i = 0; i < values.Count; i++)
		{
			KeyCode keyCode = (KeyCode)values[i];
			if (UnityEngine.Input.GetKey(keyCode))
			{
				SetSecondaryKey = keyCode;
			}
		}
		IList values2 = Enum.GetValues(typeof(KeyCode));
		for (int j = 0; j < values2.Count; j++)
		{
			KeyCode keyCode2 = (KeyCode)values2[j];
			if (UnityEngine.Input.GetKeyUp(keyCode2))
			{
				SetKey = keyCode2;
				return true;
			}
		}
		return false;
	}
}
