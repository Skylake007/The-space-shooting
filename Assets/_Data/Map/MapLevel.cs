public class MapLevel : LevelByDistance
{
	protected override void FixedUpdate()
	{
		base.FixedUpdate();
		this.MapSetTarget();
	}

	protected virtual void MapSetTarget()
	{
		if (this.target != null) return;
		if (PlayerCtrl.Instance.CurrentShip == null) return;

		PlayerShipCtrl currentShip = PlayerCtrl.Instance.CurrentShip;
		this.SetTarget(currentShip.transform);
	}
}
