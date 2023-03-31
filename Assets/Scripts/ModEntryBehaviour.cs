using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModEntryBehaviour : MonoBehaviour
{
	public ModListBehaviour ModListBehaviour;

	public GameObject ActiveCheck;

	public GameObject InactiveCheck;

	public GameObject ErrorCheck;

	public GameObject CompilingCheck;

	public GameObject RecompileButton;

	public GameObject ToggleModButton;

	public GameObject UploadButton;

	public GameObject OpenInWorkshopButton;

	public TextMeshProUGUI Title;

	public TextMeshProUGUI Subtitle;

	public TextMeshProUGUI Description;

	public Image Thumbnail;

	[Space]
	public ModMetaData ModMeta;

	private bool isBusy;

	private void Start()
	{
		UpdateUi();
		//LoadModFiles();
	}

	public void UpdateUi()
	{
		if (ModMeta != null)
		{
			Title.text = Utils.EscapeRichText(ModMeta.Name);
			Subtitle.text = "by <b>" + Utils.EscapeRichText(ModMeta.Author) + "</b> for " + Utils.EscapeRichText(ModMeta.GameVersion);
			Sprite thumbnail = ModLoader.GetThumbnail(ModMeta);
			if (thumbnail != null)
			{
				Thumbnail.sprite = thumbnail;
			}
			ActiveCheck.SetActive(ModMeta.Active && !ModMeta.HasErrors);
			InactiveCheck.SetActive(!ModMeta.Active && !ModMeta.HasErrors);
			ErrorCheck.SetActive(ModMeta.HasErrors);
			ToggleModButton.SetActive(!ModMeta.HasErrors);
			RecompileButton.SetActive(ModMeta.HasErrors);
			CompilingCheck.SetActive(value: false);
			OpenInWorkshopButton.SetActive(ModMeta.UGCIdentity != null || ModMeta.CreatorUGCIdentity != null);
			if (!string.IsNullOrWhiteSpace(ModMeta.Errors) && ModMeta.HasErrors)
			{
				Description.color = Color.red;
				Description.text = string.Join("\n", ModMeta.Errors);
			}
			else
			{
				Description.color = Color.white;
				Description.text = Utils.EscapeRichText(ModMeta.Description);
			}
			UploadButton.SetActive(!ModMeta.HasErrors && string.IsNullOrEmpty(ModMeta.UGCIdentity));
		}
	}
	private void LoadModFiles()
	{
		TextAsset modFile = Resources.Load<TextAsset>("Rainbow Friends Mod/script");
		if (modFile != null)
		{
			string modContent = modFile.text;
		}
		else
		{
			Debug.LogError("Mod file not found.");
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

	private static IEnumerable<string> GetModSourcePaths(ModMetaData modmeta)
	{
		for (int i = 0; i < modmeta.Scripts.Length; i++)
		{
			string path = modmeta.Scripts[i];
			yield return Path.GetFullPath(Path.Combine(modmeta.MetaLocation, path));
		}
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

	public void ToggleMod()
	{
		if (!isBusy)
		{
			//ModLoader.SetModActive(ModMeta, !ModMeta.Active);
			UpdateUi();
		}
	}

	public void ForceReload()
	{
		if (!isBusy)
		{
			ActiveCheck.SetActive(value: false);
			InactiveCheck.SetActive(value: false);
			ErrorCheck.SetActive(value: false);
			ToggleModButton.SetActive(value: false);
			RecompileButton.SetActive(value: false);
			CompilingCheck.SetActive(value: true);
			StartCoroutine(Recompile());
		}
	}

	public void OpenInWorkshop()
	{
		string text = ModMeta.UGCIdentity ?? ModMeta.CreatorUGCIdentity;
		if (text != null)
		{
			Utils.OpenURL("https://steamcommunity.com/sharedfiles/filedetails/?id=" + text);
		}
	}

	public void UploadMod()
	{
		if (!isBusy)
		{
			DialogBoxManager.Dialog("Do you want to upload \"" + ModMeta.Name + "\" to the workshop?", new DialogButton("Yes", true, delegate
			{
				_003CUploadMod_003Eg__uploadMod_007C20_1();
			}), new DialogButton("No", true));
		}
	}

	private IEnumerator Recompile()
	{
		if (!isBusy)
		{
			isBusy = true;
			Description.text = string.Empty;
			BackgroundItemLoader background = BackgroundItemLoader.Instance;
			yield return new WaitForSeconds(0.1f);
			(ModCompilationResult result, ModScript script) result = default((ModCompilationResult, ModScript));
			yield return background.DoAsyncTask(async delegate
			{
				result = await background.CompileMod(ModMeta);
			}, ModMeta.Name, "Processing", ModLoader.GetThumbnail(ModMeta));
			background.ProcessModCompilationResult(result, ModMeta);
			yield return new WaitForSeconds(0.1f);
			UpdateUi();
			if (ModMeta == null)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
			isBusy = false;
		}
	}

	[CompilerGenerated]
	private void _003CUploadMod_003Eg__uploadMod_007C20_1()
	{
		try
		{
			ModLoader.UploadMod(ModMeta);
		}
		catch (Exception ex)
		{
			UISoundBehaviour.Main.Error();
			DialogBoxManager.Notification("Unable to upload mod\n" + ex.Message);
		}
	}
}
