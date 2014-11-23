using UnityEngine;
using System.Collections;

public class GuiController : MonoBehaviour {

	Player player;
	float sHour, sValue;
	TimeManager time;

	void Start () {
		player = GetComponent <Player> ();
		time = FindObjectOfType<TimeManager> ();
	}

	public void energyControl(float value)
	{
		player.Change (ref player.energy, value,ref player.energySlider); 
	}

	public void foodControl(float value)
	{
		player.Change (ref player.food, value,ref player.foodSlider);
	}

	public void entertainmentControl(float value)
	{
		player.Change (ref player.entertainment, value, ref player.entertainmentSlider);
	}

	public void studyControl(float value)
	{
		player.Change (ref player.study, value, ref player.studySlider);
	}

	public void moneyControl(float value)
	{
		player.changeMoney (value);	
	}

	//to bed you have to implement both methods sValue first, sHours secound
	public void sleepValue(float value)
	{
		this.sValue = value;
	}

	public void sleepHours(float hour)
	{
		this.sHour = hour;
		player.Sleep (sValue, sHour);
	}

	public void spendMoney(float value)
	{
		player.changeMoney (value);
	}
	
	//use in every click...
	public void timePassage(float hours){
		player.timePassage (hours);
		time.hours -= hours;
	}


}
