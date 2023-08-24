using System;
using UnityEngine;

public class ShipStandPos : BinBehaviour
{
	public AbilityObjectCtrl abilityObjectCtrl;

	public virtual void SetObject(AbilityObjectCtrl abilityObjectCtrl)
	{
		this.abilityObjectCtrl = abilityObjectCtrl;
	}

	public virtual bool IsOccupied()
	{
		return this.abilityObjectCtrl != null;
	}
}