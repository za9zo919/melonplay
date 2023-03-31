using UnityEngine;

[NotDocumented]
public class Vila : MonoBehaviour
{
	public string OffsetName = "_Offset";

	public string OrthoName = "_Ortho";

	public Material material;

	private Camera cam;

	private void Awake()
	{
		cam = Camera.main;
	}

	private void OnWillRenderObject()
	{
		Vector2 v = cam.transform.position - base.transform.position;
		material.SetVector(ShaderProperties.Get(OffsetName), v);
		material.SetFloat(ShaderProperties.Get(OrthoName), cam.orthographicSize);
	}
}
