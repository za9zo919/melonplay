using UnityEngine;

public class LEDBulbBehaviour : MonoBehaviour, Messages.IUse
{
	public Color Color;

	[SkipSerialisation]
	public SpriteRenderer LightSprite;

	[SkipSerialisation]
	public SpriteRenderer GlowSprite;

	[SkipSerialisation]
	public SpriteRenderer BulbMask;

	[SkipSerialisation]
	public PhysicalBehaviour PhysicalBehaviour;

	[SkipSerialisation]
	public float MinBrightness = 0.2f;

	[SkipSerialisation]
	public float MaxCharge = 5f;

	public bool Activated;

	private float lastIntensity = float.MaxValue;

	private bool colourCached;

	private void Start()
	{
		PhysicalBehaviour.ContextMenuOptions.Buttons.Add(new ContextMenuButton(() => !ColorpickerDialogBehaviour.IsOpen, "setBulbColour", "Change colour", "Change the light colour", delegate
		{
			Utils.OpenColourInputDialog(Color, "Pick a colour", "Set colour for selected lights", delegate(LEDBulbBehaviour obj, Color c)
			{
				obj.Color = c;
				obj.colourCached = false;
				UpdateBulbMaskColour();
			});
		}));
		UpdateActivation();
		UpdateBulbMaskColour();
	}

	public void UpdateBulbMaskColour()
	{
		Color color = Color;
		Color.RGBToHSV(color, out float H, out float S, out float _);
		color = Color.HSVToRGB(H, S, 1f);
		color.a = 0.53f;
		BulbMask.color = color;
	}

	public void Use(ActivationPropagation activation)
	{
		if (base.enabled)
		{
			Activated = !Activated;
			UpdateActivation();
		}
	}

	private void OnDisable()
	{
		Activated = false;
		UpdateActivation();
	}

	private void UpdateActivation()
	{
		SpriteRenderer lightSprite = LightSprite;
		bool enabled = GlowSprite.enabled = Activated;
		lightSprite.enabled = enabled;
		colourCached = false;
	}

	private void Update()
	{
		float num = Utils.MapRange(0f, MaxCharge, MinBrightness, 1f, PhysicalBehaviour.Charge);
		if (colourCached)
		{
			if (!(Mathf.Abs(lastIntensity - num) > 0.01f))
			{
				return;
			}
			lastIntensity = num;
			colourCached = false;
		}
		Color color = Color * num;
		color.a = 1f;
		LightSprite.color = color;
		GlowSprite.color = color * 0.4f;
		colourCached = true;
	}
}
