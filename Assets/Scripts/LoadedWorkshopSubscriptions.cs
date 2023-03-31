using Steamworks.Ugc;
using System.Collections.Generic;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct LoadedWorkshopSubscriptions
{
	public static List<Item> All = new List<Item>();

	public static List<Item> Mods = new List<Item>();

	public static List<Item> Contraptions = new List<Item>();
}
