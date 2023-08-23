using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjAppearing : BinBehaviour
{
    [Header("Obj Appearing")]
    [SerializeField] protected bool isAppearing = false;
    [SerializeField] protected bool appeared = false;
    [SerializeField] protected List<IObjAppearObserver> observers = new List<IObjAppearObserver>(); 

    public bool IsAppearing => isAppearing;
    public bool Appeared => appeared;

	protected override void Start()
	{
		base.Start();
        this.OnAppearStart();
	}

    public virtual void ObserverAdd(IObjAppearObserver observer)
    {
        this.observers.Add(observer);
    }

    protected virtual void OnAppearStart()
    {
        foreach (IObjAppearObserver observer in this.observers)
        {
            observer.OnAppearStart();
        }
    }

    protected virtual void OnAppearFinish()
    {
        foreach (IObjAppearObserver observer in this.observers)
        {
            observer.OnAppearFinish();
        }
    }

    protected virtual void FixedUpdate()
    {
        this.Appearing();
    }

    protected abstract void Appearing();

    public virtual void Appear()
    {
        this.appeared = true;
        this.isAppearing = false;
        this.OnAppearFinish();
    }
}
