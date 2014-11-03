using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour 
{
	GameObject player;
	public Material highlightedMaterial;
	public Material material;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update () { }

	public float Magnitude()
	{
		Vector3 distance = transform.position - player.transform.position;

		return distance.magnitude;
	}

	public void Highlight()
	{
		renderer.material = highlightedMaterial;
	}

	public void RemoveHighlight()
	{
		renderer.material = material;
	}
} 
