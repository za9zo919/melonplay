using UnityEngine;

public class MotorisedHingeBehaviour : MonoBehaviour, Messages.IUse
{
	public bool Activated;

	public float Delta = 90f;

	[SkipSerialisation]
	public Transform IndicatorArm;

	[SkipSerialisation]
	public AudioSource AudioSource;

	[SkipSerialisation]
	public HingeJoint2D Hinge;

	[SkipSerialisation]
	public PhysicalBehaviour PhysicalBehaviour;

	private void Start()
	{
		SetDelta(Delta);
		PhysicalBehaviour.ContextMenuOptions.Buttons.AddRange(new ContextMenuButton[1]
		{
			new ContextMenuButton("servoSetDelta", "Set target angle", "Set the target angle of the servo", delegate
			{
				Utils.OpenFloatInputDialog(Delta, this, delegate(MotorisedHingeBehaviour w, float v)
				{
					w.SetDelta(v);
				}, "Set servo delta", "Angle");
			})
			{
				LabelWhenMultipleAreSelected = "Set servo target angle"
			}
		});
	}

	public void Use(ActivationPropagation activation)
	{
		Activated = !Activated;
	}

	public void FixedUpdate()
	{
		JointMotor2D motor = Hinge.motor;
		motor.motorSpeed = (2f + PhysicalBehaviour.Charge) * Mathf.DeltaAngle(Hinge.jointAngle, Activated ? GetScaledDelta() : 0f);
		Hinge.motor = motor;
		float num = Mathf.Abs(Hinge.jointSpeed) * 0.1f;
		if (num > 0.5f)
		{
			if (!AudioSource.isPlaying)
			{
				AudioSource.Play();
			}
			AudioSource.volume = Mathf.Clamp01(num * num);
		}
		else if (AudioSource.isPlaying)
		{
			AudioSource.Stop();
		}
	}

	private float GetScaledDelta()
	{
		return Delta * (float)((base.transform.localScale.x > 0f) ? 1 : (-1));
	}

	private void OnDisable()
	{
		Hinge.useMotor = false;
		AudioSource.Stop();
	}

	private void OnEnable()
	{
		Hinge.useMotor = true;
	}

	public void SetDelta(float v)
	{
		Delta = v;
		IndicatorArm.localEulerAngles = new Vector3(0f, 0f, Delta);
	}
}
