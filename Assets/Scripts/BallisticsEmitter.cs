using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class BallisticsEmitter : IDisposable
{
	public struct CallbackParams
	{
		public Collider2D HitObject;

		public Vector2 SurfaceNormal;

		public Vector2 Direction;

		public Vector2 Position;
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003C_003Ec__DisplayClass82_0
	{
		public BallisticsEmitter _003C_003E4__this;

		public Vector2 direction;

		public bool canExplode;

		public LineRenderer tracer;
	}

	[CompilerGenerated]
	private sealed class _003CBallisticIteration_003Ed__82 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public BallisticsEmitter _003C_003E4__this;

		public Vector2 direction;

		public bool canExplode;

		public LineRenderer tracer;

		public int iteration;

		public float totalDistance;

		public Vector2 origin;

		public float speed;

		public Collider2D previousCollider;

		public bool shouldDoSplash;

		private _003C_003Ec__DisplayClass82_0 _003C_003E8__1;

		private PhysicalBehaviour _003CphysicalBehaviour_003E5__2;

		private RaycastHit2D _003Chit_003E5__3;

		private float _003Chardness_003E5__4;

		private float _003Cdamage_003E5__5;

		private float _003CtraversalDistance_003E5__6;

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
		public _003CBallisticIteration_003Ed__82(int _003C_003E1__state)
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
			BallisticsEmitter ballisticsEmitter = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
			{
				_003C_003E1__state = -1;
				_003C_003E8__1._003C_003E4__this = _003C_003E4__this;
				_003C_003E8__1.direction = direction;
				_003C_003E8__1.canExplode = canExplode;
				_003C_003E8__1.tracer = tracer;
				if (iteration >= ballisticsEmitter.MaxBallisticsIterations || totalDistance >= ballisticsEmitter.MaxTotalDistance)
				{
					ballisticsEmitter._003CBallisticIteration_003Eg__removeTracer_007C82_1(ref _003C_003E8__1);
					return false;
				}
				if (LavaBehaviour.IsPointInLava(origin))
				{
					RandomiseCourse(1f, 20f, ref _003C_003E8__1.direction, ref speed);
				}
				else if (WaterBehaviour.IsPointUnderWater(origin))
				{
					RandomiseCourse(0.99999f, 10f, ref _003C_003E8__1.direction, ref speed);
				}
				float num2 = Mathf.Clamp(speed / ballisticsEmitter.Cartridge.StartSpeed, 0.05f, 1f) * ballisticsEmitter.SpeedMultiplierByDistance(totalDistance);
				if (num2 <= 0.1f)
				{
					ballisticsEmitter._003CBallisticIteration_003Eg__removeTracer_007C82_1(ref _003C_003E8__1);
					return false;
				}
				_003CphysicalBehaviour_003E5__2 = null;
				Collider2D collider2D = Physics2D.OverlapPoint(origin, ballisticsEmitter.LayersToHit, -0.1f, 0.1f);
				CallbackParams obj;
				if ((bool)collider2D && collider2D.transform.root != ballisticsEmitter.ConnectedBehaviour.transform.root && Global.main.PhysicalObjectsInWorldByTransform.TryGetValue(collider2D.transform, out _003CphysicalBehaviour_003E5__2))
				{
					float num3 = ballisticsEmitter.CalculateHardness(_003CphysicalBehaviour_003E5__2);
					if (collider2D != previousCollider)
					{
						float damageForDistance = ballisticsEmitter.GetDamageForDistance(ballisticsEmitter.ThicknessStepSize + totalDistance);
						if ((bool)_003C_003E8__1.tracer)
						{
							_003C_003E8__1.tracer.enabled = false;
						}
						if ((bool)previousCollider)
						{
							Vector2 vector = origin - _003C_003E8__1.direction * ballisticsEmitter.ThicknessStepSize;
							previousCollider.SendMessage("ExitShot", new Shot(_003C_003E8__1.direction, vector, damageForDistance, triggerExplosiveOverride: true, ballisticsEmitter.Cartridge), SendMessageOptions.DontRequireReceiver);
							Action<CallbackParams> bulletExitCallback = ballisticsEmitter.BulletExitCallback;
							if (bulletExitCallback != null)
							{
								obj = new CallbackParams
								{
									HitObject = previousCollider,
									Position = vector,
									Direction = _003C_003E8__1.direction,
									SurfaceNormal = _003C_003E8__1.direction
								};
								bulletExitCallback(obj);
							}
						}
						collider2D.SendMessage("Shot", new Shot(_003C_003E8__1.direction * -1f, origin, damageForDistance, triggerExplosiveOverride: true, ballisticsEmitter.Cartridge), SendMessageOptions.DontRequireReceiver);
						Action<CallbackParams> bulletEntryCallback = ballisticsEmitter.BulletEntryCallback;
						if (bulletEntryCallback != null)
						{
							obj = new CallbackParams
							{
								HitObject = collider2D,
								Position = origin,
								Direction = _003C_003E8__1.direction,
								SurfaceNormal = _003C_003E8__1.direction
							};
							bulletEntryCallback(obj);
						}
						if (_003C_003E8__1.canExplode && ballisticsEmitter.ExplosiveRound)
						{
							ballisticsEmitter._003CBallisticIteration_003Eg__explode_007C82_0(origin, ref _003C_003E8__1);
						}
					}
					_003CphysicalBehaviour_003E5__2.rigidbody.AddForceAtPosition(_003C_003E8__1.direction * ballisticsEmitter.Cartridge.ImpactForce * num3 * ballisticsEmitter.ThicknessStepSize * ballisticsEmitter.ImpactForceMultiplier * 4f, origin, ForceMode2D.Force);
					ballisticsEmitter.ConnectedBehaviour.StartCoroutine(ballisticsEmitter.BallisticIteration(origin + _003C_003E8__1.direction * ballisticsEmitter.ThicknessStepSize, _003C_003E8__1.direction + ballisticsEmitter.RandomisedAngle, speed - num3, iteration + 1, totalDistance + ballisticsEmitter.ThicknessStepSize, collider2D, _003C_003E8__1.tracer, shouldDoSplash: true, _003C_003E8__1.canExplode));
					return false;
				}
				if (previousCollider != null)
				{
					Vector2 vector2 = origin - _003C_003E8__1.direction * ballisticsEmitter.ThicknessStepSize;
					previousCollider.SendMessage("ExitShot", new Shot(_003C_003E8__1.direction, vector2, ballisticsEmitter.GetDamageForDistance(ballisticsEmitter.ThicknessStepSize + totalDistance), triggerExplosiveOverride: true, ballisticsEmitter.Cartridge), SendMessageOptions.DontRequireReceiver);
					Action<CallbackParams> bulletExitCallback2 = ballisticsEmitter.BulletExitCallback;
					if (bulletExitCallback2 != null)
					{
						obj = new CallbackParams
						{
							HitObject = previousCollider,
							Position = vector2,
							Direction = _003C_003E8__1.direction,
							SurfaceNormal = _003C_003E8__1.direction
						};
						bulletExitCallback2(obj);
					}
					if ((bool)_003C_003E8__1.tracer)
					{
						_003C_003E8__1.tracer.enabled = true;
					}
				}
				_003Chit_003E5__3 = Physics2D.Raycast(origin, _003C_003E8__1.direction, ballisticsEmitter.MaxRange, ballisticsEmitter.LayersToHit, -0.1f, 0.1f);
				if (!(_003Chit_003E5__3.transform != null) || !(_003Chit_003E5__3.transform.root != ballisticsEmitter.ConnectedBehaviour.transform.root) || !Global.main.PhysicalObjectsInWorldByTransform.TryGetValue(_003Chit_003E5__3.transform, out _003CphysicalBehaviour_003E5__2))
				{
					if (ballisticsEmitter.DoTraversal)
					{
						_003CtraversalDistance_003E5__6 = Mathf.Min(ballisticsEmitter.MaxRange, Time.deltaTime * 60f * ballisticsEmitter.MaxRange * Mathf.Sqrt(num2));
						if ((bool)_003C_003E8__1.tracer)
						{
							_003C_003E8__1.tracer.SetPosition(1, Mathf.Clamp01(num2) * ballisticsEmitter.MaxRange * Vector3.right);
							_003C_003E8__1.tracer.transform.position = origin;
							_003C_003E8__1.tracer.transform.right = _003C_003E8__1.direction;
						}
						shouldDoSplash = !ballisticsEmitter.TestForWaterHit(origin, _003C_003E8__1.direction, ballisticsEmitter.GetDamageForDistance(totalDistance + _003CtraversalDistance_003E5__6 * 0.1f), shouldDoSplash);
						_003C_003E8__1.direction = Vector2.Lerp(_003C_003E8__1.direction, Vector2.down, (1f - Mathf.Pow(0.999f, Time.deltaTime * 60f)) * ballisticsEmitter.BulletDropMultiplier * 0.7f).normalized;
						_003C_003E2__current = new WaitForEndOfFrame();
						_003C_003E1__state = 1;
						return true;
					}
					goto IL_07bb;
				}
				_003Chardness_003E5__4 = ballisticsEmitter.CalculateHardness(_003CphysicalBehaviour_003E5__2);
				float value = Mathf.Max(ballisticsEmitter.Cartridge.ImpactForce * _003Chardness_003E5__4, ballisticsEmitter.Cartridge.ImpactForce);
				_003Cdamage_003E5__5 = ballisticsEmitter.GetDamageForDistance(totalDistance + _003Chit_003E5__3.distance);
				value = ballisticsEmitter.ImpactForceMultiplier * Mathf.Clamp(value, 0f, 1.5f) * 1.5f;
				_003CphysicalBehaviour_003E5__2.rigidbody.AddForceAtPosition(value * _003C_003E8__1.direction, origin, ForceMode2D.Force);
				_003CphysicalBehaviour_003E5__2.SendMessage("Shot", new Shot(_003Chit_003E5__3.normal, _003Chit_003E5__3.point, _003Cdamage_003E5__5, triggerExplosiveOverride: true, ballisticsEmitter.Cartridge), SendMessageOptions.DontRequireReceiver);
				Action<CallbackParams> bulletEntryCallback2 = ballisticsEmitter.BulletEntryCallback;
				if (bulletEntryCallback2 != null)
				{
					obj = new CallbackParams
					{
						HitObject = _003Chit_003E5__3.collider,
						Position = _003Chit_003E5__3.point,
						Direction = _003C_003E8__1.direction,
						SurfaceNormal = _003Chit_003E5__3.normal
					};
					bulletEntryCallback2(obj);
				}
				if (_003C_003E8__1.canExplode && ballisticsEmitter.ExplosiveRound)
				{
					ballisticsEmitter._003CBallisticIteration_003Eg__explode_007C82_0(_003Chit_003E5__3.point, ref _003C_003E8__1);
				}
				if ((bool)_003C_003E8__1.tracer)
				{
					_003C_003E8__1.tracer.transform.position = origin;
					_003C_003E8__1.tracer.transform.right = _003C_003E8__1.direction;
					_003C_003E8__1.tracer.SetPosition(1, Vector3.right * _003Chit_003E5__3.distance);
				}
				_003C_003E2__current = new WaitForSeconds(0.01f);
				_003C_003E1__state = 2;
				return true;
			}
			case 1:
				_003C_003E1__state = -1;
				ballisticsEmitter.ConnectedBehaviour.StartCoroutine(ballisticsEmitter.BallisticIteration(origin + _003CtraversalDistance_003E5__6 * _003C_003E8__1.direction, _003C_003E8__1.direction, speed, iteration, totalDistance + _003CtraversalDistance_003E5__6 * 0.1f, null, _003C_003E8__1.tracer, shouldDoSplash, _003C_003E8__1.canExplode));
				goto IL_07bb;
			case 2:
				{
					_003C_003E1__state = -1;
					shouldDoSplash = !ballisticsEmitter.TestForWaterHit(origin, _003C_003E8__1.direction, _003Cdamage_003E5__5, shouldDoSplash);
					if (ballisticsEmitter.ShouldRicochet(_003C_003E8__1.direction, _003Chit_003E5__3, _003CphysicalBehaviour_003E5__2))
					{
						ballisticsEmitter.RicochetBullet(_003C_003E8__1.direction, speed, iteration, totalDistance, _003C_003E8__1.tracer, _003Chit_003E5__3);
						return false;
					}
					ballisticsEmitter.ConnectedBehaviour.StartCoroutine(ballisticsEmitter.BallisticIteration(_003Chit_003E5__3.point + _003C_003E8__1.direction * ballisticsEmitter.ThicknessStepSize, _003C_003E8__1.direction, speed - _003Chardness_003E5__4, iteration + 1, totalDistance + _003Chit_003E5__3.distance, _003Chit_003E5__3.collider, _003C_003E8__1.tracer, shouldDoSplash, _003C_003E8__1.canExplode));
					return false;
				}
				IL_07bb:
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

	public ExplosionCreator.ExplosionParameters ExplosiveRoundParams;

	private HashSet<LineRenderer> tracers = new HashSet<LineRenderer>();

	public uint MaxBallisticsIterations
	{
		get;
		set;
	} = 128u;


	public float MaxTotalDistance
	{
		get;
		set;
	} = 1000f;


	public float ThicknessStepSize
	{
		get;
		set;
	} = 0.08f;


	public float RicochetChanceMultiplier
	{
		get;
		set;
	} = 1f;


	public float MaxRange
	{
		get;
		set;
	} = 1000f;


	public float MaterialHardnessMultiplier
	{
		get;
		set;
	} = 0.35f;


	public float ImpactForceMultiplier
	{
		get;
		set;
	} = 18f;


	public LayerMask LayersToHit
	{
		get;
		set;
	}

	public LayerMask WaterLayer
	{
		get;
		set;
	}

	public bool DoTraversal
	{
		get;
		set;
	}

	public float TracerWidth
	{
		get;
		set;
	} = 0.02f;


	public bool RenderTracersIfTraversal
	{
		get;
		set;
	} = true;


	public float BulletDropMultiplier
	{
		get;
		set;
	} = 0.25f;


	public bool ExplosiveRound
	{
		get;
		set;
	}

	public MonoBehaviour ConnectedBehaviour
	{
		get;
		set;
	}

	public Cartridge Cartridge
	{
		get;
		set;
	}

	public Action<CallbackParams> BulletEntryCallback
	{
		get;
		set;
	}

	public Action<CallbackParams> BulletExitCallback
	{
		get;
		set;
	}

	public Action<CallbackParams> BulletRicochetCallback
	{
		get;
		set;
	}

	private Vector2 RandomisedAngle => UnityEngine.Random.insideUnitCircle * Cartridge.PenetrationRandomAngleMultiplier;

	public BallisticsEmitter(MonoBehaviour connectedBehaviour, Cartridge cartridge)
	{
		ConnectedBehaviour = connectedBehaviour;
		Cartridge = cartridge;
		LayersToHit = LayerMask.GetMask("Bounds", "Objects", "CollidingDebris");
		WaterLayer = LayerMask.GetMask("Water");
	}

	public void Emit(Vector2 origin, Vector2 direction)
	{
		LineRenderer tracer = null;
		if (DoTraversal && RenderTracersIfTraversal)
		{
			tracer = CreateTracer(origin, direction);
		}
		ConnectedBehaviour.StartCoroutine(BallisticIteration(origin, direction.normalized, Cartridge.StartSpeed, 0, 0f, null, tracer, shouldDoSplash: true, canExplode: true));
	}

	private LineRenderer CreateTracer(Vector2 origin, Vector2 direction)
	{
		GameObject gameObject = BulletTracerPool.Instance.Request(origin);
		if (!gameObject)
		{
			return null;
		}
		LineRenderer component = gameObject.GetComponent<LineRenderer>();
		component.widthMultiplier = TracerWidth;
		component.SetPosition(1, Vector3.right * MaxRange);
		tracers.Add(component);
		return component;
	}

	private float GetDamageForDistance(float totalDistance)
	{
		return Cartridge.Damage * DamageMultiplierByDistance(totalDistance);
	}

	private IEnumerator BallisticIteration(Vector2 origin, Vector2 direction, float speed, int iteration = 0, float totalDistance = 0f, Collider2D previousCollider = null, LineRenderer tracer = null, bool shouldDoSplash = true, bool canExplode = false)
	{
		_003C_003Ec__DisplayClass82_0 _003C_003Ec__DisplayClass82_ = default(_003C_003Ec__DisplayClass82_0);
		_003C_003Ec__DisplayClass82_._003C_003E4__this = this;
		_003C_003Ec__DisplayClass82_.direction = direction;
		_003C_003Ec__DisplayClass82_.canExplode = canExplode;
		_003C_003Ec__DisplayClass82_.tracer = tracer;
		if (iteration >= MaxBallisticsIterations || totalDistance >= MaxTotalDistance)
		{
			_003CBallisticIteration_003Eg__removeTracer_007C82_1(ref _003C_003Ec__DisplayClass82_);
			yield break;
		}
		if (LavaBehaviour.IsPointInLava(origin))
		{
			RandomiseCourse(1f, 20f, ref _003C_003Ec__DisplayClass82_.direction, ref speed);
		}
		else if (WaterBehaviour.IsPointUnderWater(origin))
		{
			RandomiseCourse(0.99999f, 10f, ref _003C_003Ec__DisplayClass82_.direction, ref speed);
		}
		float num = Mathf.Clamp(speed / Cartridge.StartSpeed, 0.05f, 1f) * SpeedMultiplierByDistance(totalDistance);
		if (num <= 0.1f)
		{
			_003CBallisticIteration_003Eg__removeTracer_007C82_1(ref _003C_003Ec__DisplayClass82_);
			yield break;
		}
		PhysicalBehaviour physicalBehaviour = null;
		Collider2D collider2D = Physics2D.OverlapPoint(origin, LayersToHit, -0.1f, 0.1f);
		CallbackParams obj;
		if ((bool)collider2D && collider2D.transform.root != ConnectedBehaviour.transform.root && Global.main.PhysicalObjectsInWorldByTransform.TryGetValue(collider2D.transform, out physicalBehaviour))
		{
			float num2 = CalculateHardness(physicalBehaviour);
			if (collider2D != previousCollider)
			{
				float damageForDistance = GetDamageForDistance(ThicknessStepSize + totalDistance);
				if ((bool)_003C_003Ec__DisplayClass82_.tracer)
				{
					_003C_003Ec__DisplayClass82_.tracer.enabled = false;
				}
				if ((bool)previousCollider)
				{
					Vector2 vector = origin - _003C_003Ec__DisplayClass82_.direction * ThicknessStepSize;
					previousCollider.SendMessage("ExitShot", new Shot(_003C_003Ec__DisplayClass82_.direction, vector, damageForDistance, triggerExplosiveOverride: true, Cartridge), SendMessageOptions.DontRequireReceiver);
					Action<CallbackParams> bulletExitCallback = BulletExitCallback;
					if (bulletExitCallback != null)
					{
						obj = new CallbackParams
						{
							HitObject = previousCollider,
							Position = vector,
							Direction = _003C_003Ec__DisplayClass82_.direction,
							SurfaceNormal = _003C_003Ec__DisplayClass82_.direction
						};
						bulletExitCallback(obj);
					}
				}
				collider2D.SendMessage("Shot", new Shot(_003C_003Ec__DisplayClass82_.direction * -1f, origin, damageForDistance, triggerExplosiveOverride: true, Cartridge), SendMessageOptions.DontRequireReceiver);
				Action<CallbackParams> bulletEntryCallback = BulletEntryCallback;
				if (bulletEntryCallback != null)
				{
					obj = new CallbackParams
					{
						HitObject = collider2D,
						Position = origin,
						Direction = _003C_003Ec__DisplayClass82_.direction,
						SurfaceNormal = _003C_003Ec__DisplayClass82_.direction
					};
					bulletEntryCallback(obj);
				}
				if (_003C_003Ec__DisplayClass82_.canExplode && ExplosiveRound)
				{
					_003CBallisticIteration_003Eg__explode_007C82_0(origin, ref _003C_003Ec__DisplayClass82_);
				}
			}
			physicalBehaviour.rigidbody.AddForceAtPosition(_003C_003Ec__DisplayClass82_.direction * Cartridge.ImpactForce * num2 * ThicknessStepSize * ImpactForceMultiplier * 4f, origin, ForceMode2D.Force);
			ConnectedBehaviour.StartCoroutine(BallisticIteration(origin + _003C_003Ec__DisplayClass82_.direction * ThicknessStepSize, _003C_003Ec__DisplayClass82_.direction + RandomisedAngle, speed - num2, iteration + 1, totalDistance + ThicknessStepSize, collider2D, _003C_003Ec__DisplayClass82_.tracer, shouldDoSplash: true, _003C_003Ec__DisplayClass82_.canExplode));
			yield break;
		}
		if (previousCollider != null)
		{
			Vector2 vector2 = origin - _003C_003Ec__DisplayClass82_.direction * ThicknessStepSize;
			previousCollider.SendMessage("ExitShot", new Shot(_003C_003Ec__DisplayClass82_.direction, vector2, GetDamageForDistance(ThicknessStepSize + totalDistance), triggerExplosiveOverride: true, Cartridge), SendMessageOptions.DontRequireReceiver);
			Action<CallbackParams> bulletExitCallback2 = BulletExitCallback;
			if (bulletExitCallback2 != null)
			{
				obj = new CallbackParams
				{
					HitObject = previousCollider,
					Position = vector2,
					Direction = _003C_003Ec__DisplayClass82_.direction,
					SurfaceNormal = _003C_003Ec__DisplayClass82_.direction
				};
				bulletExitCallback2(obj);
			}
			if ((bool)_003C_003Ec__DisplayClass82_.tracer)
			{
				_003C_003Ec__DisplayClass82_.tracer.enabled = true;
			}
		}
		RaycastHit2D hit = Physics2D.Raycast(origin, _003C_003Ec__DisplayClass82_.direction, MaxRange, LayersToHit, -0.1f, 0.1f);
		if (!(hit.transform != null) || !(hit.transform.root != ConnectedBehaviour.transform.root) || !Global.main.PhysicalObjectsInWorldByTransform.TryGetValue(hit.transform, out physicalBehaviour))
		{
			if (DoTraversal)
			{
				float traversalDistance = Mathf.Min(MaxRange, Time.deltaTime * 60f * MaxRange * Mathf.Sqrt(num));
				if ((bool)_003C_003Ec__DisplayClass82_.tracer)
				{
					_003C_003Ec__DisplayClass82_.tracer.SetPosition(1, Mathf.Clamp01(num) * MaxRange * Vector3.right);
					_003C_003Ec__DisplayClass82_.tracer.transform.position = origin;
					_003C_003Ec__DisplayClass82_.tracer.transform.right = _003C_003Ec__DisplayClass82_.direction;
				}
				shouldDoSplash = !TestForWaterHit(origin, _003C_003Ec__DisplayClass82_.direction, GetDamageForDistance(totalDistance + traversalDistance * 0.1f), shouldDoSplash);
				_003C_003Ec__DisplayClass82_.direction = Vector2.Lerp(_003C_003Ec__DisplayClass82_.direction, Vector2.down, (1f - Mathf.Pow(0.999f, Time.deltaTime * 60f)) * BulletDropMultiplier * 0.7f).normalized;
				yield return new WaitForEndOfFrame();
				ConnectedBehaviour.StartCoroutine(BallisticIteration(origin + traversalDistance * _003C_003Ec__DisplayClass82_.direction, _003C_003Ec__DisplayClass82_.direction, speed, iteration, totalDistance + traversalDistance * 0.1f, null, _003C_003Ec__DisplayClass82_.tracer, shouldDoSplash, _003C_003Ec__DisplayClass82_.canExplode));
			}
			yield break;
		}
		float hardness = CalculateHardness(physicalBehaviour);
		float value = Mathf.Max(Cartridge.ImpactForce * hardness, Cartridge.ImpactForce);
		float damage = GetDamageForDistance(totalDistance + hit.distance);
		value = ImpactForceMultiplier * Mathf.Clamp(value, 0f, 1.5f) * 1.5f;
		physicalBehaviour.rigidbody.AddForceAtPosition(value * _003C_003Ec__DisplayClass82_.direction, origin, ForceMode2D.Force);
		physicalBehaviour.SendMessage("Shot", new Shot(hit.normal, hit.point, damage, triggerExplosiveOverride: true, Cartridge), SendMessageOptions.DontRequireReceiver);
		Action<CallbackParams> bulletEntryCallback2 = BulletEntryCallback;
		if (bulletEntryCallback2 != null)
		{
			obj = new CallbackParams
			{
				HitObject = hit.collider,
				Position = hit.point,
				Direction = _003C_003Ec__DisplayClass82_.direction,
				SurfaceNormal = hit.normal
			};
			bulletEntryCallback2(obj);
		}
		if (_003C_003Ec__DisplayClass82_.canExplode && ExplosiveRound)
		{
			_003CBallisticIteration_003Eg__explode_007C82_0(hit.point, ref _003C_003Ec__DisplayClass82_);
		}
		if ((bool)_003C_003Ec__DisplayClass82_.tracer)
		{
			_003C_003Ec__DisplayClass82_.tracer.transform.position = origin;
			_003C_003Ec__DisplayClass82_.tracer.transform.right = _003C_003Ec__DisplayClass82_.direction;
			_003C_003Ec__DisplayClass82_.tracer.SetPosition(1, Vector3.right * hit.distance);
		}
		yield return new WaitForSeconds(0.01f);
		shouldDoSplash = !TestForWaterHit(origin, _003C_003Ec__DisplayClass82_.direction, damage, shouldDoSplash);
		if (ShouldRicochet(_003C_003Ec__DisplayClass82_.direction, hit, physicalBehaviour))
		{
			RicochetBullet(_003C_003Ec__DisplayClass82_.direction, speed, iteration, totalDistance, _003C_003Ec__DisplayClass82_.tracer, hit);
		}
		else
		{
			ConnectedBehaviour.StartCoroutine(BallisticIteration(hit.point + _003C_003Ec__DisplayClass82_.direction * ThicknessStepSize, _003C_003Ec__DisplayClass82_.direction, speed - hardness, iteration + 1, totalDistance + hit.distance, hit.collider, _003C_003Ec__DisplayClass82_.tracer, shouldDoSplash, _003C_003Ec__DisplayClass82_.canExplode));
		}
	}

	private static void RandomiseCourse(float dampening, float diversion, ref Vector2 direction, ref float speed)
	{
		float deltaTime = Time.deltaTime;
		direction = (direction + diversion * deltaTime * UnityEngine.Random.insideUnitCircle).normalized;
		speed = Mathf.Lerp(speed, 0f, Utils.GetLerpFactorDeltaTime(dampening, deltaTime));
	}

	private void RicochetBullet(Vector2 direction, float speed, int iteration, float totalDistance, LineRenderer tracer, RaycastHit2D hit)
	{
		BulletRicochetCallback?.Invoke(new CallbackParams
		{
			HitObject = hit.collider,
			Position = hit.point,
			Direction = direction,
			SurfaceNormal = hit.normal
		});
		Vector2 direction2 = Vector2.Reflect(direction, hit.normal) + RandomisedAngle * 0.1f;
		ConnectedBehaviour.StartCoroutine(BallisticIteration(hit.point - hit.normal * 0.02f, direction2, speed, iteration + 1, totalDistance + hit.distance, hit.collider, tracer));
	}

	private bool TestForWaterHit(Vector2 origin, Vector2 direction, float damage, bool sendMessage)
	{
		RaycastHit2D hit = Physics2D.Raycast(origin, direction, MaxRange, WaterLayer);
		if ((bool)hit && hit.distance > 0.5f && hit.transform.gameObject.layer == 4)
		{
			if (sendMessage)
			{
				hit.transform.SendMessage("Shot", new Shot(hit.normal, hit.point, damage, triggerExplosiveOverride: true, Cartridge), SendMessageOptions.DontRequireReceiver);
			}
			return true;
		}
		return false;
	}

	private float CalculateHardness(PhysicalBehaviour phys)
	{
		float num = 1f - Mathf.Clamp01(phys.Properties.Softness + phys.Properties.Brittleness);
		return 2f * MaterialHardnessMultiplier * (4.5f * num) + phys.Properties.BulletSpeedAbsorptionPower;
	}

	private float SpeedMultiplierByDistance(float d)
	{
		return 1f / Mathf.Max(0.1f, Mathf.Sqrt(d * 0.2f));
	}

	private float DamageMultiplierByDistance(float d)
	{
		return Mathf.Clamp(1.5f / d + 0.7f / Mathf.Lerp(d, 0.8f, 0.992f), 0.5f, 10f);
	}

	private bool ShouldRicochet(Vector2 incoming, RaycastHit2D hit, PhysicalBehaviour phys)
	{
		if (!hit.transform)
		{
			return false;
		}
		float num = Mathf.Abs(Vector2.Dot(hit.normal, incoming));
		float num2 = Mathf.Clamp01(phys.Properties.Softness + phys.Properties.Brittleness);
		float num3 = 1f - (num2 * 150f + num);
		if (num3 > 0.05f)
		{
			return num3 * RicochetChanceMultiplier > UnityEngine.Random.value;
		}
		return false;
	}

	public void Dispose()
	{
		BulletEntryCallback = null;
		BulletExitCallback = null;
		BulletRicochetCallback = null;
		ConnectedBehaviour = null;
		Cartridge = null;
		foreach (LineRenderer tracer in tracers)
		{
			if ((bool)tracer && tracer.gameObject.activeSelf)
			{
				BulletTracerPool.Instance.Return(tracer.gameObject);
			}
		}
		tracers = null;
	}

	[CompilerGenerated]
	private void _003CBallisticIteration_003Eg__explode_007C82_0(Vector2 point, ref _003C_003Ec__DisplayClass82_0 P_1)
	{
		ExplosiveRoundParams.Position = point + P_1.direction * 0.5f;
		ExplosionCreator.Explode(ExplosiveRoundParams);
		P_1.canExplode = false;
	}

	[CompilerGenerated]
	private void _003CBallisticIteration_003Eg__removeTracer_007C82_1(ref _003C_003Ec__DisplayClass82_0 P_0)
	{
		if ((bool)P_0.tracer)
		{
			tracers.Remove(P_0.tracer);
			BulletTracerPool.Instance.Return(P_0.tracer.gameObject);
		}
	}
}
