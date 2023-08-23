using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjAppearingBigger: ObjAppearing
{
    [Header("Obj Bigger")]
    [SerializeField] protected float speedScale = 0.01f;
    [SerializeField] protected float currentScale = 0f;
    [SerializeField] protected float startcale = 0.1f;
    [SerializeField] protected float maxScale = 1f;

	protected override void OnEnable()
	{
		base.OnEnable();
		this.InitScale();
	}

	protected override void Appearing()
	{
		this.currentScale += this.speedScale;	
		transform.parent.localScale = new Vector3(this.currentScale, this.currentScale, this.currentScale);
		if (this.currentScale >= this.maxScale) this.Appear();

	}
	protected virtual void InitScale()
	{
		transform.parent.localScale = Vector3.zero;
		this.currentScale = this.startcale;
		
	}

	public override void Appear()
	{
		base.Appear();
		this.transform.parent.localScale = new Vector3(this.maxScale, this.maxScale, this.maxScale);
	}
}
