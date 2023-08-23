using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRandom : BinBehaviour
{
	[Header("Spawner Random")]
	[SerializeField] protected SpawnerCtrl SpawnerCtrl;
	[SerializeField] protected float randomDelay = 1f;
	[SerializeField] protected float randomTimer = 0f;
	[SerializeField] protected float randomLimit = 9f;
	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadCtrl();
	}

	protected void LoadCtrl()
	{
		if (this.SpawnerCtrl != null) return;
		this.SpawnerCtrl = GetComponent<SpawnerCtrl>();
		Debug.Log(transform.name + ": LoadSpawnerCtrl", gameObject);
	}

	protected override void Start()
	{
		//this.JunkSpawning();
	}

	protected virtual void FixedUpdate()
	{
		this.Spawning();
	}

	protected virtual void Spawning()
	{
		if (this.RandomReachLimit()) return;

		this.randomTimer += Time.fixedDeltaTime;
		if (this.randomTimer < this.randomDelay) return;
		this.randomTimer = 0;

		Transform ranPoint = this.SpawnerCtrl.SpawnPoints.GetRandom();
		Vector3 pos = ranPoint.position;
		Quaternion rot = transform.rotation;

		Transform prefab = this.SpawnerCtrl.Spawner.RandomPrefab();
 		Transform obj = this.SpawnerCtrl.Spawner.Spawn(prefab, pos, rot);
		obj.gameObject.SetActive(true);
		
		//Invoke(nameof(this.JunkSpawning), 7f);
	}

	protected virtual bool RandomReachLimit()
	{
		int currentJunk = this.SpawnerCtrl.Spawner.SpawnedCount;
		return currentJunk >= this.randomLimit;
	}
}
