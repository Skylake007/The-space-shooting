using System;
using UnityEngine;

public enum ShipCode
{ 
	NoShip = 0,

	Fighter = 1,
	Healer = 2,
	Miner = 3,
	Tanker = 4,
}

public class ShipCodeParser
{
	public static ItemCode FromString(string itemName)
	{
		try
		{
			return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
		}
		catch (ArgumentException e)
		{
			Debug.LogError(e.ToString());
			return ItemCode.NoItem;
		}
	}
}