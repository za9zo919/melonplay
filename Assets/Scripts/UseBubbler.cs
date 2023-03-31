using UnityEngine;

public class UseBubbler : MonoBehaviour, Messages.IUse, Messages.IUseContinuous
{
	public void Use(ActivationPropagation activation)
	{
		base.transform.parent.SendMessage("Use", activation, SendMessageOptions.DontRequireReceiver);
	}

	public void UseContinuous(ActivationPropagation activation)
	{
		ContinuousActivationBehaviour.AssertState();
		base.transform.parent.SendMessage("UseContinuous", activation, SendMessageOptions.DontRequireReceiver);
	}
}
