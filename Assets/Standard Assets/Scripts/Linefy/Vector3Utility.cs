using Linefy.Internal;
using UnityEngine;

namespace Linefy
{
	public static class Vector3Utility
	{
		public static Vector3 HermitePoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
		{
			return new Vector3(MathUtility.HermiteValue(p0.x, p1.x, p2.x, p3.x, t), MathUtility.HermiteValue(p0.y, p1.y, p2.y, p3.y, t), MathUtility.HermiteValue(p0.z, p1.z, p2.z, p3.z, t));
		}

		public static Vector3 HermiteInterpolate(Vector3 y0, Vector3 y1, Vector3 y2, Vector3 y3, float mu, float tension)
		{
			float num = mu * mu;
			float num2 = num * mu;
			Vector3 a = (y1 - y0) * (1f - tension) / 2f;
			a += (y2 - y1) * (1f - tension) / 2f;
			Vector3 a2 = (y2 - y1) * (1f - tension) / 2f;
			a2 += (y3 - y2) * (1f - tension) / 2f;
			float d = 2f * num2 - 3f * num + 1f;
			float d2 = num2 - 2f * num + mu;
			float d3 = num2 - num;
			float d4 = -2f * num2 + 3f * num;
			return d * y1 + d2 * a + d3 * a2 + d4 * y2;
		}
	}
}
