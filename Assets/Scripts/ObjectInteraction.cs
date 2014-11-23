using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour 
{
	GameObject player;
    ObjectHighlighter[] children;
	Interactor interactor;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
        children = GetComponentsInChildren<ObjectHighlighter>();
		interactor = GetComponent<Interactor> ();
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

	public void Use(Player player)
	{
		interactor.Use(player);
	}
} 
