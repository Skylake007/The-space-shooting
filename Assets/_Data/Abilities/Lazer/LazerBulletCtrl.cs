using System;
using System.Collections;
using UnityEngine;

public class LazerBulletCtrl : BulletCtrl
{
	[Header("Lazer Bullet Ctrl")]
	[SerializeField] protected AbilityLazer abilityLazer;
	public AbilityLazer AbilityLazer => abilityLazer;

	protected override void Start()
	{
		base.Start();
		gameObject.SetActive(false);
	}

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadAbilityLazer();
		this.LoadShooter();
	}

	protected virtual void LoadAbilityLazer()
	{
		if (this.abilityLazer != null) return;
		this.abilityLazer = transform.parent.GetComponent<AbilityLazer>();
		Debug.LogWarning(transform.name + ": LoadAbilityLazer", gameObject);
	}

	protected virtual void LoadShooter()
	{
		if (this.shooter != null) return;
		this.shooter = abilityLazer.Abilities.AbilityObjectCtrl.transform;
		Debug.LogWarning(transform.name + ": LoadShooter", gameObject);
	}
}