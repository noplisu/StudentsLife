using UnityEngine;
using System.Collections;

public class CanvasCloser : MonoBehaviour {

	GameObject gameO;
	float tScale;

	void Start()
	{
		tScale = Time.timeScale;
		gameO = gameObject;
	}

	public void Hide()
	{
		gameO.SetActive (false);
		Time.timeScale = tScale;
	}
}
