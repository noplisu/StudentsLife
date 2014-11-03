using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInteraction : MonoBehaviour 
{
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

		foreach (ObjectInteraction obj in interactions) 
		{
			Vector3 direction = obj.transform.position - transform.position;
			float angle = Vector3.Angle(direction, transform.forward);
			
			if (angle < maxAngle)
				facingObjects.Add(obj);
		}	

		if (facingObjects.Count > 0)
		{
			ObjectInteraction highlightedObject = facingObjects[0];

			foreach(ObjectInteraction obj in facingObjects) 
			{
				if (obj.Magnitude() < highlightedObject.Magnitude())
					highlightedObject = obj;
			}
			
			if (highlightedObject.Magnitude () < maxDistance)
				highlightedObject.Highlight ();
		}
	}
}
