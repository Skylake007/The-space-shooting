using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressableAbility : Pressable
{
    [SerializeField] protected AbilityCode ability;
    public override void Pressed()
    {
        Debug.Log("PressableAbility: " + ability.ToString());
        PlayerCtrl.Instance.PlayerAbility.Active(ability);
    }
}
