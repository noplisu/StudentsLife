using UnityEngine;
using System.Collections;

public class GuiController : MonoBehaviour {

	Player player;
	float sHour, sValue;
	TimeManager time;
	UniversityManager uMan;
	Desk desk;
	Bed bed;
	Fridge fridge;
	PocketManager pManager;

	void Start () {
		player = GetComponent <Player> ();
		time = FindObjectOfType<TimeManager> ();
		uMan = FindObjectOfType<UniversityManager> ();
		desk = FindObjectOfType<Desk> ();
		bed = FindObjectOfType<Bed> ();
		fridge = FindObjectOfType<Fridge> ();
		pManager = FindObjectOfType<PocketManager> ();
	}

	public void workContorll(float value)
	{
		pManager.workHours += value;
	}

	public void energyControl(float value)
	{
		player.Change (ref player.energy, value * bed.getMultiplier(),ref player.energySlider); 
	}

	public void foodControl(float value)
	{
		if(player.cash >= value)
			player.Change (ref player.food, value * fridge.getMultiplier() * 8,ref player.foodSlider);
			player.cash -= value
	}

	public void entertainmentControl(float value)
	{
		player.Change (ref player.entertainment, value, ref player.entertainmentSlider);
	}

	// for university
	public void universityControl(float value)
	{
		player.Change (ref player.study, uMan.getValueForDay(value), ref player.studySlider);
	}

	// desk study
	public void studyContol(float value)
	{
		player.Change (ref player.study, value * desk.getMultiplier (), ref player.studySlider);
	}

	public void moneyControl(float value)
	{
		player.changeMoney (value);	
	}

	//to bed you have to implement both methods sValue first, sHours secound
	public void sleepValue(float value)
	{
		this.sValue = value * bed.getMultiplier();
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
	
	public void timePassage(float hours){
		player.timePassage (hours);
		time.hours -= hours;
	}


}
