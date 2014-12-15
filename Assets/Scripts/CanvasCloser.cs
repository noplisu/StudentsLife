using UnityEngine;
using System.Collections;

public class CanvasCloser : MonoBehaviour {

	GameObject gameO;

	void Start()
	{
		gameO = gameObject;
	}

	public void Hide()
	{
		gameO.SetActive (false);
        Time.timeScale = 1.0f;
	}
}
