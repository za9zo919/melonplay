using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct ItemPersistence
{
	private const string p = "People Playground_Data\\persistence0";

	private static readonly string Key = Utils.GetMD5AsString(Environment.MachineName);

	private static string Cache = string.Empty;

	private static string[] cachedLines;

	internal static void Add(string name)
	{
		if (!Has(name))
		{
			Cache = Cache + Utils.GetMD5AsString(name + Key) + "\n";
		}
	}

	internal static bool Has(string name)
	{
		if (cachedLines.Length < 2)
		{
			return false;
		}
		if (!cachedLines[0].StartsWith(Key))
		{
			return false;
		}
		string mD5AsString = Utils.GetMD5AsString(name + Key);
		for (int i = 1; i < cachedLines.Length; i++)
		{
			if (cachedLines[i].StartsWith(mD5AsString))
			{
				return true;
			}
		}
		return false;
	}

	internal static void Serialise()
	{
		File.WriteAllText("People Playground_Data\\persistence0", Cache, Encoding.ASCII);
	}

	internal static void Deserialise()
	{
		if (!File.Exists("People Playground_Data\\persistence0"))
		{
			File.WriteAllText("People Playground_Data\\persistence0", Key + "\n", Encoding.ASCII);
		}
		Cache = File.ReadAllText("People Playground_Data\\persistence0");
		cachedLines = Cache.Split(new string[3]
		{
			Environment.NewLine,
			"\n",
			"\r"
		}, StringSplitOptions.None);
	}
}
