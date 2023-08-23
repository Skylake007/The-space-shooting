using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : BinBehaviour
{
	[SerializeField] protected Transform model;
	[SerializeField] protected JunkDespawn junkDespawn;
	[SerializeField] protected ShootableObjectSO shootableObjectSO;

	public Transform Model => model;
	public JunkDespawn JunkDespawn => junkDespawn;
	public ShootableObjectSO ShootableObjectSO => shootableObjectSO;

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadModel();
		this.LoadJunkDespawn();
		this.LoadJunkSO();
	}

	protected virtual void LoadModel()
	{
		if (this.model != null) return;
		this.model = transform.Find("Model");
		Debug.Log(transform.name + ": LoadModel", gameObject);
	}

	protected virtual void LoadJunkDespawn()
	{
		if (this.junkDespawn != null) return;
		this.junkDespawn = transform.GetComponentInChildren<JunkDespawn>();
		Debug.LogWarning(transform.name + ": LoadJunkDespawn", gameObject);
	}

	protected virtual void LoadJunkSO()
	{
		if (this.shootableObjectSO != null) return;
		string resPath = "ShootableObject/Junk/" + transform.name;
		this.shootableObjectSO = Resources.Load<ShootableObjectSO>(resPath);
		Debug.LogWarning(transform.name + ": LoadJunkSO " + resPath, gameObject);
		//Debug.Log(transform.name + ": LoadJunkSO " + this.junkSO, gameObject);
	}
}
