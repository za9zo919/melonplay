using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[Serializable]
public class ContraptionMetaData
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003C_003Ec__DisplayClass22_0
	{
		public long byteCount;
	}

	public const string FileExtension = ".json";

	public string Name;

	public string DisplayName;

	public string Version;

	public ulong PublishedFileID;

	public string CreatorUGCIdentity;

	[NonSerialized]
	public List<string> Tags = new List<string>();

	public string PathToMetadata;

	[NonSerialized]
	public string PathToDataFile;

	[NonSerialized]
	public string PathToThumbnail;

	[NonSerialized]
	public string PathToOutlineFile;

	public List<RequiredMod> RequiredMods = new List<RequiredMod>();

	public bool IsCurrentVersion => Version == "1.25 preview 3";

	public bool IsWorkshopItem => PublishedFileID != 0;

	public bool RequiresMods
	{
		get
		{
			if (RequiredMods != null)
			{
				return RequiredMods.Count > 0;
			}
			return false;
		}
	}

	public ContraptionMetaData()
	{
	}

	public ContraptionMetaData(string name)
	{
		Name = name;
		DisplayName = Name;
		Version = "1.25 preview 3";
	}

	public static string GetPath(string name)
	{
		string text = "Contraptions/" + name + ".json";
		if (File.Exists(text))
		{
			return text;
		}
		return "Contraptions/" + name + "/" + name + ".json";
	}

	public bool IsLegacyStructure()
	{
		return File.Exists("Contraptions/" + Name + ".json");
	}

	public long GetSizeOnDisk()
	{
		_003C_003Ec__DisplayClass22_0 _003C_003Ec__DisplayClass22_ = default(_003C_003Ec__DisplayClass22_0);
		_003C_003Ec__DisplayClass22_.byteCount = 0L;
		_003CGetSizeOnDisk_003Eg__count_007C22_0(PathToMetadata, ref _003C_003Ec__DisplayClass22_);
		_003CGetSizeOnDisk_003Eg__count_007C22_0(PathToDataFile, ref _003C_003Ec__DisplayClass22_);
		_003CGetSizeOnDisk_003Eg__count_007C22_0(PathToThumbnail, ref _003C_003Ec__DisplayClass22_);
		_003CGetSizeOnDisk_003Eg__count_007C22_0(PathToOutlineFile, ref _003C_003Ec__DisplayClass22_);
		return _003C_003Ec__DisplayClass22_.byteCount;
	}

	[CompilerGenerated]
	private static void _003CGetSizeOnDisk_003Eg__count_007C22_0(string path, ref _003C_003Ec__DisplayClass22_0 P_1)
	{
		if (File.Exists(path))
		{
			FileInfo fileInfo = new FileInfo(path);
			P_1.byteCount += fileInfo.Length;
		}
	}
}
