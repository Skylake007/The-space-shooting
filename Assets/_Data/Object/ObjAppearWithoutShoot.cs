using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjAppearWithoutShoot: ShootableObjetAbstract, IObjAppearObserver  
{
    [Header("Without shoot")]
    [SerializeField] protected ObjAppearing objAppearing;

	protected override void OnEnable()
	{
		base.OnEnable();
		this.RegisterAppearEvent();
	}
	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadObjAppearing();
	}
	protected virtual void LoadObjAppearing()
	{
		if (this.objAppearing != null) return;
		this.objAppearing = GetComponent<ObjAppearing>();
		Debug.LogWarning(transform.name + ": LoadObjAppearing ", gameObject);
	}

	protected virtual void RegisterAppearEvent()
	{
		this.objAppearing.ObserverAdd(this);
	}

	public void OnAppearStart()
	{
		this.shootableObjectCtrl.ObjShooting.gameObject.SetActive(false);
		this.shootableObjectCtrl.ObjLookAtTarget.gameObject.SetActive(false);
	}

	public void OnAppearFinish()
	{
		this.shootableObjectCtrl.ObjShooting.gameObject.SetActive(true);
		this.shootableObjectCtrl.ObjLookAtTarget.gameObject.SetActive(true);

		this.shootableObjectCtrl.Spawner.Hold(transform.parent);
	}
}
