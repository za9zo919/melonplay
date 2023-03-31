using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[Obsolete]
public abstract class PoisonSpreadBehaviour : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CWaitAndDelete_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float seconds;

		public PoisonSpreadBehaviour _003C_003E4__this;

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
		public _003CWaitAndDelete_003Ed__19(int _003C_003E1__state)
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
			PoisonSpreadBehaviour obj = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = new WaitForSeconds(seconds);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				UnityEngine.Object.Destroy(obj);
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

	public bool Spreads = true;

	public LimbBehaviour Limb;

	public float LifeTime;

	public bool HasSpread;

	public float[] Fingerprint;

	private int fingerprintReadPos;

	public virtual float SpreadSpeed => 1f;

	public virtual float Lifespan => 5f;

	public virtual bool AllowMultipleActivations => true;

	public abstract void Start();

	protected virtual void Update()
	{
		LifeTime += Time.deltaTime;
		Spread();
		DestroyIfExpired();
	}

	private void Spread()
	{
		if (HasSpread || !Spreads || !(LifeTime > 1f / Mathf.Max(0.0001f, SpreadSpeed)))
		{
			return;
		}
		CirculationBehaviour source = Limb.CirculationBehaviour.Source;
		if (!Limb.CirculationBehaviour.IsDisconnected && (bool)source && _003CSpread_003Eg__shouldPoison_007C12_0(source.Limb))
		{
			Poison(source.Limb);
		}
		CirculationBehaviour[] pushesTo = Limb.CirculationBehaviour.PushesTo;
		foreach (CirculationBehaviour circulationBehaviour in pushesTo)
		{
			if ((bool)circulationBehaviour && !circulationBehaviour.IsDisconnected && _003CSpread_003Eg__shouldPoison_007C12_0(circulationBehaviour.Limb))
			{
				Poison(circulationBehaviour.Limb);
			}
		}
		HasSpread = true;
	}

	protected float GetFingerprintValue()
	{
		float result = Fingerprint[fingerprintReadPos];
		fingerprintReadPos++;
		if (fingerprintReadPos >= Fingerprint.Length)
		{
			fingerprintReadPos = 0;
		}
		return result;
	}

	private void DestroyIfExpired()
	{
		if (LifeTime > Lifespan)
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	public void Poison(LimbBehaviour limb)
	{
		PoisonSpreadBehaviour poisonSpreadBehaviour = limb.gameObject.GetComponent(GetType()) as PoisonSpreadBehaviour;
		if (!poisonSpreadBehaviour)
		{
			poisonSpreadBehaviour = (limb.gameObject.AddComponent(GetType()) as PoisonSpreadBehaviour);
			poisonSpreadBehaviour.Limb = limb;
			poisonSpreadBehaviour.Fingerprint = Fingerprint;
			OnPoisonOther(poisonSpreadBehaviour);
		}
		else if (AllowMultipleActivations)
		{
			poisonSpreadBehaviour.Start();
		}
	}

	protected virtual void OnPoisonOther(PoisonSpreadBehaviour other)
	{
	}

	public IEnumerator WaitAndDelete(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		UnityEngine.Object.Destroy(this);
	}

	[CompilerGenerated]
	private static bool _003CSpread_003Eg__shouldPoison_007C12_0(LimbBehaviour cir)
	{
		return !cir.PhysicalBehaviour.isDisintegrated;
	}
}
