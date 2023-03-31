using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Steamworks;
using Steamworks.Data;
using Steamworks.Ugc;
using UnityEngine;

public class SteamWorkshopModUploader : MonoBehaviour, IProgress<float>
{
	public static SteamWorkshopModUploader Main;

	private ModMetaData currentlyUploading;

	private bool isBusy;

	private DialogBox currentProgressBox;

	private float currentProgress;

	private void Awake()
	{
		Main = this;
	}

	public void PublishMod(ModMetaData modMeta)
	{
		if (isBusy)
		{
			return;
		}
		if (modMeta.HasErrors)
		{
			throw new ArgumentException("Mod cannot compile, cannot upload");
		}
		if (!string.IsNullOrEmpty(modMeta.UGCIdentity))
		{
			throw new ArgumentException("This mod originates from the workshop already");
		}
		currentlyUploading = modMeta;
		if (string.IsNullOrEmpty(currentlyUploading.CreatorUGCIdentity))
		{
			StartCoroutine(PublishRoutine());
			return;
		}
		UISoundBehaviour.Main.Warning();
		DialogBoxManager.Dialog("This item is marked as once uploaded. How do you want to continue?", new DialogButton("Update existing", true, delegate
		{
			StartCoroutine(PublishRoutine(ulong.Parse(modMeta.CreatorUGCIdentity)));
		}), new DialogButton("Upload as new", true, delegate
		{
			StartCoroutine(PublishRoutine());
		}), new DialogButton("Cancel", true));
	}

	private IEnumerator PublishRoutine(PublishedFileId? existingId = null)
	{
		isBusy = true;
		PublishResult? publishResult = null;
		string contentLocation = ToAbsolutePath(currentlyUploading.MetaLocation);
		string thumbnailLocation = ToAbsolutePath(Path.Combine(currentlyUploading.MetaLocation, currentlyUploading.ThumbnailPath));
		if (new FileInfo(thumbnailLocation).Length > 1000000)
		{
			UISoundBehaviour.Main.Error();
			Debug.LogWarning("Invalid thumbnail");
			DialogBoxManager.Dialog("Mod thumbnail exceeds 1 MB. Please compress or resize the image.", new DialogButton("Close", true));
			isBusy = false;
			yield break;
		}
		Editor editor;
		if (existingId.HasValue)
		{
			Item? item = null;
			Task<Item?> getItemTask = Task.Run(async () => item = await Item.GetAsync(existingId.Value));
			yield return new WaitUntil(() => getItemTask.IsCompleted);
			if (!item.HasValue || !item.Value.Result.HasFlag(Result.OK))
			{
				Debug.LogWarning("Failed to retrieve original Workshop item... creating a new one");
				StartCoroutine(PublishRoutine());
				yield break;
			}
			editor = item.Value.Edit();
			editor = editor.WithContent(contentLocation).WithPreviewFile(thumbnailLocation);
		}
		else
		{
			editor = Editor.NewCommunityFile.WithTitle(currentlyUploading.Name).WithDescription(currentlyUploading.Description).WithPreviewFile(thumbnailLocation)
				.WithContent(contentLocation)
				.WithPublicVisibility();
			IList<string> tagsForSteam = currentlyUploading.GetTagsForSteam();
			for (int i = 0; i < tagsForSteam.Count; i++)
			{
				string text = tagsForSteam[i];
				editor = editor.WithTag(text);
			}
		}
		Task<PublishResult?> task = Task.Run(async () => publishResult = await editor.SubmitAsync(this));
		if ((bool)currentProgressBox)
		{
			currentProgressBox.Close();
		}
		currentProgressBox = DialogBoxManager.Dialog(currentlyUploading.Name);
		yield return new WaitUntil(() => task.IsCompleted);
		if (!publishResult.HasValue)
		{
			if (task.IsFaulted)
			{
				Debug.LogError(task.Exception.InnerException);
			}
			UISoundBehaviour.Main.Error();
			DialogBoxManager.Dialog("Could not create workshop item\n<i>" + (task.IsFaulted ? task.Exception.InnerException.Message : "Unknown reason") + "</i>", new DialogButton("Close", true));
			isBusy = false;
			task.Dispose();
			yield break;
		}
		task.Dispose();
		if (!publishResult.Value.Result.HasFlag(Result.OK))
		{
			UISoundBehaviour.Main.Error();
			Debug.LogWarning("Failed to create Steam Workshop item: " + publishResult.Value.Result);
			DialogBoxManager.Dialog($"Could not create workshop item\n<i>{publishResult.Value.Result}</i>", new DialogButton("Close", true));
			isBusy = false;
		}
		else if (publishResult.Value.NeedsWorkshopAgreement)
		{
			DialogBoxManager.Dialog("By submitting to the workshop, you agree to the terms of service.", new DialogButton("View terms of service", false, delegate
			{
				OpenURL("https://steamcommunity.com/sharedfiles/workshoplegalagreement");
			}), new DialogButton("Understood", true, delegate
			{
				PublishMod(currentlyUploading);
			}), new DialogButton("Cancel", true));
			isBusy = false;
		}
		else
		{
			currentlyUploading.CreatorUGCIdentity = publishResult.Value.FileId.ToString();
			ModLoader.UpdateJSON(currentlyUploading);
			OpenURL($"steam://url/CommunityFilePage/{publishResult.Value.FileId}");
			if ((bool)currentProgressBox)
			{
				currentProgressBox.Close();
			}
			isBusy = false;
		}
	}

	private static string ToAbsolutePath(string relativePath)
	{
		return Path.Combine(Environment.CurrentDirectory, relativePath);
	}

	private void OpenURL(string url)
	{
		if (SteamUtils.IsOverlayEnabled)
		{
			SteamFriends.OpenWebOverlay(url);
		}
		else
		{
			Application.OpenURL(url);
		}
	}

	public void Report(float value)
	{
		currentProgress = value;
	}

	private void Update()
	{
		if ((bool)currentProgressBox && currentlyUploading != null)
		{
			currentProgressBox.SetTitle($"{currentlyUploading.Name}\n\n{Mathf.RoundToInt(currentProgress * 100f)}% uploaded...");
		}
	}
}
