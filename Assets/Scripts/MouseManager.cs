using UnityEngine;
using System.Collections;

public class MouseManager : MonoBehaviour {

	public GameObject player;
	FreeLookCam game;
	// Use this for initialization
	void Start () {
		 game = player.GetComponent<FreeLookCam> ();
		Screen.showCursor = false;
	}
	
	public void Lock()
	{
		print ("Lock: " + game);
		game.enabled = false;
		Screen.showCursor = true;
	}

	public void Unlock()
	{
		print ("Unlock: " + game);
		game.enabled = true;
		Screen.showCursor = false;
	}
}
