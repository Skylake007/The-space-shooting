using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipSpawn : ShipManagerAbstract
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

		ShipStandPos playerStandPos = this.GetPlayerStandPos();
		if (playerStandPos == null) return; 

		ShipSpawnPos spawnPoint = this.GetSpawnPos(playerStandPos);
		if (spawnPoint == null) return;

		Transform shipObj = EnemyShipsSpawner.Instance.Spawn(this.GetEnemyName(), spawnPoint.transform.position, Quaternion.identity);
		EnemyCtrl shipCtrl = shipObj.GetComponent<EnemyCtrl>();
		this.shipManagerCtrl.shipsManager.AddShip(shipCtrl);

		ShipStandPos standPos = this.GetStandPos(spawnPoint);
		if (standPos == null) return;

		shipObj.gameObject.SetActive(true);

		ShipMoveFoward shipMoveForward = shipCtrl.ObjMovement as ShipMoveFoward;
		if (shipMoveForward != null)
		{
			shipMoveForward.SetMoveTarget(standPos.transform);
			standPos.SetAbilityObjectCtrl(shipCtrl);
		}
	}

	protected virtual ShipStandPos GetStandPos(ShipSpawnPos spawnPos)
	{
		ShipStandPos standPos = null;

		List<ShipStandPos> pointions = this.shipManagerCtrl.pointsManager.StandPoints;
		foreach (ShipStandPos shipStandPos in pointions)
		{
			if (shipStandPos.LaneId != spawnPos.LaneId) continue;
			if (shipStandPos.IsOccupied()) continue;

			standPos = shipStandPos; break;
		}

		return standPos;
	}
	protected virtual ShipStandPos GetPlayerStandPos()
	{
		ShipStandPos pos = null;
		List<ShipStandPos> playerStandPoses = PlayerShipsCtrl.Instance.pointsManager.StandPoints;
		foreach (ShipStandPos playerStandPos in playerStandPoses)
		{
			if (!playerStandPos.IsOccupied()) continue;

			pos = playerStandPos;
			break;
		}
		return pos;
	}

	protected virtual ShipSpawnPos GetSpawnPos(ShipStandPos playerStandPos)
	{
		ShipSpawnPos spawnPos = null;

		List<ShipSpawnPos> positions = this.shipManagerCtrl.pointsManager.SpawnPoints;
		foreach (ShipSpawnPos shipSpawnPos in positions)
		{
			if (shipSpawnPos.LaneId != playerStandPos.LaneId) continue;
			if (shipSpawnPos.IsOccupied()) continue;

			spawnPos = shipSpawnPos;
			break;
		}
		return spawnPos;
	}

	protected virtual string GetEnemyName()
	{
		return "Enemy_1";
	}
}
