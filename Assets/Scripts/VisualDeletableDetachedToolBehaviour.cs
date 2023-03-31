using UnityEngine;

public class VisualDeletableDetachedToolBehaviour : Hover
{
	public SpriteRenderer spriteRenderer;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		collider = base.gameObject.AddComponent<BoxCollider2D>();
	}

	protected override Bounds GetVisualBounds()
	{
		return spriteRenderer.bounds;
	}

	private void Update()
	{
		CheckMouseInput();
	}

	public override void OnMouseOverlapEvent(bool overlap)
	{
		base.OnMouseOverlapEvent(overlap);
		if (overlap && UserPreferenceManager.Current.ShowOutlines)
		{
			spriteRenderer.color = Color.red;
			spriteRenderer.gameObject.layer = LayerMask.NameToLayer("ScreenUI");
		}
		else
		{
			spriteRenderer.color = Color.white;
			spriteRenderer.gameObject.layer = LayerMask.NameToLayer("Default");
		}
	}

	public override void OnUserDelete()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}
}
