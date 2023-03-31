using System;
using UnityEngine;

[Serializable]
public struct ActionRepresentation
{
	public enum ActionCategory
	{
		General,
		UserInterface,
		Camera,
		MapEditor,
		Modded
	}

	public enum ActionUniverse
	{
		None,
		All,
		Game,
		MapEditor
	}

	public string Name;

	public string Codename;

	public ActionCategory Category;

	public ActionUniverse Universe;

	public KeyCode DefaultKey;

	public KeyCode SecondaryKey;

	public bool InvisibleInMenu;

	public override string ToString()
	{
		return $"{Name} [{Category}]";
	}
}
