using System.Runtime.CompilerServices;
using UnityEngine;

public class ConnectedNodeBehaviour : MonoBehaviour, Messages.IOnBeforeSerialise
{
	public bool IsRoot;

	public int Value;

	[SkipSerialisation]
	public ConnectedNodeBehaviour[] Connections;

	public bool[] SerialisableConnectedNodes;

	public bool ShouldLoadSerialisableConnections;

	[SkipSerialisation]
	public bool IsConnectedToRoot
	{
		get;
		private set;
	} = true;


	private void Awake()
	{
		NodeController.Nodes.Add(this);
	}

	private void Start()
	{
		if (!ShouldLoadSerialisableConnections || SerialisableConnectedNodes == null)
		{
			return;
		}
		for (int i = 0; i < Connections.Length; i++)
		{
			if (!SerialisableConnectedNodes[i])
			{
				Connections[i] = null;
			}
		}
	}

	private void SetToNull(ConnectedNodeBehaviour otherNode)
	{
		int num = 0;
		while (true)
		{
			if (num < Connections.Length)
			{
				if (Connections[num] == otherNode)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		Connections[num] = null;
	}

	public void DisconnectFrom(ConnectedNodeBehaviour otherNode)
	{
		otherNode.SetToNull(this);
		SetToNull(otherNode);
	}

	public void DisconnectFromEverything()
	{
		for (int i = 0; i < Connections.Length; i++)
		{
			ConnectedNodeBehaviour connectedNodeBehaviour = Connections[i];
			if ((bool)connectedNodeBehaviour)
			{
				connectedNodeBehaviour.SetToNull(this);
			}
		}
		for (int j = 0; j < Connections.Length; j++)
		{
			Connections[j] = null;
		}
	}

	public void ResetValue()
	{
		IsConnectedToRoot = false;
		Value = (IsRoot ? 1000000 : 0);
	}

	public void RootPropagation()
	{
		if (IsRoot)
		{
			_003CRootPropagation_003Eg__propagateValue_007C15_0(this);
		}
	}

	public bool IsConnectedTo(ConnectedNodeBehaviour other)
	{
		if (other == null)
		{
			return false;
		}
		for (int i = 0; i < Connections.Length; i++)
		{
			ConnectedNodeBehaviour connectedNodeBehaviour = Connections[i];
			if ((bool)connectedNodeBehaviour && connectedNodeBehaviour == other)
			{
				return true;
			}
		}
		return false;
	}

	private void OnDestroy()
	{
		DisconnectFromEverything();
		NodeController.Nodes.Remove(this);
	}

	public void OnBeforeSerialise()
	{
		ShouldLoadSerialisableConnections = true;
		SerialisableConnectedNodes = new bool[Connections.Length];
		for (int i = 0; i < Connections.Length; i++)
		{
			SerialisableConnectedNodes[i] = (Connections[i] != null);
		}
	}

	[CompilerGenerated]
	private static void _003CRootPropagation_003Eg__propagateValue_007C15_0(ConnectedNodeBehaviour me)
	{
		me.IsConnectedToRoot = (me.IsRoot || me.Value > 0);
		for (int i = 0; i < me.Connections.Length; i++)
		{
			ConnectedNodeBehaviour connectedNodeBehaviour = me.Connections[i];
			if ((bool)connectedNodeBehaviour && connectedNodeBehaviour.Value < me.Value)
			{
				connectedNodeBehaviour.Value = me.Value - 1;
				_003CRootPropagation_003Eg__propagateValue_007C15_0(connectedNodeBehaviour);
			}
		}
	}
}
