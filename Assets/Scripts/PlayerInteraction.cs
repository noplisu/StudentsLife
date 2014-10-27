using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInteraction : MonoBehaviour {

	ObjectInteraction[] interactions;
	public float maxAngle = 60f;
	public float maxDistance = 4.5f;

	// Use this for initialization
	void Start () {
		interactions = FindObjectsOfType<ObjectInteraction> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		List<ObjectInteraction> facingObjects = new List<ObjectInteraction>(); 

		for (int i = 0; i < interactions.Length; i++) 
		{
			Vector3 direction = interactions[i].transform.position - transform.position;
			float angle = Vector3.Angle(direction, transform.forward);

			if (angle < maxAngle)
			{
				facingObjects.Add(interactions[i]);
			}
		}

		if (facingObjects.Count > 0)
		{
			ObjectInteraction highlightedObject = facingObjects[0];

			for (int i = 1; i < facingObjects.Count - 1; i++) 
			{
				if (facingObjects[i].Magnitude() < highlightedObject.Magnitude())
				{
					highlightedObject = facingObjects[i];
				}
			}
			
			if (highlightedObject.Magnitude () < maxDistance)
				highlightedObject.Highlight ();
		}
	}
}
