using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ParticleMachineBehaviour : MonoBehaviour, Messages.IUse
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public Func<bool> getValue;

		public string label;

		public Action<bool> setValue;

		public ParticleMachineBehaviour _003C_003E4__this;

		internal string _003CStart_003Eb__7()
		{
			return (getValue() ? "Disable " : "Enable ") + label;
		}

		internal void _003CStart_003Eb__8()
		{
			setValue(!getValue());
			_003C_003E4__this.UpdateActivation();
		}
	}

	public bool Activated;

	public bool EmitSmoke;

	public bool EmitFire;

	public bool EmitElectricity;

	[SkipSerialisation]
	public ParticleSystem SmokeParticles;

	[SkipSerialisation]
	public ParticleSystem FireParticles;

	[SkipSerialisation]
	public ParticleSystem ElectricityParticles;

	private PhysicalBehaviour phys;

	private void Awake()
	{
		phys = GetComponent<PhysicalBehaviour>();
	}

	private void Start()
	{
		_003CStart_003Eg__addToggleButton_007C9_6("smoke", () => EmitSmoke, delegate(bool v)
		{
			EmitSmoke = v;
		});
		_003CStart_003Eg__addToggleButton_007C9_6("fire", () => EmitFire, delegate(bool v)
		{
			EmitFire = v;
		});
		_003CStart_003Eg__addToggleButton_007C9_6("electricity", () => EmitElectricity, delegate(bool v)
		{
			EmitElectricity = v;
		});
		UpdateActivation();
	}

	public void UpdateActivation()
	{
		_003CUpdateActivation_003Eg__setPlaying_007C10_0(SmokeParticles, EmitSmoke);
		_003CUpdateActivation_003Eg__setPlaying_007C10_0(FireParticles, EmitFire);
		_003CUpdateActivation_003Eg__setPlaying_007C10_0(ElectricityParticles, EmitElectricity);
	}

	public void Use(ActivationPropagation activation)
	{
		Activated = !Activated;
		UpdateActivation();
	}

	private void OnEnable()
	{
		UpdateActivation();
	}

	private void OnDisable()
	{
		UpdateActivation();
	}

	[CompilerGenerated]
	private void _003CStart_003Eg__addToggleButton_007C9_6(string label, Func<bool> getValue, Action<bool> setValue)
	{
		phys.ContextMenuOptions.Buttons.Add(new ContextMenuButton("pm" + label, () => (getValue() ? "Disable " : "Enable ") + label, "Toggle " + label, delegate
		{
			setValue(!getValue());
			UpdateActivation();
		}));
	}

	[CompilerGenerated]
	private void _003CUpdateActivation_003Eg__setPlaying_007C10_0(ParticleSystem ps, bool play)
	{
		if ((base.enabled && Activated) & play)
		{
			ps.Play();
		}
		else
		{
			ps.Stop();
		}
	}
}
