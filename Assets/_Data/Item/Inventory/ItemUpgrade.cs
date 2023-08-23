using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUpgrade : InventoryAbstract
{
	[Header("Item Upgrade")]
	[SerializeField] protected int maxLevel = 9;

	public List<ItemInventory> items;

	protected override void Start()
	{
		base.Start();
	}

	protected virtual void Test()
	{
		this.UpgradeItem(0);
	}

	public virtual bool UpgradeItem(int itemIndex)
	{
		if (itemIndex >= this.inventory.Items.Count) return false;

		ItemInventory itemInventory = this.inventory.Items[itemIndex];
		if (itemInventory.itemCount < 1) return false;

		List<ItemRecipe> upgradeLevels = itemInventory.itemProfile.upgradeLebels;
		if (!this.ItemUpgradeable(upgradeLevels)) return false;
		if (!this.HaveEnoughIngredients(upgradeLevels, itemInventory.upgradeLevels)) return false;

		this.DeductIngredients(upgradeLevels, itemInventory.upgradeLevels);
		itemInventory.upgradeLevels++;

		return true;
	}

	protected virtual bool ItemUpgradeable(List<ItemRecipe> upgradeLevels)
	{
		//Check item can be upgrade
		if (upgradeLevels.Count == 0) return false;
		return true;
	}

	protected virtual bool HaveEnoughIngredients(List<ItemRecipe> upgradeLebels, int currentLevel)
	{
		ItemCode itemCode;
		int itemCount;

		if (currentLevel > upgradeLebels.Count)
		{
			Debug.LogError("Item cant upgrade anymore, current: " + currentLevel);
			return false;
		}

		ItemRecipe currentRecipeLebel = upgradeLebels[currentLevel];
		foreach (ItemRecipeIngredient ingredient in currentRecipeLebel.ingredients)
		{
			itemCode = ingredient.itemProfile.itemCode;
			itemCount = ingredient.itemCount;

			if (!this.inventory.ItemCheck(itemCode, itemCount)) return false;
		}

		return true;
	}

	public virtual bool ItemCheck(ItemCode itemCode, int numberCheck)
	{
		int totalCount = this.ItemTotalCount(itemCode);
		return totalCount >= numberCheck;
	}

	public virtual int ItemTotalCount(ItemCode itemCode)
	{
		int totalCount = 0;
		foreach (ItemInventory itemInventory in this.items)
		{
			if (itemInventory.itemProfile.itemCode != itemCode) continue;
			totalCount += itemInventory.itemCount;
		}

		return totalCount;
	}

	protected virtual void DeductIngredients(List<ItemRecipe> upgradeLevels, int currentLevel)
	{
		ItemCode itemCode;
		int itemCount;

		ItemRecipe currentRecipeLevel = upgradeLevels[currentLevel];
		foreach (ItemRecipeIngredient ingredient in currentRecipeLevel.ingredients)
		{
			itemCode = ingredient.itemProfile.itemCode;
			itemCount = ingredient.itemCount;

			this.inventory.DeductItem(itemCode, itemCount);
		}
	}

	public virtual void DeductItem(ItemCode itemCode, int deductCount)
	{
		ItemInventory itemInventory;
		int deduct;
		for (int i = this.items.Count - 1; i >= 0; i--)
		{
			if (deductCount <= 0) break;

			itemInventory = this.items[i];
			if (itemInventory.itemProfile.itemCode != itemCode) continue;

			if (deductCount > itemInventory.itemCount)
			{
				deduct = itemInventory.itemCount;
				deductCount -= itemInventory.itemCount;
			}
			else
			{
				deduct = deductCount;
				deductCount = 0;
			}

			itemInventory.itemCount -= deduct;
		}

		this.ClearEmptySlot();
	}

	protected virtual void ClearEmptySlot()
	{  //dont use foreach with dynamic list

		ItemInventory itemInventory;
		for (int i = 0; i < this.items.Count; i++)
		{
			itemInventory = this.items[i];
			if (itemInventory.itemCount == 0) this.items.RemoveAt(i); 
		}
	}
}
