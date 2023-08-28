using UnityEngine;

public class PlayerShipLookForward : ShipLookForward
{
	protected override void ResetValue()
	{
		base.ResetValue();
		this.loopPosition = new Vector3(0, 30, 0);
	}

	protected override Transform GetParent()
	{
		return PlayerShipsCtrl.Instance.transform;
	}
}
