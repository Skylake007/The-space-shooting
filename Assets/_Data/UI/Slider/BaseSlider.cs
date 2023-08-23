using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSlider : BinBehaviour
{
	[Header("Base Slider")]
	[SerializeField] protected Slider slider;
	protected override void Start()
	{
		base.Start();
		this.AddOnChange();
	}

	protected virtual void FixedUpdate()
	{
	//for override
	}

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadSlider();
	}

	protected virtual void LoadSlider()
	{
		if (this.slider != null) return;
		this.slider = GetComponent<Slider>();
		Debug.LogWarning(transform.name + ": LoadSlider", gameObject);
	}

	protected virtual void AddOnChange()
	{
		this.slider.onValueChanged.AddListener(this.OnChange);
	}

	protected abstract void OnChange(float newValue);
}
