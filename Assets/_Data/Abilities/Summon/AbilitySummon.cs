using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummon : BaseAbility
{
    [Header("Ability summon")]
    [SerializeField] protected Spawner spawner;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Summoning();
    }

    protected virtual void Summoning()
    {
        if (!this.isReady) return;
        this.Summon();
    }

    protected virtual Transform Summon()
    {
        Transform spawnerPos = this.abilities.AbilityObjectCtrl.SpawnPoints.GetRandom();
        Transform minionPrefab = this.spawner.RandomPrefab();
        Transform minion = this.spawner.Spawn(minionPrefab, spawnerPos.position, spawnerPos.rotation);
        minion.gameObject.SetActive(true);
        this.Active();

        return minion;
    }
}
