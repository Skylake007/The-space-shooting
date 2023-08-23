using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityShield : BaseAbility
{
	[Header("Ability Shield")]
	[SerializeField] protected bool isShielding = false;
	[SerializeField] protected float timeShielding = 3f;
	[SerializeField] protected float activeShieldSpeed = 0.5f;
	[SerializeField] protected AbilityShieldCtrl abilityShieldCtrl;


	protected override void Start()
	{
		base.Start();
		this.DeactiveShield();
	}

	protected override void ResetValue()
	{
		base.ResetValue();
		this.timer = 5f;
		this.delay = 5f;
	}

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadShield();
	}

	protected virtual void LoadShield()
	{
		if (this.abilityShieldCtrl != null) return;
		this.abilityShieldCtrl = GetComponentInChildren<AbilityShieldCtrl>();
		Debug.LogWarning(transform.name + ": LoadShield", gameObject);
	
	}

	public virtual void Shield()
	{
		if (!this.isReady) return;
		if (this.isShielding) return;

		this.isShielding = true;
		Invoke(nameof(this.ShieldingFinish), this.activeShieldSpeed);

	}

	protected virtual void ShieldingFinish()
	{
		this.ActiveShield();
		this.isShielding = false;
		this.Active();
	}

	protected virtual void ActiveShield()
	{
		this.abilityShieldCtrl.gameObject.SetActive(true);
		Invoke(nameof(this.DeactiveShield), this.timeShielding);
	}

	protected virtual void DeactiveShield()
	{
		this.abilityShieldCtrl.gameObject.SetActive(false);
	}
}
