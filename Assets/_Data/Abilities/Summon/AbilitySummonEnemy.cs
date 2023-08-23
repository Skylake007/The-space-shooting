using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummonEnemy : AbilitySummon
{
	[Header("Summon enemy")]
	[SerializeField] protected List<Transform> minions;
    [SerializeField] protected int minionLimit = 2;

    protected override void Start()
    {
        InvokeRepeating(nameof(this.ClearDeadMinions), 2f, 2f);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawner();
    }

    protected virtual void LoadEnemySpawner()
    {
        if (this.spawner != null) return;
        GameObject enemySpawner = GameObject.Find("EnemySpawner");
        this.spawner = enemySpawner.GetComponent<EnemyShipsSpawner>();
        Debug.LogWarning(transform.name + ": LoadAbilities", gameObject);
    }

    protected override void Summoning()
    {
        if (this.minions.Count >= this.minionLimit) return;
        base.Summoning();
    }

	protected override Transform Summon()
	{   //Sau khi tàu con spawn ra sẽ trở thành con của abilities
        //Tránh trường hợp tàu mẹ bay nhanh, tàu con phóng lên sẽ không bay thẳng trên đường bay

		Transform minion = base.Summon();
        minion.parent = this.abilities.AbilityObjectCtrl.transform;
        this.minions.Add(minion);

        return minion;
	}

    protected virtual void ClearDeadMinions()
    {
        foreach (Transform minion in this.minions)
        {
            if (minion.gameObject.activeSelf == false)
            {
                this.minions.Remove(minion);
                return;
            }
        }
    }
}
