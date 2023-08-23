using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : BinBehaviour
{
	[SerializeField] protected float rotationSpeed = 1f;

	protected override void OnEnable()
	{
		base.OnEnable();
		this.rotationSpeed = 1f;
		StartCoroutine(RotateObject());
	}

	private IEnumerator RotateObject()
	{
		while (true)
		{
			if (this.rotationSpeed < 3600f)
			{
				this.rotationSpeed += this.rotationSpeed;
			}
			ChargeCtrl.Instance?.Model.Rotate(Vector3.forward, this.rotationSpeed * Time.deltaTime);
			yield return null;
		}
	}
}
