using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipsSpawn : ShipManagerAbstract
{
	[Header("Enemy ships Spawn")]
	[SerializeField] protected float timer = 0;
	[SerializeField] protected float delay = 2;
	[SerializeField] protected int limit = 2;

	protected virtual void FixedUpdate()
	{
		this.Spawning();
	}

	protected virtual void Spawning()
	{
		this.timer += Time.fixedDeltaTime;
		if (this.timer <= this.delay) return;
		if (this.limit <= this.shipManagerCtrl.shipsManager.Ships.Count) return;
		this.timer = 0;

		Transform point;
		ShipMoveFoward shipMoveForward;

		point = this.GetSpawnPos();
		Transform shipObj = EnemyShipsSpawner.Instance.Spawn(this.GetEnemyName(), point.position, Quaternion.identity);
		EnemyCtrl shipCtrl = shipObj.GetComponent<EnemyCtrl>();
		this.shipManagerCtrl.shipsManager.AddShip(shipCtrl);

		shipObj.gameObject.SetActive(true);
		point = this.shipManagerCtrl.pointsManager.StandPoints[0].transform;
		shipMoveForward = shipCtrl.ObjMovement as ShipMoveFoward;
		if (shipMoveForward != null) shipMoveForward.SetMoveTarget(point);
	}

	protected virtual Transform GetSpawnPos()
	{
		Transform respawnPoint;
		respawnPoint = this.shipManagerCtrl.pointsManager.SpawnPoints[0];
		return respawnPoint;
	}

	protected virtual string GetEnemyName()
	{
		return "Enemy_1";
	}
}
