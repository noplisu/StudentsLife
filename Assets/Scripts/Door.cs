using UnityEngine;
using System.Collections;

public class Door : Interactor {

	public GameObject gameObject;
	
	public override void Use(Player player){
		print ("Door");
		if(gameObject != null) gameObject.SetActive (true);
	}
}
