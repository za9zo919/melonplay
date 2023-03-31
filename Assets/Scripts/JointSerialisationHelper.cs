using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

public class JointSerialisationHelper : MonoBehaviour, Messages.IOnAfterDeserialise
{
	[SkipSerialisation]
	public Joint2D Joint;

	[ReadOnly]
	public bool Broken;

	private void Start()
	{
		if (Broken)
		{
			UnityEngine.Object.Destroy(Joint);
		}
	}

	private void OnJointBreak2D(Joint2D joint)
	{
		if (joint == Joint)
		{
			Broken = true;
		}
	}

	public void OnAfterDeserialise(List<GameObject> gameObjects)
	{
		if (Broken)
		{
			UnityEngine.Object.Destroy(Joint);
		}
	}
}
