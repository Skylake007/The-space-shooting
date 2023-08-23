using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityShootMissileAllEnemy: AbilityShootMissile
{

	protected override void ResetValue()
	{
		base.ResetValue();
		this.timer = 5f;
		this.delay = 5f;
	}

	protected override void ShootFinish()
	{
		this.ShootAllEnemies();
		base.ShootFinish();
	}

	protected virtual void ShootAllEnemies()
	{
		List<EnemyCtrl> enemies = new List<EnemyCtrl>(FindObjectsOfType<EnemyCtrl>());
		foreach (EnemyCtrl enemy in enemies)
		{
			this.SpawnMissile(enemy.gameObject);
		}
	}
}
