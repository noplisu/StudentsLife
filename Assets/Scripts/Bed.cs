using UnityEngine;
using System.Collections;

public class Bed : Interactor {
	public float time = 8.0f;
	public GameObject gameObject;

	public override void Use(Player player){
		print ("You used a bed! ");
		if(gameObject != null) gameObject.SetActive (true);
	}
}
