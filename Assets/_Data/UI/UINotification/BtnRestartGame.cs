using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnRestartGame : BaseButton
{
	protected override void OnClick()
	{
		//Respawn here
		Debug.LogWarning("ReSpawn Ship");
		UINotification.Instance.Close();
		PlayerCtrl.Instance.CurrentShip.gameObject.SetActive(true);
		PlayerCtrl.Instance.CurrentShip.DamageReceiver.Reborn();

	}
}
