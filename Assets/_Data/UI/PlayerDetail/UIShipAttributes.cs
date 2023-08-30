using System;
using System.Collections.Generic;
using UnityEngine;

public class UIShipAttributes: UIPlayerShipDetailAbstract
{
	[SerializeField] protected UIShipAttribute uiShipAttribute;
	[SerializeField] protected RectTransform rectTransform;
	[SerializeField] protected List<UIShipAttribute> attributes;

	protected override void Awake()
	{
		base.Awake();
		this.CreateAttributes();
	}

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadUIShipAttribute();
	}

	protected virtual void LoadUIShipAttribute()
	{
		if (this.uiShipAttribute != null) return;
		this.uiShipAttribute = GetComponentInChildren<UIShipAttribute>();
		this.rectTransform = this.uiShipAttribute.GetComponent<RectTransform>();
		Debug.LogWarning(transform.name + ": LoadUIShipAttribute", gameObject);
	}

	protected virtual void CreateAttributes()
	{
		float attributeHeight = this.rectTransform.sizeDelta.y;

		int index = 0;
		Vector3 pos;
		foreach (AttributeType type in System.Enum.GetValues(typeof(AttributeType)))
		{
			if (type == AttributeType.noAttribute) continue;

			UIShipAttribute newUI = Instantiate(this.uiShipAttribute, this.uiShipAttribute);
			newUI.name = this.uiShipAttribute.name;
			pos = newUI.transform.localPosition;
			pos.y = (index * attributeHeight) * -1;
			newUI.transform.localPosition = pos;

			this.attributes.Add(newUI);
			index++;
		}
		this.uiShipAttribute.gameObject.SetActive(false);
	}

	public virtual void ShowAttributes(PlayerShipCtrl playerShipCtrl)
	{
		Attribute attribute;
		UIShipAttribute uiShipAttribute;
		for (int i = 0; i < this.attributes.Count; i++)
		{
			attribute = playerShipCtrl.charAttributes.Attibutes[i];
			uiShipAttribute = this.attributes[i];
			uiShipAttribute.SetAttribute(attributes);
		}
	}
}
