using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public static class InputSystem
{
	public static Dictionary<string, InputAction> Actions = new Dictionary<string, InputAction>();

	public const string FilePath = "ControlScheme.json";

	public static ActionRepresentation.ActionUniverse CurrentUniverse = ActionRepresentation.ActionUniverse.All;

	public static bool IsInUniverse(ActionRepresentation.ActionUniverse other)
	{
		return other.UniverseMatches(CurrentUniverse);
	}

	public static void Save()
	{
		string contents = JsonConvert.SerializeObject(Actions, Formatting.Indented);
		File.WriteAllText("ControlScheme.json", contents);
	}

	public static void Load()
	{
		try
		{
			foreach (KeyValuePair<string, InputAction> item in JsonConvert.DeserializeObject<Dictionary<string, InputAction>>(File.ReadAllText("ControlScheme.json")))
			{
				if (Actions.ContainsKey(item.Key))
				{
					Actions[item.Key] = item.Value;
				}
				else
				{
					Actions.Add(item.Key, item.Value);
				}
			}
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.Log("Control scheme file not found.");
			UnityEngine.Debug.LogException(exception);
		}
	}

	[Obsolete]
	public static void SimulatePress(string identifier)
	{
		if (Actions.TryGetValue(identifier, out InputAction value))
		{
			value.SimulateDown();
			value.SimulateUp();
		}
	}

	public static string GetDisplayText(string name)
	{
		if (Actions.TryGetValue(name, out InputAction value))
		{
			return value.GetDisplayText();
		}
		UnityEngine.Debug.LogWarning("Could not retrieve control " + name);
		return "?";
	}

	public static bool Has(string name)
	{
		return Actions.ContainsKey(name);
	}

	public static bool Get(string name)
	{
		if (Actions.TryGetValue(name, out InputAction value))
		{
			return value.Evaluate();
		}
		UnityEngine.Debug.LogWarning("Could not retrieve control " + name);
		return false;
	}

	public static bool Held(string name)
	{
		if (Actions.TryGetValue(name, out InputAction value))
		{
			return value.IsHeld();
		}
		UnityEngine.Debug.LogWarning("Could not retrieve control " + name);
		return false;
	}

	public static bool Down(string name)
	{
		if (Actions.TryGetValue(name, out InputAction value))
		{
			return value.IsPressed();
		}
		UnityEngine.Debug.LogWarning("Could not retrieve control " + name);
		return false;
	}

	public static bool Up(string name)
	{
		if (Actions.TryGetValue(name, out InputAction value))
		{
			return value.IsReleased();
		}
		UnityEngine.Debug.LogWarning("Could not retrieve control " + name);
		return false;
	}
}
