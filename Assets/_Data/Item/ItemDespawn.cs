using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDespawn : DespawnByDistance
{
	public override void DespawnObject()
	{
		ItemDropSpawner.Instance.Despawn(transform.parent);
	}

	protected override void ResetValue()
	{
		this.ResetValue();
		this.disLimit = 70f;
	}
}
