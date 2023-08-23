using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
	private static ItemDropSpawner instance;
	public static ItemDropSpawner Instance => instance;

	[SerializeField] protected float gameDropRate = 0.5f;
	 
	protected override void Awake()
	{
		base.Awake();
		if (ItemDropSpawner.instance != null) Debug.LogError("Only 1 ItemDropSpawner");
		ItemDropSpawner.instance = this;
	}

	public virtual List<ItemDropRate> Drop(List<ItemDropRate> dropList, Vector3 pos, Quaternion rot)
	{
		List<ItemDropRate> dropItems = new List<ItemDropRate>();

		if (dropList.Count < 1) return dropItems;

		dropItems = this.DropItems(dropList);
		foreach (ItemDropRate itemDropRate in dropItems)
		{
			ItemCode itemCode = itemDropRate.itemSO.itemCode;
			Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
			if (itemDrop == null) continue;
			itemDrop.gameObject.SetActive(true);
		}

		return dropItems;
	}

	protected virtual float GameDropRate()
	{
		float dropRateFromItems = 0.5f;
		return this.gameDropRate + dropRateFromItems;
	}

	protected virtual List<ItemDropRate> DropItems(List<ItemDropRate> items)
	{
		List<ItemDropRate> droppedItems = new List<ItemDropRate>();

		float rate, itemRate;
		int itemDropMore;

		foreach (ItemDropRate item in items)
		{
			rate = Random.Range(0, 1f);
			itemRate = item.dropRate/100000f * this.gameDropRate;
			itemDropMore = Mathf.FloorToInt(itemRate);
			if (itemDropMore > 0)
			{
				itemRate -= itemDropMore;
				for (int i = 0; i < itemDropMore; i++)
				{
					Debug.Log("DROP MORE");
					droppedItems.Add(item);
				}
			}
			//Debug.Log("======================");
			//Debug.Log("item: " + item.itemSO.itemName);
			//Debug.Log("Rate: " + itemRate +"/"+ rate);

			if (rate <= itemRate)
			{
				//Debug.Log("DROPED");
				droppedItems.Add(item);
			}
		}

		return droppedItems;
	}


	public virtual Transform DropFromInventory(ItemInventory itemInventory, Vector3 pos, Quaternion ros)
	{

		ItemCode itemCode = itemInventory.itemProfile.itemCode;
		Transform itemDrop = this.Spawn(itemCode.ToString(), pos, ros);
		if (itemDrop == null) return null;
		itemDrop.gameObject.SetActive(true);
		ItemCtrl itemCtrl = itemDrop.GetComponent<ItemCtrl>();
		itemCtrl.SetItemInventory(itemInventory); 

		return itemDrop;
	}
}
