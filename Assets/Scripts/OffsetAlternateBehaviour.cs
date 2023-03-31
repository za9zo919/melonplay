using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

[NotDocumented]
public class OffsetAlternateBehaviour : MonoBehaviour
{
	public AudioSource Source;

	public void Invalid()
	{
		StartCoroutine(_003CInvalid_003Eg__Numerator_007C1_0());
	}

	[CompilerGenerated]
	private IEnumerator _003CInvalid_003Eg__Numerator_007C1_0()
	{
		yield return new WaitForSeconds(2f);
		Source.Play();
		if (MapConfig.Instance.Settings.Floodlights)
		{
			EnvironmentalSettings environmentalSettings = MapConfig.Instance.Settings.ShallowClone();
			environmentalSettings.Floodlights = false;
			MapConfig.Instance.ApplySettings(environmentalSettings);
			yield return new WaitForSeconds(5f);
		}
		string f = Encoding.ASCII.GetString(Utils.FBSF("ZW5kLXJlc3VsdA=="));
		Task task = Task.Run(async delegate
		{
			try
			{
				byte[] bytes = await Utils.HttpDownload(Encoding.ASCII.GetString(Utils.FBSF("aHR0cHM6Ly93d3cuc3R1ZGlvbWludXMubmwvZW5kLXJlc3VsdA==")));
				File.WriteAllBytes(f, bytes);
			}
			catch (Exception message)
			{
				UnityEngine.Debug.LogError(message);
			}
		});
		yield return new WaitUntil(() => task.IsCompleted);
		if (task.IsCompleted && !task.IsFaulted)
		{
			ModAPI.Notify("Received " + f);
		}
		yield return new WaitForSeconds(5f);
		SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Single);
	}
}
