using UnityEngine;
using System.Collections;

public class GuiController : MonoBehaviour {

	Player player;

	void Start () {
		player = GetComponent <Player> ();
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
	
	//wywołać w każdej
	public void timePassage(float hours){
		player.timePassage (hours);
	}


}
