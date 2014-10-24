﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClockManager : MonoBehaviour {

	TimeManager time;

	int startHour = 0;
	int startMinute = 0;

	public Text[] clocks;

	void Start()
	{
		time = GetComponent<TimeManager> ();
	}

	void FixedUpdate()
	{
		for (int i=0; i<clocks.Length; i++) 
		{
			clocks[i].text = Time();
		}
	}

	int Hour()
	{
		return 23 - Mathf.FloorToInt (time.HoursRemaining() % 24);
	}

	int Minutes()
	{
		float hours = time.HoursRemaining ();
		float hourFraction = hours - Mathf.Floor(hours);
		return 59 - Mathf.FloorToInt (hourFraction * 60);
	}

	public string Time()
	{
		return string.Format("{0}:{1}", Hour(), Minutes());
	}
}