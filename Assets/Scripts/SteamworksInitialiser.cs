using Steamworks;
using System;
using UnityEngine;

public class SteamworksInitialiser : MonoBehaviour
{
	public static bool IsInitialised;

	public const int AppID = 1118200;

	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		UnityEngine.Object.DontDestroyOnLoad(this);
		if (!IsInitialised)
		{
			try
			{
				SteamClient.Init(1118200u);
				SteamClient.RestartAppIfNecessary(1118200u);
				IsInitialised = true;
				UnityEngine.Debug.Log("Steamworks initialised");
				UnityEngine.Debug.Log("Steam login: " + SteamClient.IsLoggedOn.ToString());
			}
			catch (Exception message)
			{
				IsInitialised = false;
				UnityEngine.Debug.LogWarning(message);
			}
		}
	}

	private void Update()
	{
		SteamClient.RunCallbacks();
	}

	private void OnDestroy()
	{
		SteamClient.Shutdown();
	}
}
