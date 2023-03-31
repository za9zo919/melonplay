using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LifeSyringe : SyringeBehaviour
{
	public class LifeSerumLiquid : TemporaryBodyLiquid
	{
		[CompilerGenerated]
		private sealed class _003CHealBurn_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LimbBehaviour limb;

			public LifeSerumLiquid _003C_003E4__this;

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
			public _003CHealBurn_003Ed__7(int _003C_003E1__state)
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
				LifeSerumLiquid liquid = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					limb.PhysicalBehaviour.Temperature = limb.BodyTemperature;
					break;
				case 1:
					_003C_003E1__state = -1;
					if (limb.CirculationBehaviour.GetAmount(liquid) <= float.Epsilon)
					{
						return false;
					}
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
		private sealed class _003CHealAcidFlesh_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LimbBehaviour limb;

			public LifeSerumLiquid _003C_003E4__this;

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
			public _003CHealAcidFlesh_003Ed__8(int _003C_003E1__state)
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
				LifeSerumLiquid liquid = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					break;
				case 1:
					_003C_003E1__state = -1;
					if (limb.CirculationBehaviour.GetAmount(liquid) <= float.Epsilon)
					{
						return false;
					}
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
		private sealed class _003CHealRottenFlesh_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LimbBehaviour limb;

			public LifeSerumLiquid _003C_003E4__this;

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
			public _003CHealRottenFlesh_003Ed__9(int _003C_003E1__state)
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
				LifeSerumLiquid liquid = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					break;
				case 1:
					_003C_003E1__state = -1;
					if (limb.CirculationBehaviour.GetAmount(liquid) <= float.Epsilon)
					{
						return false;
					}
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
		private sealed class _003CHealWounds_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LimbBehaviour limb;

			public LifeSerumLiquid _003C_003E4__this;

			private float _003Cfactor_003E5__2;

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
			public _003CHealWounds_003Ed__10(int _003C_003E1__state)
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
				LifeSerumLiquid liquid = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003Cfactor_003E5__2 = Mathf.Pow(0.5f, Time.deltaTime);
					break;
				case 1:
					_003C_003E1__state = -1;
					if (limb.CirculationBehaviour.GetAmount(liquid) <= float.Epsilon)
					{
						return false;
					}
					break;
				}
				if (((IEnumerable<Vector4>)limb.SkinMaterialHandler.damagePoints).Max((Func<Vector4, float>)_003CHealWounds_003Eg__intensity_007C10_0) > 0f)
				{
					for (int i = 0; i < limb.SkinMaterialHandler.damagePoints.Length; i++)
					{
						limb.SkinMaterialHandler.damagePoints[i].z *= _003Cfactor_003E5__2;
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

		public const string ID = "LIFE SERUM";

		public override string GetDisplayName()
		{
			return "Life serum";
		}

		public LifeSerumLiquid()
		{
			Color = new Color(143f / 212f, 1f, 0.7830077f);
		}

		public override void OnEnterContainer(BloodContainer container)
		{
		}

		public override void OnEnterLimb(LimbBehaviour limb)
		{
			if (!(limb.SpeciesIdentity == "Android"))
			{
				if (limb.HasBrain)
				{
					limb.Person.Braindead = false;
				}
				GeneralHealing(limb);
				limb.CirculationBehaviour.StartCoroutine(HealBurn(limb));
				limb.CirculationBehaviour.StartCoroutine(HealWounds(limb));
				limb.CirculationBehaviour.StartCoroutine(HealRottenFlesh(limb));
				limb.CirculationBehaviour.StartCoroutine(HealAcidFlesh(limb));
				limb.LungsPunctured = false;
			}
		}

		public override void OnExitContainer(BloodContainer container)
		{
		}

		private void GeneralHealing(LimbBehaviour limb)
		{
			limb.HealBone();
			limb.Health = limb.InitialHealth;
			limb.Numbness = 0f;
			limb.CirculationBehaviour.HealBleeding();
			limb.CirculationBehaviour.IsPump = limb.CirculationBehaviour.WasInitiallyPumping;
			limb.CirculationBehaviour.BloodFlow = 1f;
			limb.CirculationBehaviour.AddLiquid(limb.GetOriginalBloodType(), Mathf.Max(0f, 1f - limb.CirculationBehaviour.GetAmount(limb.GetOriginalBloodType())));
			limb.BruiseCount = 0;
			limb.CirculationBehaviour.GunshotWoundCount = 0;
			limb.CirculationBehaviour.StabWoundCount = 0;
			if (limb.RoughClassification == LimbBehaviour.BodyPart.Head)
			{
				limb.Person.Consciousness = 1f;
				limb.Person.ShockLevel = 0f;
				limb.Person.PainLevel = 0f;
				limb.Person.OxygenLevel = 1f;
				limb.Person.AdrenalineLevel = 1f;
			}
		}

		private IEnumerator HealBurn(LimbBehaviour limb)
		{
			limb.PhysicalBehaviour.Temperature = limb.BodyTemperature;
			while (limb.PhysicalBehaviour.BurnProgress > 0.1f)
			{
				limb.PhysicalBehaviour.BurnProgress -= Time.deltaTime * 0.16f;
				yield return new WaitForEndOfFrame();
				if (limb.CirculationBehaviour.GetAmount(this) <= float.Epsilon)
				{
					yield break;
				}
			}
			limb.PhysicalBehaviour.BurnProgress = 0f;
		}

		private IEnumerator HealAcidFlesh(LimbBehaviour limb)
		{
			while (limb.SkinMaterialHandler.AcidProgress > 0.1f)
			{
				limb.SkinMaterialHandler.AcidProgress -= Time.deltaTime * 0.8f;
				yield return new WaitForEndOfFrame();
				if (limb.CirculationBehaviour.GetAmount(this) <= float.Epsilon)
				{
					yield break;
				}
			}
			limb.SkinMaterialHandler.AcidProgress = 0f;
		}

		private IEnumerator HealRottenFlesh(LimbBehaviour limb)
		{
			while (limb.SkinMaterialHandler.RottenProgress > 0.1f)
			{
				limb.SkinMaterialHandler.RottenProgress -= Time.deltaTime * 0.8f;
				yield return new WaitForEndOfFrame();
				if (limb.CirculationBehaviour.GetAmount(this) <= float.Epsilon)
				{
					yield break;
				}
			}
			limb.SkinMaterialHandler.RottenProgress = 0f;
		}

		private IEnumerator HealWounds(LimbBehaviour limb)
		{
			float factor = Mathf.Pow(0.5f, Time.deltaTime);
			while (((IEnumerable<Vector4>)limb.SkinMaterialHandler.damagePoints).Max((Func<Vector4, float>)_003CHealWounds_003Eg__intensity_007C10_0) > 0f)
			{
				for (int i = 0; i < limb.SkinMaterialHandler.damagePoints.Length; i++)
				{
					limb.SkinMaterialHandler.damagePoints[i].z *= factor;
				}
				limb.SkinMaterialHandler.Sync();
				yield return new WaitForEndOfFrame();
				if (limb.CirculationBehaviour.GetAmount(this) <= float.Epsilon)
				{
					break;
				}
			}
		}

		[CompilerGenerated]
		private static float _003CHealWounds_003Eg__intensity_007C10_0(Vector4 c)
		{
			return c.z;
		}
	}

	public override string GetLiquidID()
	{
		return "LIFE SERUM";
	}
}
