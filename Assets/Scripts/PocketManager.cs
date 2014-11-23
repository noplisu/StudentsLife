using UnityEngine;
using System.Collections;

public class PocketManager : MonoBehaviour {

	public float ParentMoney = 168f;

	TimeManager time;
	Player player;
	int previousDayOfWeek;
	int previousSemester;

	public float workHours = 0;
	public float moneyPerHour = 9;

	// Use this for initialization
	void Start () {
		time = FindObjectOfType<TimeManager> ();
		player = FindObjectOfType<Player> ();
		previousDayOfWeek = time.DayOfWeek();
	}
	
	// Update is called once per frame
	void Update () {
		int dayOfWeek = time.DayOfWeek();
		if (previousDayOfWeek == 6 && dayOfWeek == 0) {
			player.changeMoney (ParentMoney);
			player.changeMoney (workHours * moneyPerHour);
			workHours = 0;
		}
		previousDayOfWeek = dayOfWeek;
	}
}
