using UnityEngine;

public class LaserReceiverBehaviour : MonoBehaviour
{
	[SkipSerialisation]
	public SpriteRenderer Light;

	private float laserTime;

	private const float threshold = 0.1f;

	private void Awake()
	{
		ContinuousActivationBehaviour.Instance.OnContinuousUpdate.AddListener(OnContinuousUpdate);
	}

	private void OnContinuousUpdate(float dt)
	{
		if (laserTime > 0.1f && base.enabled)
		{
			for (int i = 0; i < ActivationPropagation.AllChannels.Length; i++)
			{
				ushort channel = ActivationPropagation.AllChannels[i];
				SendMessage("IsolatedContinuousActivation", new ActivationPropagation(base.transform.root, channel), SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	private void Update()
	{
		if (!Global.main.Paused && !Global.main.GetPausedMenu())
		{
			laserTime -= Time.deltaTime;
			laserTime = Mathf.Clamp01(laserTime);
			Light.enabled = (laserTime > 0.1f);
		}
	}

	private void Lasered()
	{
		if (laserTime < 0.1f && base.enabled)
		{
			for (int i = 0; i < ActivationPropagation.AllChannels.Length; i++)
			{
				ushort channel = ActivationPropagation.AllChannels[i];
				SendMessage("IsolatedActivation", new ActivationPropagation(base.transform.root, channel), SendMessageOptions.DontRequireReceiver);
			}
		}
		laserTime = 0.2f;
	}

	private void OnDestroy()
	{
		ContinuousActivationBehaviour.Instance.OnContinuousUpdate.RemoveListener(OnContinuousUpdate);
	}

	private void OnDisable()
	{
		Light.enabled = false;
	}
}
