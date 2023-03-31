using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class MapEditorContextMenuBehaviour : MonoBehaviour
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003C_003Ec__DisplayClass10_0
	{
		public MapEditorContextMenuBehaviour _003C_003E4__this;

		public RectTransform rectTransform;

		public CanvasScaler canvasScaler;
	}

	public Button DeleteButton;

	public Button CopyButton;

	public Button PasteButton;

	public Button PropertiesButton;

	private List<MapEditorSelectable> selectablesWhenShown = new List<MapEditorSelectable>();

	private List<MapEditorObjectBehaviour> selectedObjects = new List<MapEditorObjectBehaviour>();

	public bool IsShown => base.gameObject.activeSelf;

	private void Start()
	{
		DeleteButton.onClick.AddListener(delegate
		{
			DeleteAction();
		});
		Hide();
	}

	private void Update()
	{
		if (IsShown)
		{
			bool interactable = selectedObjects.Count != 0;
			DeleteButton.interactable = interactable;
			CopyButton.interactable = interactable;
			PasteButton.interactable = false;
		}
	}

	public void Show(Vector2 screenPosition)
	{
		_003C_003Ec__DisplayClass10_0 _003C_003Ec__DisplayClass10_ = default(_003C_003Ec__DisplayClass10_0);
		_003C_003Ec__DisplayClass10_._003C_003E4__this = this;
		_003C_003Ec__DisplayClass10_.rectTransform = GetComponent<RectTransform>();
		_003C_003Ec__DisplayClass10_.canvasScaler = UnityEngine.Object.FindObjectOfType<CanvasScaler>();
		base.transform.position = Vector3.zero;
		_003C_003Ec__DisplayClass10_.rectTransform.ForceUpdateRectTransforms();
		LayoutRebuilder.ForceRebuildLayoutImmediate(_003C_003Ec__DisplayClass10_.rectTransform);
		_003C_003Ec__DisplayClass10_.rectTransform.ForceUpdateRectTransforms();
		_003CShow_003Eg__clampToScreen_007C10_0(screenPosition, ref _003C_003Ec__DisplayClass10_);
		selectablesWhenShown.Clear();
		selectablesWhenShown.AddRange(MapEditorSelectionManager.Instance.CurrentlySelected);
		selectedObjects.Clear();
		foreach (MapEditorSelectable item in selectablesWhenShown)
		{
			if ((bool)item && item.TryGetComponent(out MapEditorObjectBehaviour component))
			{
				selectedObjects.Add(component);
			}
		}
		base.gameObject.SetActive(value: true);
	}

	public void DeleteAction()
	{
		foreach (MapEditorObjectBehaviour selectedObject in selectedObjects)
		{
			selectedObject.Delete();
		}
		Hide();
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
	}

	[CompilerGenerated]
	private void _003CShow_003Eg__clampToScreen_007C10_0(Vector2 screenPosition, ref _003C_003Ec__DisplayClass10_0 P_1)
	{
		base.transform.position = screenPosition;
		Vector2 vector = P_1.rectTransform.sizeDelta * 2f / (P_1.canvasScaler.referenceResolution.x / Mathf.Lerp(Screen.width, Screen.height, P_1.canvasScaler.matchWidthOrHeight));
		screenPosition.x = Mathf.Clamp(screenPosition.x, 0f, (float)Screen.width - vector.x);
		screenPosition.y = Mathf.Clamp(screenPosition.y, vector.y, Screen.height);
		base.transform.position = screenPosition;
	}
}
