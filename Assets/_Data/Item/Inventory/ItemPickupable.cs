using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickupable : ItemAbstract
{
	[Header("Item Pickupable")]
	[SerializeField] protected SphereCollider _collider;

	public static ItemCode String2ItemCode(string itemName)
	{
		try
		{
			return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
		}
		catch (ArgumentException e)
		{
			Debug.LogError(e.ToString());
			return ItemCode.NoItem;
		}
	}

	public virtual void OnMouseDown()
	{
		Debug.Log(transform.parent.name);
		//PlayerShipsCtrl.Instance.inventory.AddItem
		////TODO: use new inventory
	}

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadTrigger();
	}

	protected virtual void LoadTrigger()
	{
		if (this._collider != null) return;
		this._collider = transform.GetComponent<SphereCollider>();
		this._collider.isTrigger = true;
		this._collider.radius = 0.2f;
		Debug.LogWarning(transform.name + ": LoadTrigger", gameObject);
	}

	public virtual void Picked()
	{
		//Debug.LogWarning("Item picked dispawn");
		this.itemCtrl.ItemDespawn.DespawnObject();
	}

	public virtual ItemCode GetItemCode()
	{
		return ItemPickupable.String2ItemCode(transform.parent.name);
	}
}
