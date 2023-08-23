using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Junk", menuName = "SO/Junk")]
public class JunkSO : ScriptableObject
{
	public string junkName = "Junk";
	public int hpMax = 20;
	public List<ItemDropRate> dropList;
}
 