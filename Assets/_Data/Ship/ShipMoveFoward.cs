using UnityEngine;

public class ShipMoveFoward : ObjMovement
{
    [Header("Ship Move Foward")]
    [SerializeField] protected Transform moveTarget;

    protected override void FixedUpdate()
    {
        this.GetMovePosition();
        base.FixedUpdate();
    }

	protected override void LoadComponents()
	{
		base.LoadComponents();
        this.LoadTarget();
	}

    protected virtual void LoadTarget()
    {
        if (this.moveTarget != null) return;
        this.moveTarget = transform.Find("MoveTarget");
        Debug.LogWarning(transform.name + ": LoadMoveTarget", gameObject);
    }

    public virtual void SetMoveTarget(Transform target)
    {
        this.moveTarget = target;
    }

	protected virtual void GetMovePosition()
    {
        this.targetPosition = this.moveTarget.position; 
        this.targetPosition.z = 0;
    }
}
