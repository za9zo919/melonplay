using Steamworks;
using Steamworks.Ugc;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;

public class DeleteContraptionButtonBehaviour : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003C_003CRemoveContraption_003Eb__3_0_003Ed : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public DeleteContraptionButtonBehaviour _003C_003E4__this;

		private TaskAwaiter<Item?> _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private void MoveNext()
		{
			int num = _003C_003E1__state;
			DeleteContraptionButtonBehaviour deleteContraptionButtonBehaviour = _003C_003E4__this;
			try
			{
				TaskAwaiter<bool> awaiter;
				TaskAwaiter<Item?> awaiter2;
				if (num != 0)
				{
					if (num == 1)
					{
						awaiter = _003C_003Eu__2;
						_003C_003Eu__2 = default(TaskAwaiter<bool>);
						num = (_003C_003E1__state = -1);
						goto IL_0112;
					}
					awaiter2 = Item.GetAsync(deleteContraptionButtonBehaviour.PublishedFileId).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter2;
						_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
						return;
					}
				}
				else
				{
					awaiter2 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<Item?>);
					num = (_003C_003E1__state = -1);
				}
				Item? result = awaiter2.GetResult();
				if (result.HasValue && result.Value.Result == Result.OK && result.Value.IsInstalled)
				{
					awaiter = result.Value.Unsubscribe().GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter;
						_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
					goto IL_0112;
				}
				goto end_IL_000e;
				IL_0112:
				awaiter.GetResult();
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			_003C_003Et__builder.SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	public ContraptionMetaData ContraptionMetaData;

	public ulong PublishedFileId;

	public void CreateDialogBoxAndRemove()
	{
		DialogBoxManager.Dialog(((PublishedFileId == 0L) ? "Are you sure you want to permanently remove" : "Are you sure you want to unsubscribe from") + " " + ContraptionMetaData.DisplayName + "?", new DialogButton("Yes", true, RemoveContraption), new DialogButton("No", true));
	}

	public void RemoveContraption()
	{
		if (PublishedFileId != 0L)
		{
			Task.Run(async delegate
			{
				Item? item = await Item.GetAsync(PublishedFileId);
				if (item.HasValue && item.Value.Result == Result.OK && item.Value.IsInstalled)
				{
					await item.Value.Unsubscribe();
				}
			});
		}
		string pathToMetadata = ContraptionMetaData.PathToMetadata;
		string pathToDataFile = ContraptionMetaData.PathToDataFile;
		string pathToThumbnail = ContraptionMetaData.PathToThumbnail;
		string pathToOutlineFile = ContraptionMetaData.PathToOutlineFile;
		if (!File.Exists(pathToMetadata) || !File.Exists(pathToDataFile))
		{
			UnityEngine.Debug.LogWarning("Attempt to delete contraption that doesn't exist: " + ContraptionMetaData.Name);
		}
		_003CRemoveContraption_003Eg__attemptDelete_007C3_1(pathToMetadata);
		_003CRemoveContraption_003Eg__attemptDelete_007C3_1(pathToDataFile);
		_003CRemoveContraption_003Eg__attemptDelete_007C3_1(pathToThumbnail);
		_003CRemoveContraption_003Eg__attemptDelete_007C3_1(pathToOutlineFile);
		CatalogBehaviour.Main.CreateItemButtons();
	}

	[CompilerGenerated]
	private static void _003CRemoveContraption_003Eg__attemptDelete_007C3_1(string path)
	{
		if (File.Exists(path))
		{
			try
			{
				File.Delete(path);
			}
			catch (Exception message)
			{
				UnityEngine.Debug.LogError(message);
				DialogBoxManager.Notification("Unable to delete\n" + path);
				return;
			}
			UnityEngine.Debug.Log("Deleted " + path);
		}
	}
}
