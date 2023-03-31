using UnityEngine;

[CreateAssetMenu(menuName = "PPG/Decal Descriptor")]
public class DecalDescriptor : ScriptableObject
{
	public Color Color = Color.white;

	public float IgnoreRadius = 0.2f;

	public Sprite[] Sprites;
}
