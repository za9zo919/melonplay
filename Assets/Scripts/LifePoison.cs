using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

[Obsolete]
public class LifePoison : PoisonSpreadBehaviour
{
	[CompilerGenerated]
	private sealed class _003CHealBurn_003Ed__2 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LimbBehaviour limb;

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
		public _003CHealBurn_003Ed__2(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				limb.PhysicalBehaviour.Temperature = limb.BodyTemperature;
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (limb.PhysicalBehaviour.BurnProgress > 0.1f)
			{
				limb.PhysicalBehaviour.BurnProgress -= Time.deltaTime * 0.16f;
				_003C_003E2__current = new WaitForEndOfFrame();
				_003C_003E1__state = 1;
				return true;
			}
			limb.PhysicalBehaviour.BurnProgress = 0f;
			return false;
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

	[CompilerGenerated]
	private sealed class _003CHealAcidFlesh_003Ed__3 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LimbBehaviour limb;

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
		public _003CHealAcidFlesh_003Ed__3(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (limb.SkinMaterialHandler.AcidProgress > 0.1f)
			{
				limb.SkinMaterialHandler.AcidProgress -= Time.deltaTime * 0.8f;
				_003C_003E2__current = new WaitForEndOfFrame();
				_003C_003E1__state = 1;
				return true;
			}
			limb.SkinMaterialHandler.AcidProgress = 0f;
			return false;
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

	[CompilerGenerated]
	private sealed class _003CHealRottenFlesh_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LimbBehaviour limb;

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
		public _003CHealRottenFlesh_003Ed__4(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (limb.SkinMaterialHandler.RottenProgress > 0.1f)
			{
				limb.SkinMaterialHandler.RottenProgress -= Time.deltaTime * 0.8f;
				_003C_003E2__current = new WaitForEndOfFrame();
				_003C_003E1__state = 1;
				return true;
			}
			limb.SkinMaterialHandler.RottenProgress = 0f;
			return false;
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

	[CompilerGenerated]
	private sealed class _003CHealWounds_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LimbBehaviour limb;

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
		public _003CHealWounds_003Ed__5(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (((IEnumerable<Vector4>)limb.SkinMaterialHandler.damagePoints).Max((Func<Vector4, float>)_003CHealWounds_003Eg__intensity_007C5_0) > 0f)
			{
				for (int i = 0; i < limb.SkinMaterialHandler.damagePoints.Length; i++)
				{
					limb.SkinMaterialHandler.damagePoints[i].z -= Time.deltaTime * 0.5f;
				}
				limb.SkinMaterialHandler.Sync();
				_003C_003E2__current = new WaitForEndOfFrame();
				_003C_003E1__state = 1;
				return true;
			}
			return false;
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

	public override void Start()
	{
		StopAllCoroutines();
		GeneralHealing();
		StartCoroutine(HealBurn(Limb));
		StartCoroutine(HealWounds(Limb));
		StartCoroutine(HealRottenFlesh(Limb));
		StartCoroutine(HealAcidFlesh(Limb));
	}

	private void GeneralHealing()
	{
		Limb.HealBone();
		Limb.Health = Limb.InitialHealth;
		Limb.Numbness = 0f;
		Limb.CirculationBehaviour.HealBleeding();
		Limb.CirculationBehaviour.IsPump = Limb.CirculationBehaviour.WasInitiallyPumping;
		Limb.CirculationBehaviour.BloodFlow = 5f;
		Limb.CirculationBehaviour.AddLiquid(Limb.GetOriginalBloodType(), 5f);
		Limb.BruiseCount = 0;
		Limb.CirculationBehaviour.GunshotWoundCount = 0;
		Limb.CirculationBehaviour.StabWoundCount = 0;
		if (Limb.RoughClassification == LimbBehaviour.BodyPart.Head)
		{
			Limb.Person.Consciousness = 1f;
			Limb.Person.ShockLevel = 0f;
			Limb.Person.PainLevel = 0f;
			Limb.Person.OxygenLevel = 1f;
			Limb.Person.AdrenalineLevel = 1f;
		}
	}

	private IEnumerator HealBurn(LimbBehaviour limb)
	{
		limb.PhysicalBehaviour.Temperature = limb.BodyTemperature;
		while (limb.PhysicalBehaviour.BurnProgress > 0.1f)
		{
			limb.PhysicalBehaviour.BurnProgress -= Time.deltaTime * 0.16f;
			yield return new WaitForEndOfFrame();
		}
		limb.PhysicalBehaviour.BurnProgress = 0f;
	}

	private IEnumerator HealAcidFlesh(LimbBehaviour limb)
	{
		while (limb.SkinMaterialHandler.AcidProgress > 0.1f)
		{
			limb.SkinMaterialHandler.AcidProgress -= Time.deltaTime * 0.8f;
			yield return new WaitForEndOfFrame();
		}
		limb.SkinMaterialHandler.AcidProgress = 0f;
	}

	private IEnumerator HealRottenFlesh(LimbBehaviour limb)
	{
		while (limb.SkinMaterialHandler.RottenProgress > 0.1f)
		{
			limb.SkinMaterialHandler.RottenProgress -= Time.deltaTime * 0.8f;
			yield return new WaitForEndOfFrame();
		}
		limb.SkinMaterialHandler.RottenProgress = 0f;
	}

	private IEnumerator HealWounds(LimbBehaviour limb)
	{
		while (((IEnumerable<Vector4>)limb.SkinMaterialHandler.damagePoints).Max((Func<Vector4, float>)_003CHealWounds_003Eg__intensity_007C5_0) > 0f)
		{
			for (int i = 0; i < limb.SkinMaterialHandler.damagePoints.Length; i++)
			{
				limb.SkinMaterialHandler.damagePoints[i].z -= Time.deltaTime * 0.5f;
			}
			limb.SkinMaterialHandler.Sync();
			yield return new WaitForEndOfFrame();
		}
	}

	[CompilerGenerated]
	private static float _003CHealWounds_003Eg__intensity_007C5_0(Vector4 c)
	{
		return c.z;
	}
}
