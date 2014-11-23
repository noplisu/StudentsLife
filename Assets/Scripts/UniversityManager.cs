using UnityEngine;
using System.Collections;

public class UniversityManager : MonoBehaviour {

	TimeManager time;
	int previousSemester, semestr;
	Player player;
	int mark;
	int[] marks;
	public GameObject failScreen, successScreen;
	
	// Use this for initialization
	void Start () {
		marks = new int[7];
		time = FindObjectOfType<TimeManager> ();
		previousSemester = time.CurrentSemester();
		player = FindObjectOfType<Player> ();
	}
	
	void FixUpdate()
	{
		semestr = time.CurrentSemester ();
		if (previousSemester < semestr) {
			player.ResetStudy ();
			mark = getMark ();
			marks [previousSemester - 1] = mark;
			if (studyPass ()){ previousSemester = semestr;
				if(previousSemester == 7) Finish();
			}
			else  Fail();
		}
	}

	public bool studyPass()
	{
		bool pass = true;
		mark = getMark ();
		if( mark >= 4 ) player.changeMoney (mark * 100);
		if( mark == 2 ) pass = false;
		return pass;
	}

	public int getMark()
	{
		float study = player.study;
		
		if (study < 50.0f) return 2;
		if (study >= 50.0f) return 3;
		if (study >= 70.0f) return 4;
		if (study >= 90.0f) return 5;
		return 2;
	}

	public float getValueForDay(float hours)
	{
		int sem = time.CurrentSemester () - 1;
		float multiply = 1 / (1.0f + sem * 0.1f);
		return hours * multiply;
	}

	public void Fail()
	{
		if (failScreen != null) failScreen.SetActive (true);
	}

	public void Finish()
	{
		if (successScreen != null) successScreen.SetActive (true);
	}

	
}
