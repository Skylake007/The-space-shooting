using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WormHole : BinBehaviour
{

	protected string screneName = "GalaxyDemo";
	protected virtual void OnMouseDown()
	{
		this.LoadGalaxy();
		Debug.Log("WornHole OnMouseDown");
	}

	protected virtual void LoadGalaxy()
	{
		SceneManager.LoadScene(this.screneName);
	}

}
