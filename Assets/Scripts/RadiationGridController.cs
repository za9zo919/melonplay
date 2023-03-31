using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class RadiationGridController : MonoBehaviour
{
	public class Cell
	{
		public float PreviousValue;

		public float Value;

		public float Velocity;
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003C_003Ec__DisplayClass11_0
	{
		public Cell cell;
	}

	public float GridSize = 0.2f;

	public float VelocityRetainment = 0.99f;

	public float ValueDropRate = 0.4f;

	public float ValueTransferRate = 0.3f;

	[Space]
	public Gradient VisualisationGradient;

	public float VisualisationMin = -1f;

	public float VisualisationMax = 1f;

	private ConcurrentDictionary<Vector2Int, Cell> grid = new ConcurrentDictionary<Vector2Int, Cell>();

	private void Awake()
	{
		grid = new ConcurrentDictionary<Vector2Int, Cell>();
	}

	private void Start()
	{
		for (int i = 0; i < 64; i++)
		{
			for (int j = 0; j < 64; j++)
			{
				SetCell(new Vector2Int(j, i), 0f);
			}
		}
	}

	public void UpdateGrid()
	{
		foreach (KeyValuePair<Vector2Int, Cell> item in grid)
		{
			item.Value.PreviousValue = item.Value.Value;
		}
		foreach (KeyValuePair<Vector2Int, Cell> item2 in grid)
		{
			Vector2Int key = item2.Key;
			_003C_003Ec__DisplayClass11_0 _003C_003Ec__DisplayClass11_ = default(_003C_003Ec__DisplayClass11_0);
			_003C_003Ec__DisplayClass11_.cell = item2.Value;
			_003C_003Ec__DisplayClass11_.cell.Velocity += (0f - _003C_003Ec__DisplayClass11_.cell.PreviousValue) * ValueDropRate;
			_003C_003Ec__DisplayClass11_.cell.Velocity += _003CUpdateGrid_003Eg__getDelta_007C11_0(key.x - 1, key.y - 1, ref _003C_003Ec__DisplayClass11_);
			_003C_003Ec__DisplayClass11_.cell.Velocity += _003CUpdateGrid_003Eg__getDelta_007C11_0(key.x, key.y - 1, ref _003C_003Ec__DisplayClass11_);
			_003C_003Ec__DisplayClass11_.cell.Velocity += _003CUpdateGrid_003Eg__getDelta_007C11_0(key.x + 1, key.y - 1, ref _003C_003Ec__DisplayClass11_);
			_003C_003Ec__DisplayClass11_.cell.Velocity += _003CUpdateGrid_003Eg__getDelta_007C11_0(key.x - 1, key.y, ref _003C_003Ec__DisplayClass11_);
			_003C_003Ec__DisplayClass11_.cell.Velocity += _003CUpdateGrid_003Eg__getDelta_007C11_0(key.x + 1, key.y, ref _003C_003Ec__DisplayClass11_);
			_003C_003Ec__DisplayClass11_.cell.Velocity += _003CUpdateGrid_003Eg__getDelta_007C11_0(key.x - 1, key.y + 1, ref _003C_003Ec__DisplayClass11_);
			_003C_003Ec__DisplayClass11_.cell.Velocity += _003CUpdateGrid_003Eg__getDelta_007C11_0(key.x, key.y + 1, ref _003C_003Ec__DisplayClass11_);
			_003C_003Ec__DisplayClass11_.cell.Velocity += _003CUpdateGrid_003Eg__getDelta_007C11_0(key.x + 1, key.y + 1, ref _003C_003Ec__DisplayClass11_);
			_003C_003Ec__DisplayClass11_.cell.Velocity *= VelocityRetainment;
			_003C_003Ec__DisplayClass11_.cell.Value += _003C_003Ec__DisplayClass11_.cell.Velocity;
		}
	}

	private void FixedUpdate()
	{
		if (Input.GetMouseButton(0))
		{
			SetCell(WorldToGridPos(Global.main.MousePosition), 1f);
		}
		UpdateGrid();
	}

	public void SetCell(Vector2Int id, float value)
	{
		if (!grid.TryGetValue(id, out Cell value2))
		{
			value2 = new Cell();
			grid.TryAdd(id, value2);
		}
		float value3 = value2.Value;
		value2.Value = value;
		value2.Velocity = value - value3;
	}

	public float GetCell(Vector2Int id, float fallback = 0f)
	{
		if (!grid.TryGetValue(id, out Cell value))
		{
			return fallback;
		}
		return value.PreviousValue;
	}

	public Vector2Int WorldToGridPos(Vector2 world)
	{
		return new Vector2Int((int)(world.x / GridSize), (int)(world.y / GridSize));
	}

	[CompilerGenerated]
	private float _003CUpdateGrid_003Eg__getDelta_007C11_0(int x, int y, ref _003C_003Ec__DisplayClass11_0 P_2)
	{
		return (GetCell(new Vector2Int(x, y)) - P_2.cell.PreviousValue) * ValueTransferRate;
	}
}
