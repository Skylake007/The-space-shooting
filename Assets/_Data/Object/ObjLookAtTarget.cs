using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLookAtTarget : BinBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
	[SerializeField] protected float rotSpeed = 3f;


	protected virtual void FixedUpdate()
    {
        this.LookAtTarget();
	}

	public virtual void SetRotSpeed(float speed)
	{
		this.rotSpeed = speed;
	}

	protected virtual void LookAtTarget()
    {
        Vector3 diff = this.targetPosition - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

		float timeSpeed = this.rotSpeed * Time.fixedDeltaTime;
		Quaternion targetEuler = Quaternion.Euler(0f, 0f, rot_z);

		//Kiểm soát tấc độ góc quay
		Quaternion currentEuler = Quaternion.Lerp(transform.parent.rotation, targetEuler, timeSpeed);
		transform.parent.rotation = currentEuler;
    }
}
