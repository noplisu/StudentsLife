using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClockManager : MonoBehaviour {

	TimeManager time;

	string[] Days = { "Poniedziałek", "Wtorek", "Środa", "Czwartek", "Piątek", "Sobota", "Niedziela" };

	int startHour = 6;
	int startMinute = 30;
	int startDayOfWeek = 5;
	float total_time;

	public Text clock;
	public Text week;
	public Text weekNr;
	public Text semester;

	void Start()
	{
		time = GetComponent<TimeManager> ();
		total_time = time.HoursRemaining();
	}

	void FixedUpdate()
	{
		clock.text = Time();
		week.text = DayOfWeek ();
		weekNr.text = time.CurrentWeek ().ToString();
		semester.text = time.CurrentSemester ().ToString ();
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
