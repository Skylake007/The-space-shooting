using System;
using System.Collections;
using UnityEngine;

public class AbilityLazer : BaseAbility
{
	[Header("Ability Lazer")]
	[SerializeField] protected bool isShooting = false;
	[SerializeField] protected float shootSpeed = 0.5f;
	[SerializeField] protected ChargeCtrl chargeCtrl; 
	[SerializeField] protected BulletCtrl bulletCtrl;
	


	protected override void ResetValue()
	{
		base.ResetValue();
		this.timer = 5f;
		this.delay = 5f;
	}

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadChargeCtrl();
		this.LoadBulletCtrl();
	}

	protected virtual void LoadChargeCtrl()
	{
		if (this.chargeCtrl != null) return;
		this.chargeCtrl = GetComponentInChildren<ChargeCtrl>();
		Debug.LogWarning(transform.name + ": LoadChargeCtrl", gameObject);
	}

	protected virtual void LoadBulletCtrl()
	{
		if (this.bulletCtrl != null) return;
		this.bulletCtrl = GetComponentInChildren<BulletCtrl>();
		Debug.LogWarning(transform.name + ": LoadBulletCtrl", gameObject);
	}

	public virtual void ShootingLazer()
	{
		if (!this.isReady) return;
		if (this.isShooting) return;

		this.isShooting = true;
		Invoke(nameof(this.ShootFinish), this.shootSpeed);
	}

	protected virtual void ShootFinish()
	{
		this.ChargeLazer();
		this.isShooting = false;
	}

	protected virtual void ChargeLazer()
	{
		this.chargeCtrl.gameObject.SetActive(true);
		Invoke(nameof(this.SpawnLazer), 2f);
	}

	protected virtual void SpawnLazer()
	{
		this.chargeCtrl.gameObject.SetActive(false);
		this.bulletCtrl.gameObject.SetActive(true);
		Invoke(nameof(this.ResetAbilityLazer), 3f);
	}


	protected virtual void ResetAbilityLazer()
	{
		this.bulletCtrl.gameObject.SetActive(false);
		this.Active();
	}
}