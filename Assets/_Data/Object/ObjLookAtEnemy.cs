using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLookAtEnemy : ObjLookAtTarget
{
    [Header("Look At Player")]
    [SerializeField] protected GameObject player;

    protected override void FixedUpdate()
    {
        this.GetMousePosition();
        base.FixedUpdate();
    }

	protected override void LoadComponents()
	{
		base.LoadComponents();
        this.LoadEnemy();
	}

    protected virtual void LoadEnemy()
    {
        if (this.player != null) return;
        this.player = GameObject.FindGameObjectWithTag("Enemy");
        Debug.Log(transform.name + ": LoadEnemy", gameObject);
    }

    protected virtual void GetMousePosition()
    {
        if (this.player == null) return;
        this.targetPosition = this.player.transform.position;
        this.targetPosition.z = 0;
    }
}
