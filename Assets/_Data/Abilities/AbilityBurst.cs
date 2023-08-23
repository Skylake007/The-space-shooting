using System;
using System.Collections;
using UnityEngine;

public class AbilityBurst: BaseAbility
{
	[Header("Ability Burst")]
	[SerializeField] protected bool isShooting = false;
	[SerializeField] protected float shootSpeed = 0.5f;
	[SerializeField] protected Transform spawnPoint;

	[SerializeField] protected int burstCount = 5;
	[SerializeField] protected int bulletsPerBurst = 6;
	[SerializeField] [Range(0, 359)] private float angleSpread = 160f;
	[SerializeField] private float startingDistance = 0.1f;
	[SerializeField] private float timeBetweenBurst = 0.3f;
	[SerializeField] private float resetTime = 0.5f;
	[SerializeField] private bool stagger;
	[Tooltip("Stagger has to be enabled for oscillate to work perperly")]
	[SerializeField] private bool oscillate;


	protected override void ResetValue()
	{
		base.ResetValue();
		this.timer = 5f;
		this.delay = 5f;
	}

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadSpawnPoint();
	}

	protected virtual void LoadSpawnPoint()
	{
		if (this.spawnPoint != null) return;
		this.spawnPoint = GameObject.Find("SpawnPoint").transform;
		Debug.LogWarning(transform.name + ": LoadSpawnPoint", gameObject);
	}

	public virtual void BurstBullet()
	{
		if (!this.isReady) return;
		if (this.isShooting) return;

		this.isShooting = true;
		Invoke(nameof(this.BurstFinish), this.shootSpeed);
	}

	protected virtual void BurstFinish()
	{
		StartCoroutine(ShootRoutine());
		this.isShooting = false;
		this.Active();
	}

	protected IEnumerator ShootRoutine()
	{
		float timeBetweenBullet = 0f;
		float startAngle, curentAngle, angleStep, endAngle;

		this.TargetConeOfInfluence(out startAngle, out curentAngle, out angleStep, out endAngle);

		if (this.stagger) timeBetweenBullet = timeBetweenBurst / this.bulletsPerBurst;

		for (int i = 0; i < this.burstCount; i++)
		{
			if (!oscillate)
			{
				this.TargetConeOfInfluence(out startAngle, out curentAngle, out angleStep, out endAngle);
			}
			if (oscillate && i % 2 != 1)
			{
				this.TargetConeOfInfluence(out startAngle, out curentAngle, out angleStep, out endAngle);
			}
			else if (oscillate)
			{
				curentAngle = endAngle;
				endAngle = startAngle;
				startAngle = curentAngle;
				angleStep *= -1;
			}

			for (int j = 0; j < this.bulletsPerBurst; j++)
			{
				Vector2 pos = FindBulletSpawnPos(curentAngle);
				Quaternion rot = transform.parent.parent.rotation;
				Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.BulletOne, pos, rot);

				if (newBullet != null)
				{
					newBullet.gameObject.SetActive(true);
					BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
					bulletCtrl.SetShotter(transform.parent.parent);
				}

				curentAngle += angleStep;

				if (stagger) yield return new WaitForSeconds(timeBetweenBullet);
			}

			curentAngle = startAngle;

			if (!stagger) yield return new WaitForSeconds(this.timeBetweenBurst);
		}

		yield return new WaitForSeconds(this.resetTime);
		this.isShooting = false;
	}

	protected void TargetConeOfInfluence(out float startAngle, out float currentAngle, out float angleStep, out float endAngle)
	{
		Vector2 targetDirection = InputManager.Instance.MouseWorldPosition - this.spawnPoint.position;
		float targetAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
		startAngle = targetAngle;
		endAngle = targetAngle;
		currentAngle = targetAngle;
		float halfAngleSpread = 0f;
		angleStep = 0f;
		if (this.angleSpread != 0)
		{
			angleStep = this.angleSpread / (this.bulletsPerBurst - 1);
			halfAngleSpread = angleSpread / 2f;
			startAngle = targetAngle - halfAngleSpread;
			endAngle = targetAngle + halfAngleSpread;
			currentAngle = startAngle;
		}
	}

	private Vector2 FindBulletSpawnPos(float currentAngle)
	{
		float x = this.spawnPoint.position.x + this.startingDistance * Mathf.Cos(currentAngle * Mathf.Deg2Rad);
		float y = this.spawnPoint.position.y + this.startingDistance * Mathf.Sin(currentAngle * Mathf.Deg2Rad);
		Vector2 pos = new Vector2(x, y);
		return pos;
	}
}