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
	Player player;
	public Canvas devCan;
	
	void Start () {
		interactions = FindObjectsOfType<ObjectInteraction> ();
		player = GetComponent <Player> ();
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.R)) {
			devCan.gameObject.SetActive(!devCan.gameObject.activeSelf);		
		}
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
				if (Input.GetKeyDown (KeyCode.E)) {	
					highlightedObject.Use(player);
				}
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
