using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : BinBehaviour
{
	[SerializeField] protected ItemDespawn itemDespawn;
	public ItemDespawn ItemDespawn => itemDespawn;

	[SerializeField] protected ItemInventory itemInventory;
	public ItemInventory ItemInventory => itemInventory;

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadItemDespawn();
		this.LoadInventory();
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		this.ResetItem();
	}
	protected virtual void LoadItemDespawn()
	{
		if (this.itemDespawn != null) return;
		this.itemDespawn = transform.GetComponentInChildren<ItemDespawn>();
		Debug.Log(transform.name + ": LoadItemDespawn", gameObject);
	}

	public virtual void SetItemInventory(ItemInventory itemInventory) 
	{
		this.itemInventory = itemInventory.Clone();

		//this.itemInventory = new ItemInventory();
		//this.itemInventory.itemProfile = itemInventory.itemProfile;
		//this.itemInventory.itemCount = itemInventory.itemCount;
		//this.itemInventory.upgradeLevels = itemInventory.upgradeLevels; 


		/* Key passing parameters by Values or by Reference
		 *  int x = 2;
		 *  int y = 0;
		 *  y = x //y = 2;
		 *  x =3 // x = 3; y = 2;
		 *  
		 *  ItemInventory shipInventory_1 = new ItemInventory();
		 *  shipInventory_1.UpgradeLevel = 3;
		 *  
		 *  ItemInventory dropItem_1 = shipInventory_1;
		 *  //dropItem_1.upgradeLevel = 3;
		 *  
		 *  dropItem_1.upgradeLevel = 0;
		 *  shipInventory_1.upgradeLevel = 0;
		 * 
		 */
	}

	protected virtual void LoadInventory()
	{
		if (this.itemInventory.itemProfile != null) return;
		ItemCode itemCode = ItemCodeParser.FromString(transform.name);
		ItemProfileSO itemProfile = ItemProfileSO.FindByItemCode(itemCode);
		this.itemInventory.itemProfile = itemProfile;
		this.ResetItem();
		Debug.Log(transform.name + ": LoadInventory", gameObject);
	}

	protected virtual void ResetItem()
	{
		this.itemInventory.itemCount = 1;
		this.itemInventory.upgradeLevels = 0;
	}
}
