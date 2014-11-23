using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {
	public int Semesters = 7;
	public int weeksPerSemester = 3;
	public int daysPerWeek = 7;

	public float hours = 3528;

	float hoursToDays;
	float hoursToWeeks;
	float hoursToSemesters;

	void Start()
	{
		hoursToDays = 24f;
		hoursToWeeks = hoursToDays * daysPerWeek;
		hoursToSemesters = hoursToWeeks * weeksPerSemester;
	}

	public float HoursRemaining()
	{
		return hours;
	}

	public float DaysRemaining()
	{
		return(hours / hoursToDays);
	}

	public float WeeksRemaining()
	{
		return(hours / hoursToWeeks);
	}

	public float SemestersRemaining()
	{
		return(hours / hoursToSemesters);
	}

	public int CurrentSemester()
	{
		return(Mathf.FloorToInt (Semesters - SemestersRemaining ()) + 1);
	}

	public int CurrentWeek()
	{
		return(Mathf.FloorToInt (weeksPerSemester * Semesters - WeeksRemaining ()) + 1);
	}

	public int CurrentDay()
	{
		return(Mathf.FloorToInt (daysPerWeek * weeksPerSemester * Semesters - DaysRemaining ()) + 1);
	}

	public int DayOfWeek()
	{
		return CurrentDay() % daysPerWeek;
	}

	public void SubstractHours(float hours)
	{
		this.hours -= hours;
	}
}
