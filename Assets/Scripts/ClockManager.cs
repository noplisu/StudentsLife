using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClockManager : MonoBehaviour {

	TimeManager time;

	string[] Days = { "Poniedziałek", "Wtorek", "Środa", "Czwartek", "Piątek", "Sobota", "Niedziela" };

	int startHour = 0;
	int startMinute = 0;

	public Text clock;
	public Text week;
	public Text weekNr;
	public Text semester;

	void Start()
	{
		time = GetComponent<TimeManager> ();
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
		return string.Format("{0}:{1}", Hour(), minutesString);
	}

	public string DayOfWeek()
	{
		return Days[time.DayOfWeek()];
	}
}
