using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : BinBehaviour
{
	[SerializeField] protected List<PlayerShipCtrl> ships = new List<PlayerShipCtrl>();
	[SerializeField] protected List<ShipSpawnPos> spawnPoints = new List<ShipSpawnPos>();
	[SerializeField] protected List<ShipStandPos> standPoints = new List<ShipStandPos>();

	public List<ShipSpawnPos> SpawnPoints => spawnPoints;
	public List<ShipStandPos> StandPoints => standPoints;

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadSpawnPoints();
		this.LoadStandPoints();
	}

	protected virtual void LoadSpawnPoints()
	{
		if (this.spawnPoints.Count > 0) return;
		Transform points = transform.Find("SpawnPoints");
		foreach (Transform point in points)
		{
			ShipSpawnPos shipSpawnPos = point.GetComponent<ShipSpawnPos>();
			this.spawnPoints.Add(shipSpawnPos);
		}
		Debug.LogWarning(transform.name + ": LoadSpawnPoints", gameObject);
	}

	protected virtual void LoadStandPoints()
	{
		if (this.standPoints.Count > 0) return;
		Transform points = transform.Find("StandPoints");
		ShipStandPos shipStandPos;

		foreach (Transform point in points)
		{
			shipStandPos = point.GetComponent<ShipStandPos>();
			this.standPoints.Add(shipStandPos);
		}
		Debug.LogWarning(transform.name + ": LoadStandPoints", gameObject);
	}

	public virtual void AddShip(PlayerShipCtrl ship)
	{
		this.ships.Add(ship);
	}
}
