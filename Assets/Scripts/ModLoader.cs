using ModModels;
using MoonSharp.Interpreter;
using Newtonsoft.Json;
using Steamworks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;

public class ModLoader
{
	public const string MetaFileName = "mod.json";

	public const string ModFolder = "Mods";

	public static List<ModMetaData> LoadedMods;

	public static Dictionary<ModMetaData, Script> ModScripts;

	private static readonly Dictionary<ModMetaData, Sprite> thumbnails;

	internal static HashSet<ModMetaData> alreadyInitialisedMods;

	public static event EventHandler ModListChanged;

	internal static void InvokeModListChange()
	{
		ModLoader.ModListChanged?.Invoke(null, EventArgs.Empty);
	}


	static ModLoader()
	{
		LoadedMods = new List<ModMetaData>();
		ModScripts = new Dictionary<ModMetaData, Script>();
		thumbnails = new Dictionary<ModMetaData, Sprite>();
		alreadyInitialisedMods = new HashSet<ModMetaData>();
	}

	internal static Script GetModScript(ModMetaData mod)
	{
		if (ModScripts.TryGetValue(mod, out Script value))
		{
			return value;
		}
		return null;
	}

	internal static ModMetaData GetModMetaFromScript(Script script)
	{
		foreach (KeyValuePair<ModMetaData, Script> modScript in ModScripts)
		{
			if (modScript.Value == script)
			{
				return modScript.Key;
			}
		}
		return null;
	}

	internal static void RemoveMod(ModMetaData mod)
	{
		LoadedMods.Remove(mod);
		ModScripts.Remove(mod);
	}


	public static ModMetaData Compile(ModMetaData mod)
	{
		try
		{
			string luaFilePath = Path.Combine(mod.MetaLocation, mod.ScriptPath); // Assuming the Lua script path is stored in the mod metadata
			if (!File.Exists(luaFilePath))
			{
				Debug.LogError("Lua script not found: " + luaFilePath);
			}

			string luaCode = File.ReadAllText(luaFilePath);
			Script script = new Script();
			script.DoString(luaCode);
			ModScripts.Add(mod, script);
		}
		catch (Exception ex)
		{
			Debug.LogError("Failed to execute Lua script: " + ex.Message);
		}

		return mod;
	}

	internal static void UploadMod(ModMetaData modMeta)
	{
		if (GetThumbnail(modMeta) == null)
		{
			UISoundBehaviour.Main.Error();
			DialogBoxManager.Notification("Mods require a thumbnail before they can be uploaded to the Workshop.");
			return;
		}
		if (!modMeta.Active)
		{
			UISoundBehaviour.Main.Error();
			DialogBoxManager.Notification("Your mod needs to be active to be uploaded.");
			return;
		}
		string name = SteamClient.Name;
		if (modMeta.Author != name)
		{
			UISoundBehaviour.Main.Warning();
			DialogBoxManager.Dialog("The mod author \"" + modMeta.Author + "\" does not match your current username \"" + name + "\". Are you sure you want to continue?", new DialogButton("Yes", true, delegate
			{
				SteamWorkshopModUploader.Main.PublishMod(modMeta);
			}), new DialogButton("No", true));
		}
		else
		{
			SteamWorkshopModUploader.Main.PublishMod(modMeta);
		}
	}

	internal static ModMetaData LoadModAt(string filePath)
	{
		UnityEngine.Debug.Log("Attempt load mod at " + filePath);
		ModMetaData modMetaData;
		try
		{
			modMetaData = JsonConvert.DeserializeObject<ModMetaData>(File.ReadAllText(filePath));
			modMetaData.MetaPath = filePath;
			modMetaData.MetaLocation = Path.GetDirectoryName(filePath);
			LoadedMods.Add(modMetaData);
		}
		catch (Exception message)
		{
			UnityEngine.Debug.LogError(message);
			return null;
		}
		UnityEngine.Debug.Log("Loaded mod: " + modMetaData.Name);
		return modMetaData;
	}

	public static Sprite GetThumbnail(ModMetaData modmeta)
	{
		if (thumbnails.TryGetValue(modmeta, out Sprite value))
		{
			return value;
		}
		try
		{
			string text = Path.Combine(modmeta.MetaLocation, modmeta.ThumbnailPath);
			if (!File.Exists(text))
			{
				return null;
			}
			Sprite sprite = LoadTexture(text);
			thumbnails.Add(modmeta, sprite);
			return sprite;
		}
		catch (Exception message)
		{
			UnityEngine.Debug.LogError(message);
			return null;
		}
	}

