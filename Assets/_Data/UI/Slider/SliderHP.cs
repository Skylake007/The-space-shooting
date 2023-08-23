using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHP : BaseSlider
{
	[Header("HP")]
	[SerializeField] protected float maxHP = 100;
	[SerializeField] protected float currentHP = 70;

	protected override void FixedUpdate()
	{
		this.HPShowing();
	}
	protected override void OnChange(float newValue)
	{
		//Debug.Log("newValue: " + newValue);
	}

	protected virtual void HPShowing()
	{
		float hpPercent = this.currentHP / this.maxHP;
		this.slider.value = hpPercent;
	}

	public virtual void SetMaxHP(float maxHP)
	{
		this.maxHP = maxHP;	
	}

	public virtual void SetCurrentHP(float currentHP)
	{
		this.currentHP = currentHP;
	}
}
