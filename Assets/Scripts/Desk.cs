using UnityEngine;
using System.Collections;

public class Desk : Interactor {

	public GameObject gameObject;
	public int lvl = 0;
	public float multiplier = 0.05f;
	public int maxLvl = 3;
	
	public override void Use(Player player){
		if(gameObject != null) gameObject.SetActive (true);
		Time.timeScale = 0.00000000001f;
	}

	public float getMultiplier()
	{
		return  1.0f + float.Parse (lvl.ToString ()) * multiplier;
	}

	public void Upgrade()
	{
		if (lvl + 1 < maxLvl) lvl++;
	}

}