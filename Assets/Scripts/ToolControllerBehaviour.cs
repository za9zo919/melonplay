using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ToolControllerBehaviour : MonoBehaviour
{
	public class ToolChangeEventArgs : EventArgs
	{
		public int Index;

		public ToolChangeEventArgs(int index)
		{
			Index = index;
		}
	}

	public ToolBehaviour CurrentTool;

	public ContextMenuBehaviour contextMenu;

	public LayerMask SelectionLayer;

	private bool isCurrentlyHolding;

	private PhysicalBehaviour currentlyHovering;

	private Type[] toolImplementations;

	private int parentCycleIndex;

	private int childCycleIndex;

	private int childCount;

	private bool isSelecting;

	private Vector2 selectionDragStart;

	private readonly SelectionController selectionController = new SelectionController();

	private readonly Collider2D[] buffer = new Collider2D[4];

	private static string[] toolNamesForKeyInput;

	public event EventHandler<ToolChangeEventArgs> ToolChanged;

	private void Start()
	{
		SetImplementationArray();
		ToolLibrary.OnCollectionChange.AddListener(SetImplementationArray);
		SetTool(0);
		if (toolNamesForKeyInput == null)
		{
			toolNamesForKeyInput = new string[11];
			for (int i = 0; i < 11; i++)
			{
				toolNamesForKeyInput[i] = "tool" + i.ToString();
			}
		}
	}

	private void SetImplementationArray()
	{
		Type[] types = Assembly.GetAssembly(GetType()).GetTypes();
		Type toolType = typeof(ToolBehaviour);
		toolImplementations = (from t in types
			where toolType.IsAssignableFrom(t)
			select t).Concat(ToolLibrary.ModdedTypes).ToArray();
	}

	public void SetTool(int index, ToolTab tab = ToolTab.Tools)
	{
		if ((bool)CurrentTool)
		{
			CurrentTool.OnToolUnchosen();
			isCurrentlyHolding = false;
			CurrentTool.OnDeselect();
			CurrentTool.ActiveSingleSelected = null;
		}
		List<ToolLibrary.Tool> relevantCollection = GetRelevantCollection(tab);
		if (index < 0 || index >= relevantCollection.Count)
		{
			UnityEngine.Debug.LogError("Attempt to set out of bounds tool: " + index.ToString());
			return;
		}
		ToolLibrary.Tool entry = relevantCollection[index];
		Type type = toolImplementations.FirstOrDefault((Type f) => f.Name == entry.Type);
		if (type == null)
		{
			UnityEngine.Debug.LogError("Attempt to set invalid tool: " + entry.Type);
			return;
		}
		Component component = GetComponents(type).FirstOrDefault((Component f) => f.GetType().Name == entry.Type);
		if (!component)
		{
			CurrentTool = (base.gameObject.AddComponent(type) as ToolBehaviour);
		}
		else
		{
			CurrentTool = (component as ToolBehaviour);
		}
		if (CurrentTool == null)
		{
			UnityEngine.Debug.LogError("Attempt to set invalid tool: " + entry.Type);
			return;
		}
		CurrentTool.Rigidbody = GetComponent<Rigidbody2D>();
		CurrentTool.OnToolChosen();
		this.ToolChanged?.Invoke(this, new ToolChangeEventArgs(index));
	}

	private static List<ToolLibrary.Tool> GetRelevantCollection(ToolTab tab)
	{
		if (tab != 0)
		{
			return ToolLibrary.Instance.Powers;
		}
		return ToolLibrary.Instance.Tools;
	}

	public void SetToolByTypeName(string typeName)
	{
		for (int i = 0; i < ToolLibrary.Instance.Tools.Count; i++)
		{
			if (typeName == ToolLibrary.Instance.Tools[i].Type)
			{
				SetTool(i);
				return;
			}
		}
		int num = 0;
		while (true)
		{
			if (num < ToolLibrary.Instance.Powers.Count)
			{
				if (typeName == ToolLibrary.Instance.Powers[num].Type)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		SetTool(num, ToolTab.Powers);
	}

	private void Update()
	{
		currentlyHovering = null;
		if (!Global.main.GetPausedMenu() && !DialogBox.IsAnyDialogboxOpen && !Global.ActiveUiBlock)
		{
			HandleToolSelectionInput();
			HandleIndirectInteraction();
			DetermineHovering();
			HandleTools();
			HandleContextMenu();
			UpdateSelectionBox();
		}
	}

	private void FixedUpdate()
	{
		if (InputSystem.Held("drag"))
		{
			CurrentTool.OnFixedHold();
		}
	}

	private void HandleIndirectInteraction()
	{
		if (InputSystem.Down("activateDirect") && !CurrentTool.ActiveSingleSelected)
		{
			PhysicalBehaviour currentlyUnderMouse = SelectionController.Main.CurrentlyUnderMouse;
			if ((bool)currentlyUnderMouse)
			{
				ActivationPropagation activationPropagation = new ActivationPropagation(direct: true, 0);
				Utils.Activations.SendOnce(activationPropagation, currentlyUnderMouse);
				currentlyUnderMouse.BroadcastMessage("Use", activationPropagation, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	private void HandleToolSelectionInput()
	{
		List<ToolLibrary.Tool> relevantCollection = GetRelevantCollection(ToolWheelBehaviour.Instance.CurrentTab);
		int num = 1;
		int num2 = 0;
		ToolLibrary.Tool tool;
		while (true)
		{
			if (num2 >= relevantCollection.Count)
			{
				return;
			}
			tool = relevantCollection[num2];
			if (string.IsNullOrEmpty(tool.Parent))
			{
				if (num >= 0 && num < toolNamesForKeyInput.Length)
				{
					string name = toolNamesForKeyInput[num];
					if (InputSystem.Has(name) && InputSystem.Down(name))
					{
						if (parentCycleIndex != num || childCount <= 0)
						{
							break;
						}
						childCycleIndex++;
						if (childCycleIndex >= childCount)
						{
							childCycleIndex = -1;
							SetToolByTypeName(tool.Type);
							_003CHandleToolSelectionInput_003Eg__playUiSound_007C25_0();
							NotificationControllerBehaviour.Show(tool.Name + " selected");
							return;
						}
						int num3 = childCount - 1;
						for (int i = 0; i < relevantCollection.Count; i++)
						{
							ToolLibrary.Tool tool2 = relevantCollection[i];
							if (tool2.Parent == tool.Name)
							{
								if (num3 == childCycleIndex)
								{
									SetToolByTypeName(tool2.Type);
									_003CHandleToolSelectionInput_003Eg__playUiSound_007C25_0();
									NotificationControllerBehaviour.Show(tool2.Name + " selected");
									return;
								}
								num3--;
							}
						}
					}
				}
				num++;
			}
			num2++;
		}
		SetToolByTypeName(tool.Type);
		childCycleIndex = -1;
		parentCycleIndex = num;
		childCount = 0;
		for (int j = 0; j < relevantCollection.Count; j++)
		{
			if (relevantCollection[j].Parent == tool.Name)
			{
				childCount++;
			}
		}
		_003CHandleToolSelectionInput_003Eg__playUiSound_007C25_0();
		NotificationControllerBehaviour.Show(tool.Name + " selected");
	}

	private void HandleContextMenu()
	{
		if (InputSystem.Down("context"))
		{
			contextMenu.Show(UnityEngine.Input.mousePosition);
		}
	}

	private void HandleTools()
	{
		if (InputSystem.Down("drag") && !Global.main.UILock)
		{
			if ((bool)currentlyHovering)
			{
				if (InputSystem.Held("fast") && selectionController.SelectedObjects.Contains(currentlyHovering))
				{
					selectionController.Deselect(currentlyHovering);
					if (currentlyHovering == CurrentTool.ActiveSingleSelected)
					{
						CurrentTool.OnDeselect();
						if (selectionController.SelectedObjects.Count > 0)
						{
							CurrentTool.ActiveSingleSelected = selectionController.SelectedObjects[0];
						}
					}
				}
				else
				{
					selectionController.Select(currentlyHovering, InputSystem.Held("fast") || selectionController.SelectedObjects.Contains(currentlyHovering));
					if ((bool)CurrentTool.ActiveSingleSelected)
					{
						CurrentTool.OnDeselect();
					}
					CurrentTool.ActiveSingleSelected = currentlyHovering;
				}
			}
			else
			{
				EscapeAndDeselect();
				if (!CurrentTool.UsesEmptyDrag)
				{
					StartSelectionDrag();
				}
			}
			isCurrentlyHolding = true;
			CurrentTool.OnSelect();
		}
		if (InputSystem.Down("context") && (bool)currentlyHovering)
		{
			selectionController.Select(currentlyHovering, InputSystem.Held("fast") || selectionController.SelectedObjects.Contains(currentlyHovering));
		}
		if (InputSystem.Held("drag") && isCurrentlyHolding)
		{
			CurrentTool.OnHold();
		}
		if (InputSystem.Up("drag") && (bool)Global.main && (bool)Global.main.eventSystem)
		{
			GameObject currentSelectedGameObject = Global.main.eventSystem.currentSelectedGameObject;
			if (!currentSelectedGameObject || !currentSelectedGameObject.transform.IsChildOf(contextMenu.transform))
			{
				EscapeAndDeselect();
			}
			StopSelectionDrag();
		}
	}

	private void DetermineHovering()
	{
		currentlyHovering = null;
		Collider2D collider2D = Physics2D.OverlapPoint(Global.main.MousePosition, SelectionLayer, -0.9f, 0.9f);
		if (!collider2D)
		{
			selectionController.SetHovering(null);
			return;
		}
		if (!collider2D.TryGetComponent(out PhysicalBehaviour component))
		{
			selectionController.SetHovering(null);
			return;
		}
		if (currentlyHovering != component && component.Selectable)
		{
			selectionController.SetHovering(component);
		}
		currentlyHovering = component;
	}

	private void EscapeAndDeselect()
	{
		CurrentTool.OnDeselect();
		CurrentTool.ActiveSingleSelected = null;
		isCurrentlyHolding = false;
		contextMenu.Hide();
		if (!selectionController.SelectedObjects.Contains(currentlyHovering) && !InputSystem.Held("fast"))
		{
			selectionController.ClearSelection();
		}
	}

	private void UpdateSelectionBox()
	{
		if (!isSelecting)
		{
			return;
		}
		Vector2 vector = (Vector2)Input.mousePosition - selectionDragStart;
		Vector3 position = SelectionBoxBehaviour.Main.transform.position;
		Vector2 zero = Vector2.zero;
		if (vector.sqrMagnitude > 200f)
		{
			SelectionBoxBehaviour.Main.Show();
			if (vector.x < 0f)
			{
				position.x = UnityEngine.Input.mousePosition.x;
				zero.x = Mathf.Abs(position.x - selectionDragStart.x);
			}
			else
			{
				position.x = selectionDragStart.x;
				zero.x = Mathf.Abs(vector.x);
			}
			if (vector.y > 0f)
			{
				position.y = UnityEngine.Input.mousePosition.y;
				zero.y = Mathf.Abs(position.y - selectionDragStart.y);
			}
			else
			{
				position.y = selectionDragStart.y;
				zero.y = Mathf.Abs(vector.y);
			}
			SelectionBoxBehaviour.Main.transform.position = position;
			float num = Mathf.Lerp((float)Screen.width / Global.main.CanvasScaler.referenceResolution.x, (float)Screen.height / Global.main.CanvasScaler.referenceResolution.y, Global.main.CanvasScaler.matchWidthOrHeight);
			zero.x /= num;
			zero.y /= num;
			SelectionBoxBehaviour.Main.SetSize(zero.x, zero.y);
			Vector3 vector2 = Global.main.camera.ScreenToWorldPoint(selectionDragStart);
			SelectionBoxBehaviour.Main.SetSizeDisplay((Global.main.MousePosition.x - vector2.x) * (220f / 267f), (Global.main.MousePosition.y - vector2.y) * (220f / 267f));
		}
		else
		{
			SelectionBoxBehaviour.Main.Hide();
		}
	}

	private void StartSelectionDrag()
	{
		if (!isSelecting)
		{
			isSelecting = true;
			selectionDragStart = UnityEngine.Input.mousePosition;
			SelectionBoxBehaviour.Main.transform.position = selectionDragStart;
		}
	}

	private void StopSelectionDrag()
	{
		if (!isSelecting)
		{
			return;
		}
		isSelecting = false;
		SelectionBoxBehaviour.Main.Hide();
		Vector3 vector = Global.main.camera.ScreenToWorldPoint(selectionDragStart);
		if (!((selectionDragStart - (Vector2)Input.mousePosition).sqrMagnitude < 200f))
		{
			UnityEngine.Debug.DrawLine(vector, Global.main.MousePosition, Color.green, 5f);
			if (!InputSystem.Held("fast"))
			{
				selectionController.ClearSelection();
			}
			Collider2D[] source = Physics2D.OverlapAreaAll(vector, Global.main.MousePosition, SelectionLayer);
			selectionController.Select(from c in source
				where Global.main.PhysicalObjectsInWorldByTransform.ContainsKey(c.transform)
				select c.GetComponent<PhysicalBehaviour>(), InputSystem.Held("fast"));
		}
	}

	[CompilerGenerated]
	private static void _003CHandleToolSelectionInput_003Eg__playUiSound_007C25_0()
	{
		UISoundBehaviour.Main.Scroll();
	}
}
