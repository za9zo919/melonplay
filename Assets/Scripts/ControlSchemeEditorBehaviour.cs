using NaughtyAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class ControlSchemeEditorBehaviour : MonoBehaviour
{
	[ReorderableList]
	public List<ActionRepresentation> Actions = new List<ActionRepresentation>();

	public GameObject ControlPrefab;

	public GameObject HeaderPrefab;

	public Transform Container;

	internal static bool shouldReinitialiseForModdedEntry;

	private void Awake()
	{
		LoadInputSystem();
		InitialiseControlScheme();
	}

	private void Update()
	{
		if (shouldReinitialiseForModdedEntry)
		{
			shouldReinitialiseForModdedEntry = false;
			LoadInputSystem();
			InitialiseControlScheme();
		}
	}

	public void InitialiseControlScheme()
	{
		foreach (Transform item in Container)
		{
			UnityEngine.Object.Destroy(item.gameObject);
		}
		IEnumerable<ActionRepresentation> source = Actions.Concat(ModAPI.ModdedControlInputEntries);
		foreach (ActionRepresentation.ActionCategory category in Enum.GetValues(typeof(ActionRepresentation.ActionCategory)))
		{
			if (category != ActionRepresentation.ActionCategory.MapEditor)
			{
				IEnumerable<ActionRepresentation> enumerable = from action in source
					where action.Category == category && !action.InvisibleInMenu
					select action;
				if (enumerable.Any())
				{
					UnityEngine.Object.Instantiate(HeaderPrefab, Container).GetComponentInChildren<TextMeshProUGUI>().text = Regex.Replace(category.ToString(), "(\\B[A-Z])", " $1");
					foreach (ActionRepresentation item2 in enumerable)
					{
						CreateControlObject(item2);
					}
				}
			}
		}
	}

	private void CreateControlObject(ActionRepresentation action)
	{
		ActionControlBehaviour component = UnityEngine.Object.Instantiate(ControlPrefab, Container).GetComponent<ActionControlBehaviour>();
		component.Action.text = action.Name;
		TriggerEditorBehaviour component2 = component.Trigger.GetComponent<TriggerEditorBehaviour>();
		component2.ActionName = action.Codename;
		component2.SetKey = action.DefaultKey;
		component2.SetSecondaryKey = action.SecondaryKey;
		component2.Universe = action.Universe;
		if (InputSystem.Actions.TryGetValue(action.Codename, out InputAction value))
		{
			component2.SetKey = value.Key;
			component2.SetSecondaryKey = value.SecondaryKey;
			InputSystem.Actions[action.Codename].Universe = action.Universe;
			UnityEngine.Debug.LogFormat("Action {0} is in universe {1}", action.Codename, InputSystem.Actions[action.Codename].Universe);
		}
		else
		{
			InputSystem.Actions.Add(action.Codename, new InputAction(action.DefaultKey, action.SecondaryKey)
			{
				Universe = action.Universe
			});
		}
		InputSystem.Save();
	}

	[ContextMenu("Save settings")]
	internal void SaveInputSystem()
	{
		InputSystem.Save();
	}

	[ContextMenu("Load settings")]
	internal void LoadInputSystem()
	{
		InputSystem.Load();
	}
}
