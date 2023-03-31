using UnityEngine;

public class GripBehaviour : MonoBehaviour, Messages.IUse, Messages.IOnBeforeSerialise
{
	[SkipSerialisation]
	public PhysicalBehaviour PhysicalBehaviour;

	public PhysicalBehaviour CurrentlyHolding;

	public Vector3 GripPosition;

	private FixedJoint2D joint;

	private static readonly Collider2D[] buffer = new Collider2D[32];

	private Collider2D[] noCollide;

	[HideInInspector]
	public bool isHolding;

	[HideInInspector]
	public Vector2 NearestHoldingPos;

	[HideInInspector]
	public Vector2 Anchor;

	[HideInInspector]
	public Vector2 ConnectedAnchor;

	private void Awake()
	{
		PhysicalBehaviour = GetComponent<PhysicalBehaviour>();
	}

	private void Start()
	{
		noCollide = base.transform.root.GetComponentsInChildren<Collider2D>();
		if (isHolding && (bool)CurrentlyHolding)
		{
			Attach(CurrentlyHolding, NearestHoldingPos);
		}
	}

	public void Use(ActivationPropagation activation)
	{
		if (!isHolding)
		{
			PickUpNearestObject();
		}
		else
		{
			DropObject();
		}
	}

	public void DropObject()
	{
		if (!isHolding)
		{
			return;
		}
		isHolding = false;
		UnityEngine.Object.Destroy(joint);
		if (!CurrentlyHolding)
		{
			return;
		}
		Collider2D[] colliders = CurrentlyHolding.colliders;
		foreach (Collider2D collider2D in colliders)
		{
			Collider2D[] array = noCollide;
			foreach (Collider2D collider2D2 in array)
			{
				if ((bool)collider2D2 && (bool)collider2D)
				{
					IgnoreCollisionStackController.IgnoreCollisionSubstituteMethod(collider2D, collider2D2, ignore: false);
				}
			}
		}
		CurrentlyHolding.beingHeldByGripper = false;
		CurrentlyHolding.SendMessage("OnDrop", this, SendMessageOptions.DontRequireReceiver);
		CurrentlyHolding = null;
	}

	private void Update()
	{
		if (isHolding && !CurrentlyHolding)
		{
			DropObject();
		}
	}

	private void FixedUpdate()
	{
		if ((bool)CurrentlyHolding && PhysicalBehaviour.SimulateTemperature && CurrentlyHolding.SimulateTemperature)
		{
			Utils.AverageTemperature(PhysicalBehaviour, CurrentlyHolding, 0.02f);
		}
	}

	private void PickUpNearestObject()
	{
		Vector2 worldPoint = base.transform.TransformPoint(GripPosition);
		int num = Physics2D.OverlapCircleNonAlloc(base.transform.TransformPoint(GripPosition), GripPosition.z, buffer);
		PhysicalBehaviour physicalBehaviour = null;
		float num2 = float.MaxValue;
		for (int i = 0; i < num; i++)
		{
			Collider2D collider2D = buffer[i];
			if (Global.main.PhysicalObjectsInWorldByTransform.TryGetValue(collider2D.transform, out PhysicalBehaviour value))
			{
				float distance;
				Vector2 nearestLocalHoldingPoint = value.GetNearestLocalHoldingPoint(worldPoint, out distance);
				if (distance < num2)
				{
					num2 = distance;
					NearestHoldingPos = nearestLocalHoldingPoint;
					physicalBehaviour = value;
				}
			}
		}
		if ((bool)physicalBehaviour)
		{
			Attach(physicalBehaviour, NearestHoldingPos);
		}
	}

	private void Attach(PhysicalBehaviour phys, Vector2 otherLocalHoldingPosition)
	{
		isHolding = true;
		CurrentlyHolding = phys;
		phys.beingHeldByGripper = true;
		phys.transform.position += base.transform.TransformPoint(GripPosition) - phys.transform.TransformPoint(otherLocalHoldingPosition);
		joint = base.gameObject.AddComponent<FixedJoint2D>();
		joint.connectedBody = phys.rigidbody;
		joint.anchor = GripPosition;
		joint.connectedAnchor = otherLocalHoldingPosition;
		joint.enableCollision = false;
		Collider2D[] componentsInChildren = phys.transform.root.GetComponentsInChildren<Collider2D>();
		foreach (Collider2D collider2D in componentsInChildren)
		{
			Collider2D[] array = noCollide;
			foreach (Collider2D collider2D2 in array)
			{
				if ((bool)collider2D2 && (bool)collider2D)
				{
					IgnoreCollisionStackController.IgnoreCollisionSubstituteMethod(collider2D, collider2D2);
				}
			}
		}
		CurrentlyHolding.SendMessage("OnGripped", this, SendMessageOptions.DontRequireReceiver);
	}

	public void OnBeforeSerialise()
	{
		if ((bool)joint)
		{
			ConnectedAnchor = joint.connectedAnchor;
			NearestHoldingPos = ConnectedAnchor;
			Anchor = joint.anchor;
			GripPosition = Anchor;
		}
	}
}
