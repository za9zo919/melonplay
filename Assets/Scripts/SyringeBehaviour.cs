using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public abstract class SyringeBehaviour : BloodContainer, Messages.IShot, Messages.IExitShot, Messages.IOnFragmentHit, Messages.IBreak, Messages.IUse, Messages.ILodged, Messages.IDislodged
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003C_003Ec__DisplayClass21_0
	{
		public BloodContainer other;
	}

	[CompilerGenerated]
	private sealed class _003C_003CShot_003Eg__WaitAFrame_007C24_0_003Ed : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SyringeBehaviour _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003C_003CShot_003Eg__WaitAFrame_007C24_0_003Ed(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			SyringeBehaviour syringeBehaviour = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = new WaitForSeconds(0.05f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				syringeBehaviour.BreakSyringe();
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	public bool Finite;

	public bool CanToggleInfinite = true;

	public PressureDirection PressureMode;

	public bool NewlySpawned = true;

	[SkipSerialisation]
	public float TransferRate = 0.01f;

	private SpriteRenderer spriteRenderer;

	[SkipSerialisation]
	public HashSet<BloodContainer> pushTargets = new HashSet<BloodContainer>();

	private Liquid spawnLiquid;

	private MaterialPropertyBlock materialProperty;

	public override Vector2 Limits => new Vector2(0f, 1.4f);

	public override PressureDirection Pressure => PressureMode;

	public override bool AllowsOverflow => false;

	protected virtual void Awake()
	{
		materialProperty = new MaterialPropertyBlock();
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.GetPropertyBlock(materialProperty);
	}

	protected virtual void Start()
	{
		AddButtons();
		if (GetLiquidID() != null)
		{
			spawnLiquid = Liquid.GetLiquid(GetLiquidID());
			if (NewlySpawned)
			{
				AddLiquid(spawnLiquid, Limits.y);
			}
		}
		NewlySpawned = false;
	}

	protected void AddButtons()
	{
		List<ContextMenuButton> buttons = GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons;
		buttons.Add(new ContextMenuButton(() => Pressure != 0 && Finite, "setToPush", "Set to push", "Set syringe to push mode", delegate
		{
			PressureMode = PressureDirection.Push;
		}));
		buttons.Add(new ContextMenuButton(() => Pressure != PressureDirection.Pull && Finite, "setToPull", "Set to pull", "Set syringe to pull mode", delegate
		{
			PressureMode = PressureDirection.Pull;
		}));
		buttons.Add(new ContextMenuButton(() => Pressure != PressureDirection.None && Finite, "setToIdle", "Set to idle", "Set syringe to idle mode", delegate
		{
			PressureMode = PressureDirection.None;
		}));
		buttons.Add(new ContextMenuButton(() => CanToggleInfinite, "toggleInifniteSyringe", () => (!Finite) ? "Disable infinite source" : "Enable infinite source", "Toggle syringe infinite", delegate
		{
			Finite = !Finite;
			PressureMode = PressureDirection.Push;
		}));
	}

	public virtual void Use(ActivationPropagation a)
	{
		switch (a.Channel)
		{
		default:
		{
			PressureDirection pressureDirection = PressureMode = ((PressureMode == PressureDirection.Push) ? PressureDirection.Pull : PressureDirection.Push);
			break;
		}
		case 1:
			PressureMode = PressureDirection.Push;
			break;
		case 2:
			if (Finite)
			{
				PressureMode = PressureDirection.Pull;
			}
			break;
		}
	}

	public virtual void Lodged(Stabbing stabbing)
	{
		if ((bool)stabbing.victim && stabbing.victim.TryGetComponent(out BloodContainer component))
		{
			pushTargets.Add(component);
		}
	}

	public virtual void Dislodged(PhysicalBehaviour.Penetration penetration)
	{
		if (penetration != null && (bool)penetration.Victim && penetration.Victim.TryGetComponent(out BloodContainer component))
		{
			pushTargets.Remove(component);
		}
	}

	protected virtual void FixedUpdate()
	{
		if (!Finite && GetLiquidID() != null)
		{
			AddLiquid(spawnLiquid, Limits.y - GetAmount(spawnLiquid));
		}
		foreach (BloodContainer pushTarget in pushTargets)
		{
			_003C_003Ec__DisplayClass21_0 _003C_003Ec__DisplayClass21_ = default(_003C_003Ec__DisplayClass21_0);
			_003C_003Ec__DisplayClass21_.other = pushTarget;
			if ((bool)_003C_003Ec__DisplayClass21_.other)
			{
				BloodWireBehaviour.AveragePressure(Time.fixedDeltaTime, this, _003C_003Ec__DisplayClass21_.other);
				if (!Finite || MeasuredPressure > _003C_003Ec__DisplayClass21_.other.MeasuredPressure)
				{
					_003CFixedUpdate_003Eg__push_007C21_1(ref _003C_003Ec__DisplayClass21_);
				}
				else if (Finite)
				{
					_003CFixedUpdate_003Eg__pull_007C21_0(ref _003C_003Ec__DisplayClass21_);
				}
			}
		}
	}

	public abstract string GetLiquidID();

	public virtual void ExitShot(Shot shot)
	{
		BreakSyringe();
	}

	public virtual void Shot(Shot shot)
	{
		StartCoroutine(_003CShot_003Eg__WaitAFrame_007C24_0());
	}

	public virtual void Break(Vector2 velocity)
	{
		BreakSyringe();
	}

	public virtual void OnFragmentHit(float force)
	{
		BreakSyringe();
	}

	protected virtual void BreakSyringe()
	{
		if (base.TotalLiquidAmount > float.Epsilon && LiquidDistribution.Count > 0)
		{
			SyringeExplosionBehaviour component = UnityEngine.Object.Instantiate(Resources.Load<GameObject>("Prefabs/SyringeExplosion"), base.transform.position, Quaternion.identity).GetComponent<SyringeExplosionBehaviour>();
			component.Colour = GetComputedColor();
			component.Liquids = LiquidDistribution.Keys;
			component.Amount = base.TotalLiquidAmount / (float)LiquidDistribution.Count;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	protected virtual void OnWillRenderObject()
	{
		materialProperty.SetColor(ShaderProperties.Get("_LiquidColour"), GetColor());
		switch (PressureMode)
		{
		case PressureDirection.Push:
			materialProperty.SetFloat(ShaderProperties.Get("_Direction"), 1f);
			break;
		case PressureDirection.Pull:
			materialProperty.SetFloat(ShaderProperties.Get("_Direction"), -1f);
			break;
		default:
			materialProperty.SetFloat(ShaderProperties.Get("_Direction"), 0f);
			break;
		}
		spriteRenderer.SetPropertyBlock(materialProperty);
	}

	private Color GetColor()
	{
		Color computedColor = GetComputedColor();
		computedColor.a = Mathf.Clamp01(ScaledLiquidAmount);
		return computedColor;
	}

	[CompilerGenerated]
	private void _003CFixedUpdate_003Eg__pull_007C21_0(ref _003C_003Ec__DisplayClass21_0 P_0)
	{
		if (!(P_0.other.TotalLiquidAmount <= P_0.other.LowerLimit) && !(base.TotalLiquidAmount >= base.UpperLimit))
		{
			P_0.other.TransferTo(TransferRate, this);
		}
	}

	[CompilerGenerated]
	private void _003CFixedUpdate_003Eg__push_007C21_1(ref _003C_003Ec__DisplayClass21_0 P_0)
	{
		if (base.TotalLiquidAmount <= base.LowerLimit || P_0.other.TotalLiquidAmount >= P_0.other.UpperLimit)
		{
			return;
		}
		if (GetLiquidID() != null)
		{
			CirculationBehaviour circulationBehaviour = P_0.other as CirculationBehaviour;
			if ((object)circulationBehaviour != null)
			{
				if (circulationBehaviour.GetAmount(spawnLiquid) < 0.5f)
				{
					TransferTo(TransferRate, P_0.other);
				}
			}
			else
			{
				TransferTo(TransferRate, P_0.other);
			}
		}
		else
		{
			TransferTo(TransferRate, P_0.other);
		}
	}

	[CompilerGenerated]
	private IEnumerator _003CShot_003Eg__WaitAFrame_007C24_0()
	{
		yield return new WaitForSeconds(0.05f);
		BreakSyringe();
	}
}
