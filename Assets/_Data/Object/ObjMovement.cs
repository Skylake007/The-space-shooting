using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMovement : BinBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float speed = 0.01f;
	[SerializeField] protected float distance = 1f;
	[SerializeField] protected float minDistance = 1f;

	protected virtual void FixedUpdate()
    {
		this.Moving();
	}

	public virtual void SetSpeed(float speed)
	{
		this.speed = speed;
	}

	protected virtual void Moving() 
	{
		//Không cho enemy sát vào tàu chính
		this.distance = Vector3.Distance(transform.position, this.targetPosition);
		if (this.distance < this.minDistance) return;

		//Transform đại diện cho obj đang được gắn vào
		Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPosition, this.speed);
		transform.parent.position = newPos;
	}
}
