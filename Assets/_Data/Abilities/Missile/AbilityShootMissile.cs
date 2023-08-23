using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityShootMissile : BaseAbility
{
	[Header("Ability Shoot Missile")]
	[SerializeField] protected bool isShooting = false;
	[SerializeField] protected float shootSpeed = 0.5f;

	public virtual void ShootingMissile()
	{
		if (!this.isReady) return;
		if (this.isShooting) return;

		this.isShooting = true;
		Invoke(nameof(this.ShootFinish), this.shootSpeed);
	}

	protected virtual void ShootFinish()
	{
		this.isShooting = false;
		this.Active();
	}

	protected virtual void SpawnMissile(GameObject target)
	{
		Vector3 spawnPos = transform.position;
		Quaternion rotation = transform.parent.rotation;
		Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.MissileOne, spawnPos, rotation);
		if (newBullet == null) return;

		newBullet.gameObject.SetActive(true);
		BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
		bulletCtrl.SetShotter(PlayerCtrl.Instance.CurrentShip.transform);
		//bulletCtrl.GetComponentInChildren<ObjLookAtEnemy>().SetTarget(target);
		bulletCtrl.GetComponentInChildren<ObjLookAtEnemy>();
	}
}
