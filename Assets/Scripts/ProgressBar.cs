using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour 
{
	float progress;
	Vector2 pos;
	Vector2 size;
	Texture2D progressBarEmpty;
	Texture2D progressBarNotEmpty;


	// Use this for initialization
	void Start () 
	{
		progress = 0;
		pos = new Vector2 (20, 40);
		size = new Vector2 (60, 20);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}