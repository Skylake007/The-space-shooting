using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : BinBehaviour
{
	private static GameCtrl instance;
	public static GameCtrl Instance => instance;
	public Camera MainCamera => mainCamera;

	[SerializeField] protected Camera mainCamera;

	protected override void Awake()
	{
		//Debug.Log(transform.name + ": Awake", gameObject);

		base.Awake();
		if (GameCtrl.instance != null) Debug.LogError("Only 1 GameManager allow to camera");
		GameCtrl.instance = this;
	}

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadCamera();
	}

	protected virtual void LoadCamera()
	{
		if (this.mainCamera != null) return;
		this.mainCamera = GameCtrl.FindAnyObjectByType<Camera>();
		Debug.Log(transform.name + ": LoadCamera", gameObject);
	}
}
