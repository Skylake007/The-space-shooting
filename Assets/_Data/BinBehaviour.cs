using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinBehaviour : MonoBehaviour
{
	//Do not declare fixedUpdate function here it may cause performance error
	protected virtual void Awake()
	{
		this.LoadComponents();
	}

	protected virtual void Start()
	{
		// For override
	}

	protected virtual void Reset()
	{
		this.LoadComponents();
		this.ResetValue();
	}


	protected virtual void LoadComponents()
	{
		//For override
	}

	protected virtual void ResetValue()
	{
		//For override
	}

	protected virtual void OnEnable()
	{ 
		//For override
	}
	protected virtual void OnDisable()
	{
		//For override
	}

	//protected virtual void OnAppearStart()
	//{
	//	//For override
	//}
}
