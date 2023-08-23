using UnityEngine;

public class PlayerShipLookForward : ShipLookForward
{
	protected override void ResetValue()
	{
		base.ResetValue();
		this.rotSpeed = 27;
		this.loopPosition = new Vector3(0, 30, 0);
	}
}
