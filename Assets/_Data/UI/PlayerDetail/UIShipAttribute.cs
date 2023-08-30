using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIShipAttribute: BinBehaviour
{
	[SerializeField] protected Attribute attribute;
	public Attribute Attribute => attribute;

	[SerializeField] protected TextMeshProUGUI txtAttribute;

	private void FixedUpdate()
	{
		this.ShowAttribute();
	}

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadTxtAttribute();
	}

	protected virtual void LoadTxtAttribute()
	{
		if (this.txtAttribute != null) return;
		this.txtAttribute = GetComponentInChildren<TextMeshProUGUI>();
		Debug.LogWarning(transform.name + ": LoadTxtAttribute", gameObject);
	}

	public virtual void SetAttribute(Attribute attribute)
	{
		this.attribute = attribute;
	}

	protected virtual void ShowAttribute()
	{
		if (this.attribute == null) return;
		if (attribute.type == AttributeType.noAttribute) return;
		string attrName = this.attribute.type.ToString();
		string txt = $"{attribute}: {this.attribute.value}";
		this.txtAttribute.text = txt;
	}
}
