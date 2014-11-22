using UnityEngine;
using System.Collections;

public class Fridge : Interactor {
	public GameObject gameObject;

	public override void Use(Player player){
		print ("Fridge");
		if(gameObject != null) gameObject.SetActive (true);
		// player.Eat (perCent);
	}
}
