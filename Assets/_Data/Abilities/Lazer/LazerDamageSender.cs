using System;
using System.Collections;
using UnityEngine;

public class LazerDamageSender : DamageSender
{
	[Header("Lazer Damage Sender")]
	[SerializeField] protected BulletCtrl bulletCtrl;
	public BulletCtrl BulletCtrl => bulletCtrl;

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadBulletCtrl();
	}

	protected virtual void LoadBulletCtrl()
	{
		if (this.bulletCtrl != null) return;
		this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
		Debug.LogWarning(transform.name + ": LoadBulletCtrl", gameObject);
	}

	public override void Send(Transform obj)
	{
		DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
		if (damageReceiver == null) return;
		this.Send(damageReceiver);

		if (obj.parent.transform == this.bulletCtrl.Shooter) return;
		//this.createImpactFX(obj);
		this.CreateFXImpacts();
	}
}