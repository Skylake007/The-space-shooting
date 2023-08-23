using System;
using System.Collections;
using UnityEngine;

public class ChargeCtrl : BaseAbility
{
	[Header("Charge Ctrl")]
	private static ChargeCtrl instance;
	public static ChargeCtrl Instance => instance;
	[SerializeField] protected Transform model;
	public Transform Model => model;

	protected override void Awake()
	{
		base.Awake();
		if (ChargeCtrl.instance != null) Debug.LogError("Only 1 ChargeCtrl allow to exist");
		ChargeCtrl.instance = this;
	}

	protected override void Start()
	{
		base.Start();
		gameObject.SetActive(false);
	}

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadModel();
	}

	protected virtual void LoadModel()
	{
		if (this.model != null) return;
		this.model = transform.Find("Model");
		Debug.LogWarning(transform.name + ": LoadModel", gameObject);
	}
}