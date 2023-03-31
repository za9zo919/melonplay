using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

[SkipSerialisation]
public class AutomaticSentryController
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003C_003Ec__DisplayClass15_0
	{
		public AutomaticSentryController _003C_003E4__this;

		public Transform transform;
	}

	public float SightRange = 20f;

	public UnityEvent OnShoot = new UnityEvent();

	public UnityEvent OnSight = new UnityEvent();

	public LayerMask LayerMask;

	public float AimFuzziness = 0.0005f;

	private readonly List<LimbBehaviour> targetStack = new List<LimbBehaviour>();

	private static readonly RaycastHit2D[] losBuffer = new RaycastHit2D[5];

	private readonly Collider2D[] buffer = new Collider2D[256];

	private LimbBehaviour currentTarget;

	private float t;

	private int previousPersonID;

	private const float interval = 0.5f;

	public bool HasTarget => currentTarget;

	public AutomaticSentryController()
	{
		t = 0f;
	}

	public void GetTargetMotorSpeed(Transform transform, Vector2 worldspaceBarrelPosition, Vector2 worldspaceBarrelDirection, out float motorSpeed)
	{
		_003C_003Ec__DisplayClass15_0 _003C_003Ec__DisplayClass15_ = default(_003C_003Ec__DisplayClass15_0);
		_003C_003Ec__DisplayClass15_._003C_003E4__this = this;
		_003C_003Ec__DisplayClass15_.transform = transform;
		motorSpeed = 0f;
		if (t > 0.5f && !currentTarget)
		{
			t = 0f;
			for (int i = 0; i < Physics2D.OverlapCircleNonAlloc(worldspaceBarrelPosition, SightRange, buffer, LayerMask); i++)
			{
				Collider2D collider2D = buffer[i];
				LimbBehaviour component;
				if (!(collider2D.transform.root == _003C_003Ec__DisplayClass15_.transform.root) && collider2D.TryGetComponent(out component) && !targetStack.Contains(component) && component.IsConsideredAlive && HasLineOfSight(component, _003C_003Ec__DisplayClass15_.transform, worldspaceBarrelPosition))
				{
					if (component.RoughClassification == LimbBehaviour.BodyPart.Torso)
					{
						targetStack.Add(component);
					}
					else
					{
						targetStack.Insert(0, component);
					}
				}
			}
		}
		else
		{
			t += Time.deltaTime;
		}
		if (targetStack.Count == 0)
		{
			return;
		}
		if (!currentTarget)
		{
			currentTarget = targetStack.Last();
			if (!currentTarget)
			{
				_003CGetTargetMotorSpeed_003Eg__skip_007C15_0(ref _003C_003Ec__DisplayClass15_);
				return;
			}
		}
		if (currentTarget.IsConsideredAlive && Vector2.Distance(currentTarget.transform.position, _003C_003Ec__DisplayClass15_.transform.position) < SightRange)
		{
			if (!HasLineOfSight(currentTarget, _003C_003Ec__DisplayClass15_.transform, worldspaceBarrelPosition))
			{
				_003CGetTargetMotorSpeed_003Eg__skip_007C15_0(ref _003C_003Ec__DisplayClass15_);
			}
			else
			{
				motorSpeed = GetMotorSpeed(_003C_003Ec__DisplayClass15_.transform, worldspaceBarrelDirection);
			}
		}
		else
		{
			_003CGetTargetMotorSpeed_003Eg__skip_007C15_0(ref _003C_003Ec__DisplayClass15_);
		}
	}

	private bool HasLineOfSight(LimbBehaviour t, Transform transform, Vector2 worldspacePos)
	{
		Vector2 a = (Vector2)t.transform.position - worldspacePos;
		UnityEngine.Debug.DrawLine(worldspacePos, worldspacePos + a * 10f, Color.yellow);
		int num = Physics2D.LinecastNonAlloc(worldspacePos, t.transform.position, losBuffer, LayerMask);
		if (num == 0)
		{
			return false;
		}
		for (int i = 0; i < num; i++)
		{
			RaycastHit2D raycastHit2D = losBuffer[i];
			if (raycastHit2D.transform.root != t.transform.root && raycastHit2D.transform.root != transform.root && Global.main.PhysicalObjectsInWorldByTransform[raycastHit2D.transform].AbsorbsLasers)
			{
				return false;
			}
		}
		return true;
	}

	private float GetMotorSpeed(Transform transform, Vector2 worldspaceDir)
	{
		int instanceID = currentTarget.Person.GetInstanceID();
		if (previousPersonID != instanceID)
		{
			OnSight?.Invoke();
			previousPersonID = instanceID;
		}
		Vector2 vector = (currentTarget.transform.position - transform.position).normalized;
		if (Vector2.Dot(vector, worldspaceDir) > 1f - AimFuzziness)
		{
			OnShoot?.Invoke();
		}
		return Mathf.Clamp(0f - Vector2.SignedAngle(worldspaceDir, vector), -120f, 120f);
	}

	[CompilerGenerated]
	private void _003CGetTargetMotorSpeed_003Eg__skip_007C15_0(ref _003C_003Ec__DisplayClass15_0 P_0)
	{
		if ((bool)currentTarget)
		{
			UnityEngine.Debug.DrawLine(currentTarget.transform.position, P_0.transform.position, Color.red);
		}
		targetStack.RemoveAt(targetStack.Count - 1);
		currentTarget = null;
	}
}
