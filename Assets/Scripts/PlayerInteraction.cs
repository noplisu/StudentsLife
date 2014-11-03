using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInteraction : MonoBehaviour 
{
	ObjectInteraction[] interactions;
	public float maxAngle = 60f;
	public float maxDistance = 4.5f;
	ObjectInteraction highlighted;
	bool anySelected;
	
	void Start () {
		interactions = FindObjectsOfType<ObjectInteraction> ();
	}
	
	void FixedUpdate () 
	{
		anySelected = false;

		if (getFacingObjects().Count > 0)
		{
			ObjectInteraction highlightedObject = getFacingObjects()[0];

			foreach(ObjectInteraction obj in getFacingObjects()) 
			{
				if (obj.Magnitude() < highlightedObject.Magnitude())
					highlightedObject = obj;
			}
			
			if (highlightedObject.Magnitude () < maxDistance)
			{
				anySelected = true;
				selectObject(highlightedObject);
			}
		}

		if (!anySelected)
			selectObject ();
	}

	void selectObject(ObjectInteraction highlightedObject = null)
	{
		if (highlighted != null)
			highlighted.RemoveHighlight ();

		highlighted = highlightedObject;

		if (highlighted != null)
			highlighted.Highlight ();
	}

	List<ObjectInteraction> getFacingObjects()
	{
		List<ObjectInteraction> facingObjects = new List<ObjectInteraction>(); 

		foreach (ObjectInteraction obj in interactions) 
		{
			Vector3 direction = obj.transform.position - transform.position;
			float angle = Vector3.Angle(direction, transform.forward);
			
			if (angle < maxAngle)
				facingObjects.Add(obj);
		}

		return facingObjects;
	}
}
