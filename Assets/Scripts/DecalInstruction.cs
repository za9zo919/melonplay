using UnityEngine;

public struct DecalInstruction
{
	public DecalDescriptor type
	{
		get;
		set;
	}

	public Vector2 globalPosition
	{
		get;
		set;
	}

	public float size
	{
		get;
		set;
	}

	public Color colourMultiplier
	{
		get;
		set;
	}

	public DecalInstruction(DecalDescriptor type, Vector2 globalPosition, float size = 1f)
	{
		this = default(DecalInstruction);
		this.type = type;
		this.globalPosition = globalPosition;
		this.size = Mathf.Max(0.05f, size);
		colourMultiplier = Color.white;
	}

	public DecalInstruction(DecalDescriptor type, Vector2 globalPosition, Color color, float size = 1f)
	{
		this = default(DecalInstruction);
		this.type = type;
		this.globalPosition = globalPosition;
		this.size = Mathf.Max(0.05f, size);
		colourMultiplier = color;
	}
}
