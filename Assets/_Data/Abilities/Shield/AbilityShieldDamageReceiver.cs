using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityShieldDamageReceiver : DamageReceiver
{
	[SerializeField] protected AbilityShieldCtrl abilityShieldCtrl;

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadShield();
	}

	protected virtual void LoadShield()
	{
		if (this.abilityShieldCtrl != null) return;
		this.abilityShieldCtrl = GetComponentInParent < AbilityShieldCtrl>();
		Debug.LogWarning(transform.name + ": LoadShield", gameObject);
	}

	protected override void OnDead()
	{
		this.abilityShieldCtrl.gameObject.SetActive(false);
	}
}
