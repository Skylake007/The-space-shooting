using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : BinBehaviour
{
	[Header("HP Bar")]
	[SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
	[SerializeField] protected SliderHP sliderHP;
	[SerializeField] protected FollowTarget followTarget;
	[SerializeField] protected Spawner spawner;



	protected virtual void FixedUpdate()
	{
		this.HPShowing();
	}

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadSliderHP();
		this.LoadFollowTarget();
		this.LoadSpawner();
	}

	protected virtual void LoadSliderHP()
	{
		if (this.sliderHP != null) return;
		this.sliderHP = transform.GetComponentInChildren<SliderHP>();
		Debug.LogWarning(transform.name + ": LoadSliderHP", gameObject);
	}
	protected virtual void LoadFollowTarget()
	{
		if (this.followTarget != null) return;
		this.followTarget = transform.GetComponent<FollowTarget>();
		Debug.LogWarning(transform.name + ": LoadFollowTarget", gameObject);
	}

	protected virtual void LoadSpawner()
	{
		if (this.spawner != null) return;
		this.spawner = transform.parent.parent.GetComponent<Spawner>();
		Debug.LogWarning(transform.name + ": LoadSpawner", gameObject);
	}

	protected virtual void HPShowing()
	{
		if (this.shootableObjectCtrl == null) return;
		bool isDead = shootableObjectCtrl.DamageReceiver.IsDead();
		if (isDead) {
			this.spawner.Despawn(transform);
			return;
		}

		float hp = this.shootableObjectCtrl.DamageReceiver.HP;
		float maxHp = this.shootableObjectCtrl.DamageReceiver.HPMax;

		this.sliderHP.SetMaxHP(maxHp);
		this.sliderHP.SetCurrentHP(hp);
	}

	public virtual void SetObjCtrl(ShootableObjectCtrl shootableObjectCtrl)
	{
		this.shootableObjectCtrl = shootableObjectCtrl;
	}

	public virtual void SetTarget(Transform target)
	{
		this.followTarget.SetTarget(target);
	}
}
