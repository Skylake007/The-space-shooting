using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarSpawner: Spawner
{
	private static HPBarSpawner instance;
	public static HPBarSpawner Instance => instance;

	public static string HPBar = "HPBar"; //obj name

	protected override void Awake()
	{
		base.Awake();
		if (HPBarSpawner.instance != null) Debug.Log("Only 1 HPBarSpawner allow");
		HPBarSpawner.instance = this;

	}
}
