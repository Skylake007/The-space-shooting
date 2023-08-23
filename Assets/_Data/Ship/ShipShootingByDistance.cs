using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootingByDistance : ObjShooting
{

	[Header("Shoot by distance")]
	[SerializeField] protected Transform target;
	[SerializeField] protected float distance = Mathf.Infinity;
	[SerializeField] protected float shootDistance = 3f;

	public virtual void SetTarget(Transform target)
	{
	// to do
		if (target == null) {
			//Debug.LogWarning("The ship is Dead");
			return;
		}

		this.target = target;
	}

	protected override bool IsShooting()
	{
	// to do
		if (target == null)
		{          
		//Debug.LogWarning("The ship is Dead");
			return false;
		}

		this.distance = Vector3.Distance(transform.position, this.target.position);
		this.isShooting = this.distance < this.shootDistance;

		return this.isShooting;
	}
}
