using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct GameVersion
{
	public const string Version = "1.25 preview 3";

	public static int GetDifference(string a, string b)
	{
		return ParseBuildIndex(a) - ParseBuildIndex(b);
	}

	public static bool IsOlderThan(string a, string b)
	{
		return GetDifference(a, b) < 0;
	}

	public static bool IsAtLeast(string a, string b)
	{
		return GetDifference(a, b) >= 0;
	}

	public static bool IsNewerThan(string a, string b)
	{
		return GetDifference(a, b) > 0;
	}

	public static int ParseBuildIndex(string input)
	{
		input = input.ToLower().Trim().Normalize();
		int num = input.IndexOf("preview");
		if (num == -1)
		{
			num = input.IndexOf("beta");
		}
		bool num2 = num != -1;
		Version version = System.Version.Parse(num2 ? input.Substring(0, num) : input);
		int num3 = _003CParseBuildIndex_003Eg__transformNegative_007C5_0(version.Major) * 10000 + _003CParseBuildIndex_003Eg__transformNegative_007C5_0(version.Minor) * 1000 + _003CParseBuildIndex_003Eg__transformNegative_007C5_0(version.Build) * 100;
		if (num2)
		{
			string text = input.Substring(num);
			int result = 1;
			if (result > 99)
			{
				return int.MaxValue;
			}
			int num4 = -1;
			for (int i = 0; i < text.Length; i++)
			{
				if (char.IsNumber(text[i]))
				{
					num4 = i;
					break;
				}
			}
			if (num4 != -1 && (!int.TryParse(text.Substring(num4), out result) || result < 1))
			{
				return int.MaxValue;
			}
			num3 += result;
		}
		else
		{
			num3 += 99;
		}
		if (num3 != -1)
		{
			return num3;
		}
		return int.MaxValue;
	}

	[CompilerGenerated]
	private static int _003CParseBuildIndex_003Eg__transformNegative_007C5_0(int v)
	{
		return Mathf.Max(0, v);
	}
}
