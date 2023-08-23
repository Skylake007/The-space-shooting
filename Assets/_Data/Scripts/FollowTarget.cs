using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : BinBehaviour
{

    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 2f;

    // Start is called before the first frame update
    protected virtual void FixedUpdate()
    {
        this.Following();
    }

    protected virtual void Following()
    {
        if (this.target == null) return;
        transform.position = Vector3.Lerp(transform.position, this.target.position, Time.fixedDeltaTime * speed);
    }

    public virtual void SetTarget(Transform target) 
    {
        this.target = target;
    }
}
