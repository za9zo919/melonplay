using System;
using UnityEngine;

public abstract class LinkDeviceBehaviour : Hover
{
	public Vector2 LocalOffset;

	public Vector2 OtherLocalOffset;

	public PhysicalBehaviour Other;

	[SkipSerialisation]
	protected LineRenderer lineRenderer;

	[SkipSerialisation]
	protected PhysicalBehaviour PhysicalBehaviour;

	[SkipSerialisation]
	protected Material initialMaterial;

	[SkipSerialisation]
	private EdgeCollider2D edgeCollider;

	[SkipSerialisation]
	protected SpriteRenderer fromSpriteRenderer;

	[SkipSerialisation]
	protected SpriteRenderer toSpriteRenderer;

	[SkipSerialisation]
	private readonly Vector2[] colliderPoints = new Vector2[2];

	protected virtual void Awake()
	{
		PhysicalBehaviour = GetComponent<PhysicalBehaviour>();
	}

	protected virtual void Start()
	{
		if (!Other)
		{
			UnityEngine.Object.Destroy(this);
			return;
		}
		string str = Guid.NewGuid().ToString();
		GameObject gameObject = new GameObject("link source " + str);
		gameObject.AddComponent<Optout>();
		gameObject.transform.SetParent(base.transform);
		gameObject.transform.localPosition = LocalOffset;
		lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.useWorldSpace = true;
		lineRenderer.sharedMaterial = (initialMaterial = GetWireMaterial());
		lineRenderer.widthMultiplier = GetWireWidth();
		Color color2 = lineRenderer.startColor = (lineRenderer.endColor = GetWireColor());
		collider = (edgeCollider = gameObject.AddComponent<EdgeCollider2D>());
		collider.isTrigger = true;
		edgeCollider.points = colliderPoints;
		fromSpriteRenderer = PrepareSpriteRendererOrder(PhysicalBehaviour, gameObject);
		GameObject gameObject2 = new GameObject("link target " + str);
		gameObject2.AddComponent<Optout>();
		gameObject2.transform.SetParent(Other.transform);
		gameObject2.transform.localPosition = OtherLocalOffset;
		toSpriteRenderer = PrepareSpriteRendererOrder(Other, gameObject2);
		gameObject.AddComponent<VisualDeletableDetachedToolBehaviour>();
		gameObject2.AddComponent<VisualDeletableDetachedToolBehaviour>();
		ModAPI.InvokeLinkCreated(this, this);
		AfterInitialise();
	}

	private void Update()
	{
		if (Global.main.GetPausedMenu())
		{
			return;
		}
		if (!fromSpriteRenderer || !toSpriteRenderer)
		{
			UnityEngine.Object.Destroy(this);
			return;
		}
		lineRenderer.enabled = Global.main.ShowLimbStatus;
		if (Global.main.ShowLimbStatus)
		{
			lineRenderer.SetPosition(0, base.transform.TransformPoint(LocalOffset));
			lineRenderer.SetPosition(1, Other.transform.TransformPoint(OtherLocalOffset));
			collider.enabled = true;
		}
		else
		{
			collider.enabled = false;
		}
		CheckMouseInput();
		if (IsMouseInsideBounds)
		{
			CalculateEdgeCollider();
		}
	}

	public override void OnMouseOverlapEvent(bool overlap)
	{
		base.OnMouseOverlapEvent(overlap);
		if (overlap && UserPreferenceManager.Current.ShowOutlines)
		{
			lineRenderer.sharedMaterial = Resources.Load<Material>("Materials/DeleteWire");
			lineRenderer.gameObject.layer = LayerMask.NameToLayer("ScreenUI");
		}
		else
		{
			lineRenderer.sharedMaterial = initialMaterial;
			lineRenderer.gameObject.layer = LayerMask.NameToLayer("Default");
		}
	}

	private SpriteRenderer PrepareSpriteRendererOrder(PhysicalBehaviour phys, GameObject container)
	{
		SpriteRenderer component = phys.GetComponent<SpriteRenderer>();
		int sortingLayerID = component.sortingLayerID;
		int sortingOrder = component.sortingOrder;
		SpriteRenderer spriteRenderer = container.AddComponent<SpriteRenderer>();
		spriteRenderer.sortingLayerID = sortingLayerID;
		spriteRenderer.sortingOrder = sortingOrder + 1;
		spriteRenderer.sprite = GetDeviceSprite();
		container.AddComponent<ExistInDetailView>();
		return spriteRenderer;
	}

	protected abstract Sprite GetDeviceSprite();

	protected abstract float GetWireWidth();

	protected abstract Color GetWireColor();

	protected abstract Material GetWireMaterial();

	protected abstract void AfterInitialise();

	protected override Bounds GetVisualBounds()
	{
		return lineRenderer.bounds;
	}

	public override void OnUserDelete()
	{
	}

	protected void CalculateEdgeCollider()
	{
		colliderPoints[0] = Vector2.zero;
		colliderPoints[1] = edgeCollider.transform.InverseTransformPoint(Other.transform.TransformPoint(OtherLocalOffset));
		edgeCollider.points = colliderPoints;
		edgeCollider.edgeRadius = lineRenderer.widthMultiplier / 1.5f;
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		if ((bool)fromSpriteRenderer)
		{
			UnityEngine.Object.Destroy(fromSpriteRenderer.gameObject);
		}
		if ((bool)toSpriteRenderer)
		{
			UnityEngine.Object.Destroy(toSpriteRenderer.gameObject);
		}
	}
}
