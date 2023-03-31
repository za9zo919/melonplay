using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class OldSyringeBehaviour : MonoBehaviour
{
	[HideInInspector]
	public float[] Fingerprint;

	private SpriteRenderer spriteRenderer;

	private MaterialPropertyBlock materialProperty;

	private void Awake()
	{
		materialProperty = new MaterialPropertyBlock();
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.GetPropertyBlock(materialProperty);
		materialProperty.SetFloat(ShaderProperties.Get("_Direction"), 0f);
	}

	private void Start()
	{
		if (Fingerprint == null || Fingerprint.Length == 0)
		{
			CreateNewFingerprint();
		}
	}

	private void CreateNewFingerprint()
	{
		Fingerprint = new float[64];
		for (int i = 0; i < Fingerprint.Length; i++)
		{
			Fingerprint[i] = UnityEngine.Random.Range(-1f, 1f);
		}
	}

	private void Lodged(Stabbing stabbing)
	{
		if (stabbing.victim.TryGetComponent(out LimbBehaviour component) && !component.GetComponent(GetPoisonType()))
		{
			PoisonSpreadBehaviour obj = component.gameObject.AddComponent(GetPoisonType()) as PoisonSpreadBehaviour;
			obj.Limb = component;
			obj.Fingerprint = Fingerprint;
		}
	}

	public abstract Type GetPoisonType();

	private void ExitShot(Shot shot)
	{
		BreakSyringe();
	}

	private void Shot(Shot shot)
	{
		StartCoroutine(_003CShot_003Eg__WaitAFrame_007C9_0());
	}

	private void Break(Vector2 velocity)
	{
		BreakSyringe();
	}

	private void OnFragmentHit(float force)
	{
		BreakSyringe();
	}

	private void OnWillRenderObject()
	{
		materialProperty.SetColor(ShaderProperties.Get("_LiquidColour"), spriteRenderer.color);
		spriteRenderer.SetPropertyBlock(materialProperty);
	}

	private void BreakSyringe()
	{
		OldSyringeExplosionBehaviour component = UnityEngine.Object.Instantiate(Resources.Load<GameObject>("Prefabs/OldSyringeExplosion"), base.transform.position, Quaternion.identity).GetComponent<OldSyringeExplosionBehaviour>();
		component.Colour = spriteRenderer.color;
		component.PoisonType = GetPoisonType();
		component.Fingerprint = Fingerprint;
		UnityEngine.Object.Destroy(base.gameObject);
	}

	[CompilerGenerated]
	private IEnumerator _003CShot_003Eg__WaitAFrame_007C9_0()
	{
		yield return new WaitForSeconds(0.05f);
		BreakSyringe();
	}
}
