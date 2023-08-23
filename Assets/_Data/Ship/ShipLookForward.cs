﻿using UnityEngine;

public class ShipLookForward : ObjLookAtTarget
{
    [Header("Ship Look Foward")]
    [SerializeField] protected Transform lookTarget;
    [SerializeField] protected Vector3 loopPosition = new Vector3(0, 30, 0);

	protected override void OnEnable()
	{
        base.OnEnable();
        this.SetupLookTarget();
	}

	protected override void LoadComponents()
	{
		base.LoadComponents();
        this.LoadLookTarget();
	}

    protected override void ResetValue()
    {
        base.ResetValue();
        this.rotSpeed = 27;
    }

    protected virtual void LoadLookTarget()
    {
        if (this.lookTarget != null) return;
        this.lookTarget = transform.Find("LookTarget");
        Debug.LogWarning(transform.name + ": LoadLookTarget", gameObject);
    }

    protected virtual void SetupLookTarget()
    {
        Vector3 pos = transform.position;
        pos.x += this.loopPosition.x;
        pos.y += this.loopPosition.y;
        pos.z += this.loopPosition.z;

        this.lookTarget.position = pos;
        this.lookTarget.parent = null;
    }

    protected override void LookAtTarget()
    {
        this.targetPosition = this.lookTarget.position;
        base.LookAtTarget();
    }
}
