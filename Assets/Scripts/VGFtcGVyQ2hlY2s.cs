using System;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;

[NotDocumented]
public class VGFtcGVyQ2hlY2s : MonoBehaviour
{
	public static bool VGFtcGVyZWRXaXRo()
	{
		string b = File.ReadAllText("People Playground_Data\\Managed\\tcmdh");
		string a;
		using (FileStream inputStream = File.OpenRead("People Playground_Data\\Managed\\Assembly-CSharp.dll"))
		{
			using (MD5 mD = MD5.Create())
			{
				a = BitConverter.ToString(mD.ComputeHash(inputStream));
			}
		}
		return a == b;
	}
}
