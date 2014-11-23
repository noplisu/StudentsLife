using UnityEngine;
using System.Collections;

public class PocketManager : MonoBehaviour {

	public float ParentMoney = 168f;

	TimeManager time;
	Player player;
	int previousDayOfWeek;
	int previousSemester;

	int mark = 4;

	// Use this for initialization
	void Start () {
		time = FindObjectOfType<TimeManager> ();
		player = FindObjectOfType<Player> ();
		previousDayOfWeek = time.DayOfWeek();
		previousSemester = time.CurrentSemester();
	}
	
	// Update is called once per frame
	void Update () {
		int dayOfWeek = time.DayOfWeek();
		int semester = time.CurrentSemester();
		if (previousDayOfWeek == 6 && dayOfWeek == 0)
			player.changeMoney (ParentMoney);
		if (previousSemester < semester && mark >= 4)
			player.changeMoney (mark * 100);
		previousSemester = semester;
		previousDayOfWeek = dayOfWeek;
	}
}
