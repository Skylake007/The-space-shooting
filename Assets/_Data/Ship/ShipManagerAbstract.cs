using System.Collections.Generic;
using UnityEngine;

public class ShipManagerAbstract : BinBehaviour
{
	[Header("Ship Manager Abstract")]
	public ShipManagerCtrl shipManagerCtrl;

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadShipManagerCtrl();
	}

	protected virtual void LoadShipManagerCtrl()
	{
		if (this.shipManagerCtrl != null) return;
		this.shipManagerCtrl = transform.parent.GetComponent<ShipManagerCtrl>();
		Debug.LogWarning(transform.name + ": LoadShipManagerCtrl", gameObject);
	}
}