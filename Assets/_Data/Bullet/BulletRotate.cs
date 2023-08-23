using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotate : BulletAbstract
{
	[SerializeField] protected float speed = 20f;

	protected virtual void FixedUpdate()
	{
		this.Rotating();
	}

	protected virtual void Rotating()
	{
		Vector3 eulers = new Vector3(0, 0, 1);
		transform.parent.Rotate(eulers * this.speed * Time.fixedDeltaTime);
	}
}
