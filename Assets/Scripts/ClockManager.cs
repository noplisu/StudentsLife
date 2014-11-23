using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClockManager : MonoBehaviour {

	TimeManager time;

	string[] Days = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

	int startHour = 6;
	int startMinute = 30;
	int startDayOfWeek = 5;
	float total_time;

	public Text[] clocks;

	void Start()
	{
		time = GetComponent<TimeManager> ();
		total_time = time.HoursRemaining();
	}

	void FixedUpdate()
	{
		foreach(Text clock in clocks) 
		{
			clock.text = Time();
		}
	}

	public int Hour()
	{
		float hoursPassed = total_time - time.HoursRemaining ();
		return Mathf.FloorToInt ((startHour + hoursPassed) % 24);
	}

	public int Minutes()
	{
		float hoursPassed = total_time - time.HoursRemaining ();
		float hourFraction = startMinute + (hoursPassed - Mathf.Floor(hoursPassed)) * 60;
		return Mathf.FloorToInt (hourFraction % 60);
	}

	public string Time()
	{
		float minutes = Minutes();
		string minutesString = "";
		if (minutes < 10) 
		{
			minutesString += "0";
		}
		minutesString += minutes.ToString ();
		return string.Format("{0}:{1}", Hour(), minutesString);
	}

	public string DayOfWeek()
	{
		return Days[(startDayOfWeek + time.DayOfWeek()) % 7];
	}
}
