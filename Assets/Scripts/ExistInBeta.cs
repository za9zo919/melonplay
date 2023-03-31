using UnityEngine;

public class ExistInBeta : MonoBehaviour
{
	private void Start()
	{
		string text = "1.25 preview 3".ToLower();
		base.gameObject.SetActive(text.Contains("beta") || text.Contains("preview"));
	}
}
