using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDrop : InventoryAbstract
{
	[Header("Item Drop")]
	[SerializeField] protected int maxLevel = 9;

	
	protected override void Start()
	{
		base.Start();
	}

	protected virtual void Test()
	{
		//this.DropItemIndex(0);
	}

	protected virtual void DropItemIndex(int itemIndex, Vector3 droppPos, Quaternion dropRot)
	{
		ItemInventory itemInventory = this.inventory.Items[itemIndex];

		Vector3 dropPos = transform.position;
		dropPos.x += 1;

		ItemDropSpawner.Instance.DropFromInventory(itemInventory, dropPos, transform.rotation);
		this.inventory.Items.Remove(itemInventory);  
	}
}
