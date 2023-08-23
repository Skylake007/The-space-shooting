using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UINotification : BinBehaviour
{
	[Header("UI Inventory")]
	private static UINotification instance;
	public static UINotification Instance => instance;

	protected bool isOpen = false;
	
	protected override void Awake()
	{
		base.Awake();
		if (UINotification.Instance != null) Debug.LogError("Only 1 UIInventory allow to exist");
		UINotification.instance = this;
	}
	protected override void Start()
	{
		base.Start();
		this.Close();
	}

	protected virtual void FixedUpdate()
	{
		//this.ShowItem();	
	}

	public virtual void Toggle()
	{
		this.isOpen = !this.isOpen;
		if (this.isOpen) this.Open();
		else this.Close();
	}

	public virtual void Open()
	{
		this.gameObject.SetActive(true);
		this.isOpen = true;
	}

	public virtual void Close()
	{
		this.gameObject.SetActive(false);
		this.isOpen = false;
	}

	protected virtual void ShowItems()
	{
		
	}

}
