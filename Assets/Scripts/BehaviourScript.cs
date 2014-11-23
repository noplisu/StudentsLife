using UnityEngine;
using System.Collections;

public class BehaviourScript : MonoBehaviour
{
	void Start () 
	{
	
	}
	
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape))
			Application.LoadLevel ("main");
	}

	void OnGUI()
	{

	}
}
