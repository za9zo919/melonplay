using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomEventBehaviour : MonoBehaviour
{
	[Serializable]
	public class RandomEvent
	{
		public UnityEvent Actions = new UnityEvent();

		public float Delay;
	}

	[SkipSerialisation]
	public List<RandomEvent> Events = new List<RandomEvent>();

	[SkipSerialisation]
	public float ChancePerSecond;

	private void Update()
	{
		float num = Time.deltaTime * ChancePerSecond;
		if (!(UnityEngine.Random.value > num))
		{
			foreach (RandomEvent @event in Events)
			{
				if (@event.Actions != null)
				{
					if (@event.Delay < float.Epsilon)
					{
						@event.Actions.Invoke();
					}
					else
					{
						StartCoroutine(Utils.DelayCoroutine(@event.Delay, @event.Actions.Invoke));
					}
				}
			}
		}
	}
}
