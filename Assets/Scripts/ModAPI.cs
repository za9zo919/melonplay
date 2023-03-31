using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct ModAPI
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass52_0
	{
		public string name;

		internal bool _003CFindSpawnable_003Eb__1(SpawnableAsset i)
		{
			return i.name == name;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass53_0
	{
		public string name;

		internal bool _003CFindCategory_003Eb__0(Category c)
		{
			if (!(c.name == name))
			{
				if (c.HadPriorName)
				{
					return c.PriorName == name;
				}
				return false;
			}
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass65_0
	{
		public string uniqueId;

		internal bool _003CRegisterInput_003Eb__0(ActionRepresentation u)
		{
			return u.Codename == uniqueId;
		}
	}

	public const float PixelSize = 0.0285714287f;

	internal static bool metaDataIsValid = false;

	internal static List<ActionRepresentation> ModdedControlInputEntries = new List<ActionRepresentation>();

	private static ModMetaData metadata;

	public static ModMetaData Metadata
	{
		get
		{
			if (!metaDataIsValid)
			{
				throw new InvalidOperationException("Metadata can only be retrieved in the AfterSpawn, Main, or OnLoad function.");
			}
			return metadata;
		}
		internal set
		{
			metadata = value;
		}
	}

	public static ModDebugDrawer Draw
	{
		get;
		internal set;
	}

	public static event EventHandler<WireBehaviour> OnWireCreated;

	public static event EventHandler<PinBehaviour> OnPinCreated;

	public static event EventHandler<LinkDeviceBehaviour> OnLinkCreated;

	public static event EventHandler<UserSpawnEventArgs> OnItemSpawned;

	public static event EventHandler<UserSpawnEventArgs> OnItemRemoved;

	public static event EventHandler<PhysicalBehaviour> OnItemSelected;

	public static event EventHandler<PhysicalBehaviour> OnItemDeselected;

	public static event EventHandler<PhysicalBehaviour> OnItemActivated;

	public static event EventHandler<FirearmBehaviour> OnGunShot;

	public static event EventHandler<PersonBehaviour> OnDeath;

	internal static void ClearEvents()
	{
		ModAPI.OnWireCreated = null;
		ModAPI.OnPinCreated = null;
		ModAPI.OnLinkCreated = null;
		ModAPI.OnItemSpawned = null;
		ModAPI.OnItemRemoved = null;
		ModAPI.OnItemSelected = null;
		ModAPI.OnItemDeselected = null;
		ModAPI.OnItemActivated = null;
		ModAPI.OnGunShot = null;
		ModAPI.OnDeath = null;
	}

	internal static void InvokeWireCreated(object sender, WireBehaviour args)
	{
		ModAPI.OnWireCreated?.Invoke(sender, args);
	}

	internal static void InvokePinCreated(object sender, PinBehaviour args)
	{
		ModAPI.OnPinCreated?.Invoke(sender, args);
	}

	internal static void InvokeLinkCreated(object sender, LinkDeviceBehaviour args)
	{
		ModAPI.OnLinkCreated?.Invoke(sender, args);
	}

	internal static void InvokeItemSpawned(object sender, UserSpawnEventArgs args)
	{
		ModAPI.OnItemSpawned?.Invoke(sender, args);
	}

	internal static void InvokeItemRemoved(object sender, UserSpawnEventArgs args)
	{
		ModAPI.OnItemRemoved?.Invoke(sender, args);
	}

	internal static void InvokeItemSelected(object sender, PhysicalBehaviour args)
	{
		ModAPI.OnItemSelected?.Invoke(sender, args);
	}

	internal static void InvokeItemDeselected(object sender, PhysicalBehaviour args)
	{
		ModAPI.OnItemDeselected?.Invoke(sender, args);
	}

	internal static void InvokeItemActivated(object sender, PhysicalBehaviour args)
	{
		ModAPI.OnItemActivated?.Invoke(sender, args);
	}

	internal static void InvokeGunShot(object sender, FirearmBehaviour args)
	{
		ModAPI.OnGunShot?.Invoke(sender, args);
	}

	internal static void InvokeDeath(object sender, PersonBehaviour args)
	{
		ModAPI.OnDeath?.Invoke(sender, args);
	}

	public static SpawnableAsset FindSpawnable(string name)
	{
		SpawnableAsset spawnableAsset = _003CFindSpawnable_003Eg__find_007C52_0(name);
		if (spawnableAsset == null)
		{
			return null;
		}
		if (metaDataIsValid && spawnableAsset.MigrationEvents != null && spawnableAsset.MigrationEvents.Length != 0)
		{
			MigrationEvent[] migrationEvents = spawnableAsset.MigrationEvents;
			foreach (MigrationEvent migrationEvent in migrationEvents)
			{
				if (migrationEvent != null && migrationEvent.IsApplicable(Metadata.GameVersion))
				{
					return migrationEvent.ToSpawnInstead;
				}
			}
		}
		return spawnableAsset;
	}

	public static Category FindCategory(string name)
	{
		return ModGlobals.MainCatalog.Categories.FirstOrDefault((Category c) => (!(c.name == name)) ? (c.HadPriorName && c.PriorName == name) : true);
	}

	public static Sprite LoadSprite(string path, float scale = 1f, bool pixelated = true)
	{
		if (!metaDataIsValid)
		{
			throw new InvalidOperationException("Invalid use of path-dependent function! LoadSprite must be called in the AfterSpawn, Main, or OnLoad function.");
		}
		string text = Path.Combine(Metadata.MetaLocation, path);
		if (ModResourceCache.TryGet(text, out Sprite obj))
		{
			return obj;
		}
		if (!File.Exists(text))
		{
			UnityEngine.Debug.LogErrorFormat("{0}: Failed to load sprite at \"{1}\"", Metadata.Name, path);
			return null;
		}
		Sprite sprite = Utils.LoadSprite(text, (!pixelated) ? FilterMode.Bilinear : FilterMode.Point, scale * 35f, markNonReadable: false);
		ModResourceCache.Cache(text, sprite);
		return sprite;
	}

	public static Texture2D LoadTexture(string path, bool pixelated = true)
	{
		if (!metaDataIsValid)
		{
			throw new InvalidOperationException("Invalid use of path-dependent function! LoadTexture must be called in the AfterSpawn, Main, or OnLoad function.");
		}
		string text = Path.Combine(Metadata.MetaLocation, path);
		if (ModResourceCache.TryGet(text, out Texture2D obj))
		{
			return obj;
		}
		if (!File.Exists(text))
		{
			UnityEngine.Debug.LogErrorFormat("{0}: Failed to load texture at \"{1}\"", Metadata.Name, path);
			return null;
		}
		Texture2D texture2D = Utils.LoadTexture(text, (!pixelated) ? FilterMode.Bilinear : FilterMode.Point, markNonReadable: false);
		ModResourceCache.Cache(text, texture2D);
		return texture2D;
	}

	public static AudioClip LoadSound(string path)
	{
		if (!metaDataIsValid)
		{
			throw new InvalidOperationException("Invalid use of path-dependent function! LoadSound must be called in the AfterSpawn, Main, or OnLoad function.");
		}
		string text = Path.Combine(Metadata.MetaLocation, path);
		if (ModResourceCache.TryGet(text, out AudioClip obj))
		{
			return obj;
		}
		AudioClip audioClip = Utils.FileToAudioClip(text);
		ModResourceCache.Cache(text, audioClip);
		return audioClip;
	}

	public static Cartridge FindCartridge(string name)
	{
		if (name == "30-06 Springfield")
		{
			name = "30-06";
		}
		Cartridge cartridge = Resources.Load<Cartridge>("Calibers/" + name);
		if (cartridge == null)
		{
			return null;
		}
		return UnityEngine.Object.Instantiate(cartridge);
	}

	public static PhysicalProperties FindPhysicalProperties(string name)
	{
		PhysicalProperties physicalProperties = Resources.Load<PhysicalProperties>("PhysicalProperties/" + name);
		if (physicalProperties == null)
		{
			return null;
		}
		return UnityEngine.Object.Instantiate(physicalProperties);
	}

	public static Material FindMaterial(string name)
	{
		if (ModGlobals.LoadedMaterials.TryGetValue(name, out Material value))
		{
			return value;
		}
		return null;
	}

	public static GameObject CreateParticleEffect(string name, Vector2 position)
	{
		if (ModGlobals.LoadedParticleEffects.TryGetValue(name, out GameObject value))
		{
			if (value.CompareTag("Poolable"))
			{
				return PoolGenerator.Instance.RequestPrefab(value, position);
			}
			return UnityEngine.Object.Instantiate(value, position, Quaternion.identity);
		}
		return null;
	}

	public static void Register(Modification modification)
	{
		if (!metaDataIsValid)
		{
			throw new InvalidOperationException("Item modifications can only be registered in the AfterSpawn, Main, or OnLoad function.");
		}
		ModificationManager.Modifications.Add(modification, Metadata);
		UnityEngine.Debug.Log(modification.NameOverride + " registered as item modification");
	}

	public static void Register<T>() where T : MonoBehaviour
	{
		ModificationManager.BackgroundScripts.Add(typeof(T));
		UnityEngine.Debug.Log(typeof(T).Name + " registered as background behaviour");
	}

	public static void RegisterTool<T>(string name, string description, Sprite icon, string parent = null) where T : ToolBehaviour
	{
		RegisterCustomTool<T>(name, description, icon, parent, ToolLibrary.Instance.Tools);
		UnityEngine.Debug.Log(typeof(T).Name + " registered as tool");
	}

	public static void RegisterPower<T>(string name, string description, Sprite icon, string parent = null) where T : ToolBehaviour
	{
		RegisterCustomTool<T>(name, description, icon, parent, ToolLibrary.Instance.Powers);
		UnityEngine.Debug.Log(typeof(T).Name + " registered as power");
	}

	public static void RegisterInput(string name, string uniqueId, KeyCode defaultKey)
	{
		if (!ModdedControlInputEntries.Any((ActionRepresentation u) => u.Codename == uniqueId))
		{
			ModdedControlInputEntries.Add(new ActionRepresentation
			{
				Name = name,
				Codename = uniqueId,
				Category = ActionRepresentation.ActionCategory.Modded,
				DefaultKey = defaultKey,
				Universe = ActionRepresentation.ActionUniverse.Game
			});
			UnityEngine.Debug.Log("Registered input for " + name + ":" + uniqueId);
			ControlSchemeEditorBehaviour.shouldReinitialiseForModdedEntry = true;
		}
		else
		{
			UnityEngine.Debug.Log("Could not register input for " + name + ":" + uniqueId + ", it is a duplicate");
		}
	}

	private static void RegisterCustomTool<T>(string name, string description, Sprite icon, string parent, List<ToolLibrary.Tool> coll) where T : ToolBehaviour
	{
		if (!ToolLibrary.Instance)
		{
			UnityEngine.Debug.LogError("You can't register custom tools/powers before a map is loaded");
			return;
		}
		coll.Add(new ToolLibrary.Tool(name, description, icon, typeof(T).Name, parent));
		ToolLibrary.ModdedTypes.Add(typeof(T));
		ToolLibrary.Instance.BroadcastCollectionChange();
	}

	public static void Notify(object message)
	{
		NotificationControllerBehaviour.Show(message.ToString());
	}

	public static GameObject CreatePhysicalObject(string name, Sprite sprite)
	{
		GameObject gameObject = new GameObject(name, typeof(SpriteRenderer), typeof(AudioSourceTimeScaleBehaviour), typeof(Optout));
		gameObject.layer = LayerMask.NameToLayer("Objects");
		gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
		gameObject.AddComponent<BoxCollider2D>();
		gameObject.AddComponent<Rigidbody2D>();
		PhysicalBehaviour physicalBehaviour = gameObject.AddComponent<PhysicalBehaviour>();
		physicalBehaviour.Properties = FindPhysicalProperties("Metal");
		physicalBehaviour.SpawnSpawnParticles = false;
		gameObject.AddComponent<AudioSourceTimeScaleBehaviour>();
		physicalBehaviour.OverrideShotSounds = Array.Empty<AudioClip>();
		physicalBehaviour.OverrideImpactSounds = Array.Empty<AudioClip>();
		return gameObject;
	}

	public static LightSprite CreateLight(Transform parent, Color color, float radius = 5f, float brightness = 1.5f)
	{
		LightSprite component = UnityEngine.Object.Instantiate(Resources.Load<GameObject>("Prefabs/ModLightPrefab"), parent).GetComponent<LightSprite>();
		component.transform.localPosition = Vector3.zero;
		component.Color = color;
		component.Radius = radius;
		component.Brightness = brightness;
		return component;
	}

	public static void KeepExtraObjects()
	{
		if (metaDataIsValid)
		{
			CatalogBehaviour.ShouldRemoveToRemoveWhenModded = false;
		}
		else
		{
			UnityEngine.Debug.LogWarningFormat("You cannot call {0} outside the AfterSpawn delegate.", "KeepExtraObjects");
		}
	}

	public static void RegisterLiquid(string id, Liquid liquidInstance)
	{
		if (Global.allowedToRegisterExternalLiquids)
		{
			Liquid.Register(id, liquidInstance);
			return;
		}
		throw new InvalidOperationException("You can only register a liquid after or during map load.");
	}

	[CompilerGenerated]
	private static SpawnableAsset _003CFindSpawnable_003Eg__find_007C52_0(string name)
	{
		if ((bool)CatalogBehaviour.Main)
		{
			return CatalogBehaviour.Main.GetSpawnable(name);
		}
		return Resources.LoadAll<SpawnableAsset>("SpawnableAssets").FirstOrDefault((SpawnableAsset i) => i.name == name);
	}
}
