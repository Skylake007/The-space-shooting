using UnityEngine;

public class EnemyShipLookForward : ShipLookForward
{
	protected override void ResetValue()
	{
		base.ResetValue();
		this.loopPosition = new Vector3(0, -30, 0);
	}
}
