using UnityEngine;
using System.Collections;

public class WinLoseManager : MonoBehaviour {

	public GameObject failScreen, successScreen;
	// Use this for initialization

	public void Fail()
	{
		print ("You failed");
		if (failScreen != null) failScreen.SetActive (true);
	}

	public void Win()
	{
		print ("You win");
		if (successScreen != null) successScreen.SetActive (true);
	}
}
