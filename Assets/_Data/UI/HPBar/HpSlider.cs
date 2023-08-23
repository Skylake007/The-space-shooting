using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpSlider : BaseSlider
{
	[Header("UI HP Ship")]
	[SerializeField] protected float maxHP = 50;
	[SerializeField] protected float currentHP = 50;
	protected override void OnChange(float newValue)
	{
		//Debug.Log("newValue: " + newValue);
	}
	protected override void FixedUpdate()
	{
		this.HPShowing();
	}

	protected virtual void HPShowing()
	{
		if (PlayerCtrl.Instance.CurrentShip == null) return;

		int hpMax = PlayerCtrl.Instance.CurrentShip.DamageReceiver.HPMax;
		int hp = PlayerCtrl.Instance.CurrentShip.DamageReceiver.HP;
		float hpPercent = hp / maxHP;
		this.slider.value = hpPercent;
	}
}
