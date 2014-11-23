using UnityEngine;
using System.Collections;

public class Bed : Interactor {
	public GameObject gameObject;

	public override void Use(Player player){
		if(gameObject != null) gameObject.SetActive (true);
	}
}
