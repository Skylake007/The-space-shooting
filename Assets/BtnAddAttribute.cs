using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnAddAttribute : BaseButton
{
    public UIShipAttribute uiShipAttribute;
    public UIPlayerShipDetailCtrl uiPlayerShipDetailCtrl;

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadUIShipAttribute();
		this.LoadUIPlayerShipDetail();
	}

	protected virtual void LoadUIShipAttribute()
	{
		if (this.uiShipAttribute != null) return;
		this.uiShipAttribute = transform.parent.GetComponent<UIShipAttribute>();
		Debug.LogWarning(transform.name + ": LoadUIShipAttribute", gameObject);
	}

	protected virtual void LoadUIPlayerShipDetail()
	{
		if (this.uiPlayerShipDetailCtrl != null) return;
		this.uiPlayerShipDetailCtrl = transform.parent.parent.parent.GetComponent<UIPlayerShipDetailCtrl>();
		Debug.LogWarning(transform.name + ": LoadUIPlayerShipDetail", gameObject);
	}

	protected override void OnClick()
	{
		AttributeType attributeType = this.uiShipAttribute.Attribute.type;
		this.uiPlayerShipDetailCtrl.playerShipCtrl.charAttributes.Add(attributeType,1);
	}
}

    