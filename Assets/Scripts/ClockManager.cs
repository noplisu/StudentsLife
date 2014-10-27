using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClockManager : MonoBehaviour {

	TimeManager time;

	string[] Days = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

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

	public int Hour()
	{
		return 23 - Mathf.FloorToInt (time.HoursRemaining() % 24);
	}

	public int Minutes()
	{
		float hours = time.HoursRemaining ();
		float hourFraction = hours - Mathf.Floor(hours);
		return 59 - Mathf.FloorToInt (hourFraction * 60);
	}

	public string Time()
	{
		float minutes = Minutes();
		string minutesString;
		if (minutes < 10) 
		{
			minutesString = "0" + minutes.ToString ();
		}
		else 
		{
			minutesString = minutes.ToString ();
		}
		return string.Format("{2} {0}:{1}", Hour(), minutesString, DayOfWeek());
	}

	public string DayOfWeek()
	{
		return Days[time.DayOfWeek()];
	}
}
