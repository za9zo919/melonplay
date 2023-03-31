using System.Collections.Generic;
using UnityEngine;

public class PoolGenerator : MonoBehaviour
{
	public uint PoolSize = 256u;

	public float PoolInactivityThreshold = 300f;

	private readonly Dictionary<int, ObjectPoolBehaviour> pools = new Dictionary<int, ObjectPoolBehaviour>();

	public static PoolGenerator Instance
	{
		get;
		private set;
	}

	private void Awake()
	{
		Instance = this;
	}

	public GameObject RequestPrefab(GameObject originalPrefab, Vector2 position)
	{
		int instanceID = originalPrefab.GetInstanceID();
		if (pools.TryGetValue(instanceID, out ObjectPoolBehaviour value))
		{
			return value.Request(position);
		}
		value = new GameObject(originalPrefab.name + " pool").AddComponent<ObjectPoolBehaviour>();
		value.MaxPoolSize = PoolSize;
		value.Prefab = originalPrefab;
		pools.Add(instanceID, value);
		return value.Request(position);
	}
}
