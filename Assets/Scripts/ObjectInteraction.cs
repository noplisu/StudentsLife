using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour 
{
	GameObject player;
    ObjectHighlighter[] children;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
        children = GetComponentsInChildren<ObjectHighlighter>();
	}

	void Update () { }

	public float Magnitude()
	{
		Vector3 distance = transform.position - player.transform.position;

		return distance.magnitude;
	}

	public void Highlight()
	{
        foreach(ObjectHighlighter o in children)
		    o.Highlight();
	}

	public void RemoveHighlight()
	{
        foreach (ObjectHighlighter o in children)
            o.RemoveHighlight();
	}
} 
