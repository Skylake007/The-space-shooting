using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : BinBehaviour
{
	[SerializeField] protected List<PlayerShipCtrl> ships = new List<PlayerShipCtrl>();
	[SerializeField] protected List<Transform> spawnPoints = new List<Transform>();
	[SerializeField] protected List<Transform> standPoints = new List<Transform>();

	public List<Transform> SpawnPoints => spawnPoints;
	public List<Transform> StandPoints => standPoints;

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
			this.spawnPoints.Add(point);
		}
		Debug.LogWarning(transform.name + ": LoadSpawnPoints", gameObject);
	}

	protected virtual void LoadStandPoints()
	{
		if (this.standPoints.Count > 0) return;
		Transform points = transform.Find("StandPoints");
		foreach (Transform point in points)
		{
			this.standPoints.Add(point);
		}
		Debug.LogWarning(transform.name + ": LoadStandPoints", gameObject);
	}

	public virtual void AddShip(PlayerShipCtrl ship)
	{
		this.ships.Add(ship);
	}

	//public virtual void SpawnShips()
	//{
	//	Debug.Log("SpawnShips");

	//	int index = 0;
	//	foreach (ShipCtrl shipCtrl in this.ships)
	//	{
	//		this.SpawnShip(shipCtrl, index);
	//		index++;
	//	}
	//}

}
