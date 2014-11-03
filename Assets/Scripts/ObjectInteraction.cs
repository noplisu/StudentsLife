using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour 
{
	GameObject player;
	public Material highlightedMaterial;
	private Material previousMaterial;

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
		previousMaterial = renderer.material; 

		//Material mat = Resources.Load ("Active", typeof(Material)) as Material;	
		//print (previousMaterial);

		renderer.material = highlightedMaterial;
	}

	public void RemoveHighlight()
	{
		renderer.material = previousMaterial;

		previousMaterial = highlightedMaterial;
	}
} 
