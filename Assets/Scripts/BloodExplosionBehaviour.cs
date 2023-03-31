using UnityEngine;

public class BloodExplosionBehaviour : MonoBehaviour
{
	public ParticleSystem Debris1;

	public ParticleSystem Debris2;

	public FancyBloodSplatController FancyBloodSplatController;

	public void SetColor(Color color)
	{
		set(Debris1, color);
		set(Debris2, color);
		if ((bool)FancyBloodSplatController)
		{
			FancyBloodSplatController.DecalColourMultiplier = color;
		}
		static void set(ParticleSystem ps, Color color)
		{
			ParticleSystem.MainModule main = ps.main;
			main.startColor = color;
		}
	}
}
