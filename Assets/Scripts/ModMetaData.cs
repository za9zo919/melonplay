using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class ModMetaData
{
	public string Name = "Mod";

	public string Author = "";

	public string Description = "";

	public string ModVersion = "1.0";

	public string GameVersion = "1.25 preview 3";

	public string ScriptPath = "1.25 preview 3";

	public string ThumbnailPath = "thumb.png";

	public string EntryPoint = "Mod.Mod";

	public string[] Tags = new string[0];

	public string[] Scripts = new string[0];

	public bool Active = true;

	[NonSerialized]
	public string MetaLocation;

	public string UGCIdentity;

	public string CreatorUGCIdentity;

	[NonSerialized]
	public string MetaPath;

	[NonSerialized]
	public bool HasErrors;

	[NonSerialized]
	public string Errors;

	internal string GetUniqueName()
	{
		string text = string.IsNullOrWhiteSpace(CreatorUGCIdentity) ? "local" : CreatorUGCIdentity;
		return Author.Normalize() + "-" + Name.Normalize() + "-" + text.Normalize();
	}

	internal IList<string> GetTagsForSteam()
	{
		return (Tags ?? Array.Empty<string>()).Append("Mods").ToList();
	}
}
