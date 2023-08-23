using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDied : HidenObj
{
	[Header("Ship HP")]
	[SerializeField] protected float currentHP = 0f;
	[SerializeField] protected bool IsDead = false;

	protected override bool CanHiding()
	{
		return IsDead;
	}

	protected override void Start()
	{
		base.Start();
		this.IsDead = false;
	}

	protected override void FixedUpdate()
	{
		base.FixedUpdate();
		this.IsShipDead();
	}

	protected virtual void IsShipDead()
	{
		int hpMax = PlayerCtrl.Instance.CurrentShip.DamageReceiver.HPMax;
		int hp = PlayerCtrl.Instance.CurrentShip.DamageReceiver.HP;

		if (hp <= 0)
		{
			this.currentHP = hp;
			Debug.LogWarning("SHIPHP=====================\n " + currentHP);
			this.IsDead = true;
			this.OnDeadFX();
			UINotification.Instance.Open();
		}
		else {
			this.IsDead = false;
			PlayerCtrl.Instance.CurrentShip.gameObject.SetActive(true);
		}
	}

	protected virtual void OnDeadFX()
	{
		string fxName = this.GetOnDeadFXName();
		Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
		fxOnDead.gameObject.SetActive(true);
	}
	protected virtual string GetOnDeadFXName()
	{
		return FXSpawner.smoke1;
	}
}
