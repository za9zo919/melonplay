using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct ContraptionOutlineSerialiser
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<GameObject, PhysicalBehaviour> _003C_003E9__3_0;

		public static Func<PhysicalBehaviour, bool> _003C_003E9__3_1;

		internal PhysicalBehaviour _003CSaveOutline_003Eb__3_0(GameObject a)
		{
			return a.GetComponent<PhysicalBehaviour>();
		}

		internal bool _003CSaveOutline_003Eb__3_1(PhysicalBehaviour a)
		{
			return a;
		}
	}

	public const string OutlineExtension = ".outline";

	public static ContraptionOutline GenerateOutline(IEnumerable<PhysicalBehaviour> physicalBehaviours, Vector3 center)
	{
		RotatedRectangle[] array = new RotatedRectangle[physicalBehaviours.Count()];
		ContraptionOutline result = new ContraptionOutline(array);
		int num = 0;
		foreach (PhysicalBehaviour physicalBehaviour in physicalBehaviours)
		{
			if ((bool)physicalBehaviour)
			{
				Vector3 lossyScale = physicalBehaviour.transform.lossyScale;
				Vector3 size = physicalBehaviour.spriteRenderer.sprite.bounds.size;
				Vector2 size2 = new Vector2(size.x * lossyScale.x, size.y * lossyScale.y);
				Vector3 v = physicalBehaviour.transform.position - center;
				array[num] = new RotatedRectangle(v, size2, v, physicalBehaviour.transform.eulerAngles.z);
				num++;
			}
		}
		return result;
	}

	public static ContraptionOutline LoadOutline(string path)
	{
		List<RotatedRectangle> list = new List<RotatedRectangle>();
		using (FileStream fileStream = new FileStream(path, FileMode.Open))
		{
			using (StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8))
			{
				try
				{
					int num = 0;
					while (!streamReader.EndOfStream)
					{
						num++;
						string text = streamReader.ReadLine();
						if (num != 1)
						{
							string[] array = text.Replace(',', '.').Split(' ');
							if (array.Length < 5)
							{
								throw new Exception($"Malformed at line {num}. Expected at least 5 segments, got {array.Length}: {text}");
							}
							float x = float.Parse(array[0], CultureInfo.InvariantCulture);
							float y = float.Parse(array[1], CultureInfo.InvariantCulture);
							float x2 = float.Parse(array[2], CultureInfo.InvariantCulture);
							float y2 = float.Parse(array[3], CultureInfo.InvariantCulture);
							float angleDegrees = float.Parse(array[4], CultureInfo.InvariantCulture);
							RotatedRectangle item = new RotatedRectangle(new Vector2(x, y), new Vector2(x2, y2), new Vector2(x, y), angleDegrees);
							list.Add(item);
						}
					}
				}
				catch (Exception ex)
				{
					UnityEngine.Debug.LogErrorFormat("Failed to deserialise outline: {0}", ex);
				}
				finally
				{
					streamReader.Close();
					streamReader.Dispose();
					fileStream.Dispose();
				}
				return new ContraptionOutline(list.ToArray());
			}
		}
	}

	public static void SaveOutline(string saveName, GameObject[] gameObjects, Vector3 center)
	{
		ContraptionOutline contraptionOutline = GenerateOutline(from a in gameObjects
			select a.GetComponent<PhysicalBehaviour>() into a
			where a
			select a, center);
		string path = "Contraptions/" + saveName + "/";
		if (!Directory.Exists("Contraptions/"))
		{
			Directory.CreateDirectory("Contraptions/");
		}
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}
		using (FileStream fileStream = new FileStream("Contraptions/" + saveName + "/" + saveName + ".outline", FileMode.Create))
		{
			using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
			{
				try
				{
					streamWriter.WriteLine("1.25 preview 3");
					RotatedRectangle[] rectangles = contraptionOutline.Rectangles;
					foreach (RotatedRectangle rotatedRectangle in rectangles)
					{
						streamWriter.Write(_003CSaveOutline_003Eg__round_007C3_2(rotatedRectangle.Center.x).ToString(CultureInfo.InvariantCulture));
						streamWriter.Write(' ');
						streamWriter.Write(_003CSaveOutline_003Eg__round_007C3_2(rotatedRectangle.Center.y).ToString(CultureInfo.InvariantCulture));
						streamWriter.Write(' ');
						streamWriter.Write(_003CSaveOutline_003Eg__round_007C3_2(rotatedRectangle.Size.x).ToString(CultureInfo.InvariantCulture));
						streamWriter.Write(' ');
						streamWriter.Write(_003CSaveOutline_003Eg__round_007C3_2(rotatedRectangle.Size.y).ToString(CultureInfo.InvariantCulture));
						streamWriter.Write(' ');
						streamWriter.Write(_003CSaveOutline_003Eg__round_007C3_2(rotatedRectangle.AngleDegrees).ToString(CultureInfo.InvariantCulture));
						streamWriter.Write('\n');
					}
				}
				catch (Exception ex)
				{
					UnityEngine.Debug.LogErrorFormat("Failed to serialise outline: {0}", ex);
				}
				finally
				{
					streamWriter.Close();
					streamWriter.Dispose();
					fileStream.Dispose();
				}
			}
		}
	}

	[CompilerGenerated]
	private static float _003CSaveOutline_003Eg__round_007C3_2(float x)
	{
		return Mathf.Round(x * 100f) / 100f;
	}
}
