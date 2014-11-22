using UnityEngine;
using System.Collections;

public class Lamp : Interactor {

	public GameObject light;
	public override void Use(Player player){
		//zapalić światło
		print ("Lamp");
		if (light != null) light.SetActive (!light.activeSelf);
	}
}