	public static void SetModActive(ModMetaData modmeta, bool active = true)
	{
		if (modmeta.MetaLocation == null)
		{
			throw new ArgumentException(modmeta.Name + " is unloaded");
		}
		modmeta.Active = active;
		if (modmeta.Active)
		{
			ModificationManager.InvokeOnLoad(modmeta);
		}
		UpdateJSON(modmeta);
		try
		{
			ModExtraMetadataLoader.StoreActive();
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("Failed to sync extra meta data: " + ex?.ToString());
		}
	}

	internal static void UpdateJSON(ModMetaData modmeta)
	{
		string contents = JsonConvert.SerializeObject(modmeta, Formatting.Indented);
		File.WriteAllText(modmeta.MetaPath, contents);
	}

	private static Sprite LoadTexture(string fullPath, FilterMode mode = FilterMode.Bilinear)
	{
		byte[] data = File.ReadAllBytes(fullPath);
		Texture2D texture2D = new Texture2D(0, 0);
		if (!texture2D.LoadImage(data))
		{
			throw new InvalidDataException("Texture at " + fullPath + " cannot be loaded as a PNG");
		}
		texture2D.filterMode = mode;
		texture2D.wrapMode = TextureWrapMode.Clamp;
		return Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), 0.5f * Vector2.one, 256f);
	}


	private static IEnumerable<string> GetModSourcePaths(ModMetaData modmeta)
	{
		for (int i = 0; i < modmeta.Scripts.Length; i++)
		{
			string path = modmeta.Scripts[i];
			yield return Path.GetFullPath(Path.Combine(modmeta.MetaLocation, path));
		}
	}

	private static string AlphaNumeric(string a)
	{
		return Regex.Replace(a, "[^a-zA-Z0-9 -]", "");
	}

	private static string GetOutputAssemblyPath(ModMetaData mod)
	{
		return Path.GetFullPath("CompiledModAssemblies\\" + AlphaNumeric(mod.GetUniqueName()) + ".dll");
	}

	private static string GetAssemblyMetaPath(ModMetaData mod)
	{
		return Path.GetFullPath("CompiledModAssemblies\\" + AlphaNumeric(mod.GetUniqueName()) + ".meta");
	}

	public static IEnumerable<byte> GetModAssemblyMeta(ModMetaData mod)
	{
		List<byte> list = new List<byte>();
		foreach (string modSourcePath in GetModSourcePaths(mod))
		{
			if (File.Exists(modSourcePath))
			{
				list.AddRange(Utils.GetMD5ForFile(modSourcePath));
			}
		}
		list.AddRange(Utils.GetMD5(mod.ModVersion));
		list.AddRange(Utils.GetMD5(mod.GameVersion));
		return list;
	}

	public static bool ShouldRecompile(ModMetaData mod)
	{
		if (mod.HasErrors)
		{
			UnityEngine.Debug.LogFormat("{0} recompiled because it had errors", mod.Name);
			return true;
		}
		/*string assemblyMetaPath = GetAssemblyMetaPath(mod);
		string outputAssemblyPath = GetOutputAssemblyPath(mod);
		if (!File.Exists(assemblyMetaPath) || !File.Exists(outputAssemblyPath))
		{
			UnityEngine.Debug.LogFormat("{0} recompiled because it had missing files (probably because it was malfunctioning and was not compiled)", mod.Name);
			return true;
		}
		byte[] array = File.ReadAllBytes(assemblyMetaPath);
		try
		{
			byte[] array2 = GetModAssemblyMeta(mod).ToArray();
			if (array2.Length != array.Length)
			{
				UnityEngine.Debug.LogFormat("{0} recompiled because the hash does not match", mod.Name);
				return true;
			}
			for (int i = 0; i < array2.Length; i++)
			{
				if (array2[i] != array[i])
				{
					UnityEngine.Debug.LogFormat("{0} recompiled because the hash does not match", mod.Name);
					return true;
				}
			}
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.Log("Failed to compute mod hash for " + mod.Name + ": " + ex.Message);
			return true;
		}*/
		return false;
	}
}
