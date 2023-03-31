using System;
using System.Runtime.InteropServices;
using UnityEngine;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct WireSnapController
{
	public const int DirectionCount = 8;

	public static Vector2 GetTransformedWorldEndPoint(Vector2 worldEndPos, Vector2 worldStartPos)
	{
		if (!InputSystem.Held("snap"))
		{
			return worldEndPos;
		}
		Vector2 a = worldEndPos - worldStartPos;
		float magnitude = a.magnitude;
		if (magnitude < 0.001f)
		{
			return worldEndPos;
		}
		Vector2 vector = a / magnitude;
		float f = Utils.Snap(Mathf.Atan2(vector.y, vector.x), (float)Math.PI / 4f);
		float x = worldStartPos.x + Mathf.Cos(f) * magnitude;
		float y = worldStartPos.y + Mathf.Sin(f) * magnitude;
		return new Vector2(x, y);
	}
}
