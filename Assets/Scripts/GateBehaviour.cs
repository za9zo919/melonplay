using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GateBehaviour : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Action<GateBehaviour, float> _003C_003E9__16_2;

		public static Action<GateBehaviour, float> _003C_003E9__16_3;

		internal void _003CStart_003Eb__16_2(GateBehaviour e, float v)
		{
			e.SetThreshold(v);
		}

		internal void _003CStart_003Eb__16_3(GateBehaviour e, float v)
		{
			e.MaxPower = v;
		}
	}

	[SkipSerialisation]
	public PhysicalBehaviour PhysicalBehaviour;

	[SkipSerialisation]
	public SpriteRenderer PowerLevelBar;

	[SkipSerialisation]
	public SpriteRenderer PassthroughLight;

	[SkipSerialisation]
	public SpriteRenderer Cursor;

	[HideInInspector]
	public bool Passthrough;

	[SkipSerialisation]
	public float CursorMaxDistance;

	[SkipSerialisation]
	public AudioClip Tick;

	[Tooltip("This value is here for compatibility reasons...")]
	public float Threshold;

	public float MaxPower = 100f;

	public float ThresholdPercentage = 50f;

	public bool DoubleTrigger;

	private Vector3 barSize;

	private Vector3 barStartPos;

	private Vector3 cursorStartPos;

	private const float Delta = 25f;

	private void Awake()
	{
		ThresholdPercentage = Threshold / 100f;
		cursorStartPos = Cursor.transform.localPosition;
		barStartPos = PowerLevelBar.transform.localPosition;
		barSize = PowerLevelBar.transform.localScale;
	}

	private void Start()
	{
		List<ContextMenuButton> buttons = PhysicalBehaviour.ContextMenuOptions.Buttons;
		ContextMenuButton[] obj = new ContextMenuButton[3]
		{
			new ContextMenuButton("setGateThreshold", "Set threshold", "Set gate threshold", delegate
			{
				Utils.OpenFloatInputDialog(ThresholdPercentage * 100f, this, delegate(GateBehaviour e, float v)
				{
					e.SetThreshold(v);
				}, "Set the gate threshold", "Threshold as percentage");
			}),
			new ContextMenuButton("setGateMaxPower", "Set maximum power level", "Set maximum power level", delegate
			{
				Utils.OpenFloatInputDialog(MaxPower, this, delegate(GateBehaviour e, float v)
				{
					e.MaxPower = v;
				}, "Set the gate maximum power", "Maximum power");
			}),
			default(ContextMenuButton)
		};
		ContextMenuButton contextMenuButton = obj[2] = new ContextMenuButton("toggleGateTriggerBehaviour", () => (!DoubleTrigger) ? "Double trigger gate" : "Single trigger gate", "Toggle gate behaviour.", delegate
		{
			DoubleTrigger = !DoubleTrigger;
		})
		{
			LabelWhenMultipleAreSelected = "Toggle gate behaviour"
		};
		buttons.AddRange(obj);
	}

	private void SetThreshold(float v)
	{
		ThresholdPercentage = Mathf.Clamp(v, 0f, 100f) / 100f;
		if (base.enabled)
		{
			PhysicalBehaviour.PlayClipOnce(Tick);
		}
	}

	private void Update()
	{
		bool flag = PhysicalBehaviour.Charge / MaxPower >= ThresholdPercentage;
		PassthroughLight.enabled = flag;
		if (flag)
		{
			PhysicalBehaviour.ActivationPropagationDelay = 0.1f;
		}
		bool flag2 = flag && !Passthrough;
		bool flag3 = !flag && Passthrough;
		if (flag2 || (flag3 && DoubleTrigger))
		{
			for (int i = 0; i < ActivationPropagation.AllChannels.Length; i++)
			{
				ushort channel = ActivationPropagation.AllChannels[i];
				bool flag4 = PhysicalBehaviour.IsBeingUsedContinuously(channel);
				bool num = (flag2 && !flag3) & flag4;
				bool flag5 = (DoubleTrigger && flag3 && !flag2) & flag4;
				if (num | flag5)
				{
					_003CUpdate_003Eg__send_007C18_0(i);
				}
			}
		}
		Passthrough = flag;
		if (!Passthrough)
		{
			PhysicalBehaviour.ActivationPropagationDelay = -1f;
		}
	}

	private void OnWillRenderObject()
	{
		if (base.enabled)
		{
			float thresholdPercentage = ThresholdPercentage;
			Cursor.transform.localPosition = cursorStartPos + Vector3.right * SnapToPixels(CursorMaxDistance * thresholdPercentage);
			float num = Mathf.Clamp(PhysicalBehaviour.Charge, 0f, MaxPower) / MaxPower;
			num = SnapToPixels(num * barSize.x) / barSize.x;
			float x = num * barSize.x;
			PowerLevelBar.transform.localScale = new Vector3(x, barSize.y);
			PowerLevelBar.transform.localPosition = barStartPos - new Vector3(barSize.x / 2f * (1f - num), 0f);
		}
	}

	private float SnapToPixels(float v)
	{
		return Mathf.Round(v / 0.0285714287f) * 0.0285714287f;
	}

	private void OnEnable()
	{
		PowerLevelBar.enabled = true;
	}

	private void OnDisable()
	{
		PhysicalBehaviour.ActivationPropagationDelay = 0.1f;
		PowerLevelBar.enabled = false;
		PassthroughLight.enabled = false;
	}

	[CompilerGenerated]
	private void _003CUpdate_003Eg__send_007C18_0(int i)
	{
		BroadcastMessage("IsolatedActivation", new ActivationPropagation(base.transform.root, ActivationPropagation.AllChannels[i]));
	}
}
