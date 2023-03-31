using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnergySwordMotionBlur : MonoBehaviour
{
	[Serializable]
	public struct Node
	{
		public float Life;

		public Vector3 A;

		public Vector3 B;
	}

	[SkipSerialisation]
	public MeshRenderer MeshRenderer;

	[SkipSerialisation]
	public MeshFilter MeshFilter;

	[SkipSerialisation]
	public float Life = 1f;

	[SkipSerialisation]
	public float MinDistance = 0.1f;

	[SkipSerialisation]
	public Rigidbody2D Rigidbody;

	[SkipSerialisation]
	public Transform A;

	[SkipSerialisation]
	public Transform B;

	[SkipSerialisation]
	public Gradient ColorOverMesh;

	private List<Node> nodes = new List<Node>();

	private Mesh mesh;

	private readonly List<Vector3> vertices = new List<Vector3>();

	private readonly List<int> indices = new List<int>();

	private readonly List<Color> colors = new List<Color>();

	private void Awake()
	{
		mesh = new Mesh();
		mesh.indexFormat = IndexFormat.UInt32;
		mesh.MarkDynamic();
		MeshFilter.mesh = mesh;
	}

	private void OnEnable()
	{
		mesh.Clear();
		nodes.Clear();
	}

	private void Update()
	{
		base.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
		base.transform.localScale = Vector3.one;
		float num = MinDistance * MinDistance;
		Vector3 a = (A.position + B.position) / 2f;
		if (nodes.Count > 0)
		{
			Node node = nodes[nodes.Count - 1];
			if ((a - (node.A + node.B) / 2f).sqrMagnitude >= num)
			{
				CreateNode();
			}
		}
		else
		{
			CreateNode();
		}
		UpdateNodes();
		UpdateMesh();
	}

	private void CreateNode()
	{
		if (nodes.Count < 128)
		{
			(Vector2 a, Vector2 b) currentBladePos = GetCurrentBladePos();
			Vector2 item = currentBladePos.a;
			Vector2 item2 = currentBladePos.b;
			nodes.Add(new Node
			{
				A = item,
				B = item2,
				Life = Life
			});
		}
	}

	private (Vector2 a, Vector2 b) GetCurrentBladePos()
	{
		return (A.position, B.position);
	}

	private void UpdateNodes()
	{
		float deltaTime = Time.deltaTime;
		for (int num = nodes.Count - 1; num >= 0; num--)
		{
			Node node = nodes[num];
			if (node.Life <= 0f)
			{
				nodes.RemoveAt(num);
			}
			else
			{
				node.Life -= deltaTime;
				nodes[num] = node;
			}
		}
	}

	private void UpdateMesh()
	{
		if (nodes.Count <= 1)
		{
			MeshRenderer.enabled = false;
			return;
		}
		MeshRenderer.enabled = true;
		colors.Clear();
		vertices.Clear();
		int count = nodes.Count;
		for (int i = 0; i < count; i++)
		{
			float num = ((float)i + 1f) / (float)count;
			Node node = nodes[i];
			vertices.Add(node.A);
			vertices.Add(node.B);
			Color item = (i == 0) ? Color.clear : ColorOverMesh.Evaluate(1f - num);
			colors.Add(item);
			colors.Add(item);
		}
		(Vector2, Vector2) currentBladePos = GetCurrentBladePos();
		vertices.Add(currentBladePos.Item1);
		vertices.Add(currentBladePos.Item2);
		Color item2 = ColorOverMesh.Evaluate(0f);
		colors.Add(item2);
		colors.Add(item2);
		indices.Clear();
		int num2 = 0;
		while (indices.Count < (vertices.Count - 2) * 3)
		{
			indices.Add(num2 + 1);
			indices.Add(num2 + 2);
			indices.Add(num2);
			indices.Add(num2 + 1);
			indices.Add(num2 + 2);
			indices.Add(num2 + 3);
			num2 += 2;
		}
		mesh.Clear();
		mesh.SetVertices(vertices);
		mesh.SetColors(colors);
		mesh.SetIndices(indices, MeshTopology.Triangles, 0);
	}

	private void OnDestroy()
	{
		UnityEngine.Object.Destroy(mesh);
	}
}
