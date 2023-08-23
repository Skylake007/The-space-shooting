using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerCtrl : BinBehaviour
{
	[SerializeField] protected JunkSpawner junkSpawner;
	public JunkSpawner JunkSpawner { get => junkSpawner; }

	[SerializeField] protected SpawnPoints spawnPoints;
	public SpawnPoints SpawnPoints => spawnPoints;

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadJunkSpawner();
		this.LoadSpawnPoints();
	}

	protected virtual void LoadJunkSpawner()
	{
		if (this.junkSpawner != null) return;
		this.junkSpawner = GetComponent<JunkSpawner>();
		Debug.Log(transform.name + ": LoadJunkSpawner", gameObject);
	}

	protected void LoadSpawnPoints()
	{
		if (this.spawnPoints != null) return;
		this.spawnPoints = Transform.FindObjectOfType<SpawnPoints>();
		Debug.Log(transform.name + ": LoadSpawnPoints", gameObject);
	}
}