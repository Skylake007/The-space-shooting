using System;

[Serializable]
public class ItemInventory
{
	public string itemId;
	public ItemProfileSO itemProfile;
	public int itemCount = 0;
	public int maxStack = 7;
	public int upgradeLevels = 0;

	public virtual ItemInventory Clone()
	{
		ItemInventory item = new ItemInventory
		{
			itemId = ItemInventory.RandomId(),
			itemProfile = this.itemProfile,
			itemCount = this.itemCount,
			upgradeLevels = this.upgradeLevels
		};

		return item;
	}

	public static string RandomId() 
	{
		return RandomStringGenerator.Generate(27);
	}
}