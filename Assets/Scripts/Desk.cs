using UnityEngine;
using System.Collections;
using UnityEditor;

public class Desk : Interactor {

	public GameObject gameObject;
	
	public override void Use(Player player){
		//zmienic ubrania
		print ("Desk");
		if(gameObject != null) gameObject.SetActive (true);
	}

}