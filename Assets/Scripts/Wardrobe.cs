using UnityEngine;
using System.Collections;

public class Wardrobe : Interactor {
	public GameObject gameObject;

	public override void Use(Player player){
		//zmienic ubrania
		print ("Wardrobe");
		if(gameObject != null) gameObject.SetActive (true);
	}
}
