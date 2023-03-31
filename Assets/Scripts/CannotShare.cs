using System.Collections.Generic;
using UnityEngine;

public class CannotShare : MonoBehaviour, Messages.IOnAfterDeserialise
{
	public SpawnableAsset Substitute;

	public void OnAfterDeserialise(List<GameObject> gameObjects)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(Substitute.Prefab, base.transform.position, base.transform.rotation);
		gameObject.AddComponent<AudioSourceTimeScaleBehaviour>();
		gameObject.AddComponent<SerialiseInstructions>().OriginalSpawnableAsset = Substitute;
		UndoControllerBehaviour.RegisterAction(new ObjectCreationAction(gameObject));
		UnityEngine.Object.Destroy(base.gameObject);
	}
}
