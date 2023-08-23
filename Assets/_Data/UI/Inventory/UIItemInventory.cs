using UnityEngine;
using UnityEngine.UI;

public class UIItemInventory : BinBehaviour
{
	[Header("UI Item Inventory")]
	[SerializeField] protected ItemInventory itemInventory;
	public ItemInventory ItemInventory => itemInventory;

	[SerializeField] protected Text itemName;
	public Text ItemName => itemName;

	[SerializeField] protected Text itemNumber;
	public Text ItemNumber => itemNumber;

	[SerializeField] protected Image itemSprite;
	public Image ItemSprite => itemSprite;

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadItemName();
		this.LoadItemNumber();
		this.LoadItemImage();
	}

	protected virtual void LoadItemName()
	{
		if (this.itemName != null) return;
		this.itemName = transform.Find("ItemName").GetComponent<Text>();
		Debug.Log(transform.name + ": LoadItemName", gameObject);
	}

	protected virtual void LoadItemNumber()
	{
		if (this.itemNumber != null) return;
		this.itemNumber = transform.Find("ItemNumber").GetComponent<Text>();
		Debug.Log(transform.name + ": LoadItemNumber", gameObject);
	}

	protected virtual void LoadItemImage()
	{
		if (this.itemSprite != null) return;
		this.itemSprite = transform.Find("ItemImage").GetComponent<Image>();
		Debug.Log(transform.name + ": LoadItemImage", gameObject);
	}

	public virtual void ShowItem(ItemInventory item)
	{
		this.itemInventory = item;
		this.itemName.text = this.itemInventory.itemProfile.itemName;
		this.itemNumber.text = this.itemInventory.itemCount.ToString();
		this.itemSprite.sprite = this.itemInventory.itemProfile.sprite;
	}
}
