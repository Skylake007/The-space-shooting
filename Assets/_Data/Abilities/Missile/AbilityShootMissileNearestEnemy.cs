using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityShootMissileNearestEnemy : AbilityShootMissile
{

	protected override void ResetValue()
	{
		base.ResetValue();
		this.timer = 5f;
		this.delay = 5f;
	}

	protected override void ShootFinish()
	{
		this.ShootNeareastEnemy();
		base.ShootFinish();
	}

	protected virtual void ShootNeareastEnemy()
	{
		List<EnemyCtrl> enemies = new List<EnemyCtrl>(FindObjectsOfType<EnemyCtrl>());
		GameObject closestEnemy = null;
		float closestDistance = float.MaxValue;
		foreach (EnemyCtrl enemy in enemies)
		{
			float distance = Vector2.Distance(transform.position, enemy.transform.position);
			if (distance < closestDistance)
			{
				closestDistance = distance;
				closestEnemy = enemy.gameObject;
			}
		}

		if (closestEnemy == null) return;
		this.SpawnMissile(closestEnemy);
	}
}
