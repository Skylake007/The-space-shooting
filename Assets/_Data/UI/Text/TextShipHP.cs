using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextShipHP : BaseText
{
	protected virtual void FixedUpdate()
	{
		this.UpdateShipHP();
	}

	protected virtual void UpdateShipHP()
	{
		//if (PlayerCtrl.Instance.CurrentShip == null) return;
		//int hpMax = PlayerCtrl.Instance.CurrentShip.DamageReceiver.HPMax;
		//int hp = PlayerCtrl.Instance.CurrentShip.DamageReceiver.HP;
		//this.text.SetText(hp + "/" + hpMax);
		//Debug.LogWarning("<b>"+ hp / hpMax +"</b>");
	}
}
