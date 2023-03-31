using Linefy.Serialization;
using System;
using UnityEngine;

namespace Linefy
{
	public abstract class PrimitivesGroup : LinefyDrawcall
	{
		private int id_widthMultiplier = Shader.PropertyToID("_WidthMultiplier");

		private int id_persentOfScreenHeightMode = Shader.PropertyToID("_PersentOfScreenHeightMode");

		private int prevCapacity;

		protected int capacity;

		protected int _count = -1;

		private int _capacityChangeStep;

		private float _widthMultiplier = 1f;

		private WidthMode _widthMode;

		public virtual int maxCount
		{
			get
			{
				UnityEngine.Debug.LogError("not implemeted");
				return 0;
			}
		}

		public int capacityChangeStep
		{
			get
			{
				return _capacityChangeStep;
			}
			set
			{
				_capacityChangeStep = value;
			}
		}

		public virtual int count
		{
			get
			{
				return _count;
			}
			set
			{
				int count = _count;
				int num = Mathf.Max(0, value);
				if (num > maxCount)
				{
					UnityEngine.Debug.LogWarningFormat("The count {0} is limited to the maximum value {1} for {2} ", num, maxCount, GetType());
					num = maxCount;
				}
				if (num != _count)
				{
					_count = num;
					if (capacityChangeStep <= 0)
					{
						float f = Mathf.Max(1f, (float)_count / 16f);
						capacity = Mathf.Max(capacity, Mathf.CeilToInt(f) * 64);
					}
					else
					{
						float f2 = Mathf.Max(1f, (float)_count / (float)capacityChangeStep);
						capacity = Mathf.CeilToInt(f2) * capacityChangeStep;
					}
					if (prevCapacity != capacity)
					{
						SetCapacity(prevCapacity);
						prevCapacity = capacity;
					}
					SetCount(count);
				}
			}
		}

		public float widthMultiplier
		{
			get
			{
				return _widthMultiplier;
			}
			set
			{
				if (value != _widthMultiplier)
				{
					_widthMultiplier = value;
					base.material.SetFloat(id_widthMultiplier, _widthMultiplier);
				}
			}
		}

		public WidthMode widthMode
		{
			get
			{
				return _widthMode;
			}
			set
			{
				if (value != _widthMode)
				{
					_widthMode = value;
					ResetMaterial();
					base.material.SetFloat(id_persentOfScreenHeightMode, (_widthMode == WidthMode.PercentOfScreenHeight) ? 1 : 0);
					base.material.SetFloat(id_widthMultiplier, _widthMultiplier);
				}
			}
		}

		protected virtual void SetCapacity(int prevCapacity)
		{
			UnityEngine.Debug.LogErrorFormat("SetCapacity() not implemented in {0}", GetType());
		}

		protected virtual void SetCount(int prevCount)
		{
			UnityEngine.Debug.LogErrorFormat("SetCount() not implemented in {0}", GetType());
		}

		protected override void OnAfterMaterialCreated()
		{
			base.OnAfterMaterialCreated();
			base.material.SetFloat(id_persentOfScreenHeightMode, (_widthMode == WidthMode.PercentOfScreenHeight) ? 1 : 0);
			base.material.SetFloat(id_widthMultiplier, _widthMultiplier);
		}

		[Obsolete("SetVisualPropertyBlock is Obsolete , use LoadSerializationData instead")]
		public override void SetVisualPropertyBlock(VisualPropertiesBlock block)
		{
			base.SetVisualPropertyBlock(block);
			widthMode = block.widthMode;
		}

		public void LoadSerializationData(SerializationData_PrimitivesGroup inputData)
		{
			LoadSerializationData((SerializationData_LinefyDrawcall)inputData);
			capacityChangeStep = inputData.capacityChangeStep;
			widthMultiplier = inputData.widthMultiplier;
			widthMode = inputData.widthMode;
		}

		public void SaveSerializationData(SerializationData_PrimitivesGroup outputData)
		{
			SaveSerializationData((SerializationData_LinefyDrawcall)outputData);
			outputData.capacityChangeStep = capacityChangeStep;
			outputData.widthMultiplier = widthMultiplier;
			outputData.widthMode = widthMode;
		}
	}
}
