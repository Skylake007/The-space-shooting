using System;
using System.Collections;
using UnityEngine;

public class LazerImpact : BulletImpact
{
	[SerializeField] protected float recursiveTime = 0.3f;

	//protected override void LoadCapsuleCollider()
	//{
	//	base.LoadCapsuleCollider();
	//	this.CapsuleCollider.height = 7.6f;
	//	this.CapsuleCollider.radius = 0.3f;
	//	this.CapsuleCollider.center = new Vector3(4.3f, 0, 0);
	//	this.CapsuleCollider.direction = 0;
	//}

	protected override void OnTriggerEnter(Collider other)
	{
		if (other.transform == this.bulletCtrl.Shooter) return;
		//does not interact with shield
		if (this.bulletCtrl.Shooter == other.transform?.parent?.parent?.parent?.parent) return;
		StartCoroutine(ResursiveCall(other.transform));
	}

	private void OnTriggerExit(Collider other)
	{
		StopAllCoroutines();
	}

	private IEnumerator ResursiveCall(Transform other)
	{
		this.bulletCtrl.DamageSender.Send(other);
		yield return new WaitForSeconds(this.recursiveTime);
		StartCoroutine(ResursiveCall(other));	
	}
}