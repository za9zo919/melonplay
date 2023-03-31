using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ModGlobals : MonoBehaviour
{
	public Material[] Materials;

	public GameObject[] ParticleEffects;

	public CatalogData Catalog;

	private static bool alreadyRan;

	internal static Dictionary<string, Material> LoadedMaterials = new Dictionary<string, Material>();

	internal static Dictionary<string, GameObject> LoadedParticleEffects = new Dictionary<string, GameObject>();

	internal static CatalogData MainCatalog;

	private void Awake()
	{
		if (!alreadyRan)
		{
			alreadyRan = true;
			MainCatalog = Catalog;
			_003CAwake_003Eg__injectInDictionary_007C4_0(Materials, LoadedMaterials);
			_003CAwake_003Eg__injectInDictionary_007C4_0(ParticleEffects, LoadedParticleEffects);
		}
	}

	[CompilerGenerated]
	private static void _003CAwake_003Eg__injectInDictionary_007C4_0<T>(T[] obj, Dictionary<string, T> dict) where T : Object
	{
		foreach (T val in obj)
		{
			dict.Add(val.name, val);
		}
	}
}
