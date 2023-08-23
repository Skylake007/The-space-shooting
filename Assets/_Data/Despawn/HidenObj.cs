using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HidenObj : BinBehaviour
{
    protected virtual void FixedUpdate()
    {
        this.Hiding();
    }

    protected virtual void Hiding()
    {
        if (!this.CanHiding())
        {
            this.UnHidenObject();
            return; 
        }
        this.HideObject();
    }

    public virtual void HideObject()
    {
        //this.transform.parent.gameObject.SetActive(false);
        PlayerCtrl.Instance.CurrentShip.gameObject.SetActive(false);
    }

    public virtual void UnHidenObject()
    {
        //this.transform.parent.gameObject.SetActive(true);
    }
    protected abstract bool CanHiding();
}
