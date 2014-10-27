using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float Magnitude()
	{
		Vector3 distance = transform.position - player.transform.position;

		return distance.magnitude;
	}

	public void Highlight()
	{
		print (gameObject);
	}
}
