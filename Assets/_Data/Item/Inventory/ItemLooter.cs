using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]

public class ItemLooter : InventoryAbstract
{
	//[SerializeField] protected Inventory inventory;
	[SerializeField] protected SphereCollider _collider;
	[SerializeField] protected Rigidbody _rigidbody;
	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadInventory();
		this.LoadTrigger();
		this.LoadRigidbody();
	}

	protected virtual void LoadInventory()
	{
		if (this.inventory != null) return;
		this.inventory = transform.parent.GetComponent<Inventory>();
		Debug.Log(transform.name + ": LoadInventory", gameObject);
	}

	protected virtual void LoadRigidbody()
	{
		if (this._rigidbody != null) return;
		this._rigidbody = transform.GetComponent<Rigidbody>();
		this._rigidbody.useGravity = false;
		this._rigidbody.isKinematic = true;
		Debug.LogWarning(transform.name + ": LoadRigibody", gameObject);
	}

	protected virtual void LoadTrigger()
	{
		if (this._collider != null) return;
		this._collider = transform.GetComponent<SphereCollider>();
		this._collider.isTrigger = true;
		this._collider.radius = 0.3f;
		Debug.LogWarning(transform.name + ": LoadTringger", gameObject);
	}

	protected virtual void OnTriggerEnter(Collider collider)
	{
		ItemPickupable itemPickupable = collider.GetComponent<ItemPickupable>();
		if (itemPickupable == null) return;

		ItemInventory itemInventory = itemPickupable.ItemCtrl.ItemInventory;
		if (this.inventory.AddItem(itemInventory))
		{
			itemPickupable.Picked(); //Pickup ore and destroy obj
		}
		//Debug.Log(collider.name);
		//Debug.Log(collider.transform.parent.name);
	}
}
