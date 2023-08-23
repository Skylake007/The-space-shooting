using System;
using UnityEngine;

public enum AbilityCode
{ 
	NoAbility = 0,

	MissileAllEnemey = 1,
	MissileNearestEnemy = 2,
	Laze = 3,
	Shield = 4,
	Burst = 5,	
}

public class AbilityCodeParser
{
	public static AbilityCode FromString(string itemName)
	{
		try
		{
			return (AbilityCode)System.Enum.Parse(typeof(AbilityCode), itemName);
		}
		catch (ArgumentException e)
		{
			Debug.LogError(e.ToString());
			return AbilityCode.NoAbility;
		}
	}
}