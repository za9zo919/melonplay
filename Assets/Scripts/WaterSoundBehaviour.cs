using UnityEngine;

public class WaterSoundBehaviour : MonoBehaviour
{
	public AudioSource AudioSource;

	public Bounds AudioRect;

	public float SoftRange = 20f;

	private void Update()
	{
		Vector3 position = Global.main.camera.transform.position;
		position.z = 0f;
		Vector3 vector = base.transform.InverseTransformPoint(position);
		float magnitude = (base.transform.TransformPoint(AudioRect.ClosestPoint(vector)) - position).magnitude;
		float num = Mathf.Max(0f, Mathf.Abs(AudioRect.min.y - vector.y)) / AudioRect.size.y;
		num *= num;
		AudioSource.volume = Mathf.Clamp01((SoftRange - magnitude) * num);
	}
}
