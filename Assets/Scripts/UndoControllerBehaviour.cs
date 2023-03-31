using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UndoControllerBehaviour : MonoBehaviour
{
	public List<IUndoableAction> history = new List<IUndoableAction>();

	private static int currentHistoryPosition = -1;

	private static UndoControllerBehaviour main;

	private void Awake()
	{
		main = this;
		currentHistoryPosition = -1;
	}

	public static void RegisterAction(IUndoableAction action)
	{
		main.history.Insert(currentHistoryPosition + 1, action);
		currentHistoryPosition++;
	}

	public static void DeregisterAction(IUndoableAction action)
	{
		if (main.history.Contains(action))
		{
			if (main.history.IndexOf(action) <= currentHistoryPosition)
			{
				currentHistoryPosition--;
			}
			main.history.Remove(action);
		}
	}

	public static bool FindRelevantAction(UnityEngine.Object o, out IUndoableAction result)
	{
		result = (from c in main.history
			where c.IsRelatedTo(o)
			select c).FirstOrDefault();
		return result != null;
	}

	public static void Undo()
	{
		if (currentHistoryPosition != -1)
		{
			main.history[currentHistoryPosition].Undo();
			currentHistoryPosition--;
		}
	}

	public static void ClearHistory()
	{
		currentHistoryPosition = -1;
		main.history.Clear();
	}

	private void Update()
	{
		if (!Global.main.GetPausedMenu() && !DialogBox.IsAnyDialogboxOpen && !Global.ActiveUiBlock && InputSystem.Up("undo"))
		{
			Undo();
		}
	}
}
