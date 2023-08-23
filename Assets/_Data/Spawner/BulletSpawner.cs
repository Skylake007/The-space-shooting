using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
	private static BulletSpawner instance;
	public static BulletSpawner Instance { get => instance;}

	public static string BulletOne = "Bullet_1";
	public static string BulletTwo = "Bullet_2";

	public static string MissileOne = "Missile_1";

	protected override void Awake()
	{
		base.Awake();
		if (BulletSpawner.instance != null) Debug.Log("Only 1 BulletSpawner allow");
		BulletSpawner.instance = this;

	}
}
