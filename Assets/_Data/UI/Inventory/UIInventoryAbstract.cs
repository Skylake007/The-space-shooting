using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIInventoryAbstract : BinBehaviour
{

	[Header("Inventory Abstract")]
	[SerializeField] protected UIInventoryCtrl inventoryCtrl;
	public UIInventoryCtrl UIInventoryCtrl => inventoryCtrl;

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadUIInventoryCtrl();
	}

	protected virtual void LoadUIInventoryCtrl()
	{
		if (this.inventoryCtrl != null) return;
		this.inventoryCtrl = transform.parent.GetComponent<UIInventoryCtrl>();
		Debug.LogWarning(transform.name + ": LoadUIInventoryCtrl", gameObject);
	}
}
