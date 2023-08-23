using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjShooting : BinBehaviour
{
	[SerializeField] protected bool isShooting = false;
	[SerializeField] protected float shootDelay = 1f;
	[SerializeField] protected float shootTimer = 0f;

	private void Update()
	{
		this.IsShooting();
	}
	void FixedUpdate()
	{
		this.Shooting();
	}

	protected virtual void Shooting()
	{
		if (!this.isShooting) return;

		this.shootTimer += Time.fixedDeltaTime;
		if (this.shootTimer < this.shootDelay) return;
		this.shootTimer = 0;

		Vector3 spawnPos = transform.position;
		Quaternion rotation = transform.parent.rotation;

		Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.BulletTwo, spawnPos, rotation);
		if (newBullet == null) return;
		newBullet.gameObject.SetActive(true);

		BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
		bulletCtrl.SetShotter(transform.parent);

		//Debug.Log("Shotting");
	}

	protected virtual void ShootingByEnemy()
	{
		if (!this.isShooting) return;

		this.shootTimer += Time.fixedDeltaTime;
		if (this.shootTimer < this.shootDelay) return;
		this.shootTimer = 0;

		Vector3 spawnPos = transform.position;
		Quaternion rotation = transform.parent.rotation;

		Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.BulletOne, spawnPos, rotation);
		if (newBullet == null) return;
		newBullet.gameObject.SetActive(true);

		BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
		bulletCtrl.SetShotter(transform.parent);

		//Debug.Log("Shotting");
	}

	protected abstract bool IsShooting();
}
