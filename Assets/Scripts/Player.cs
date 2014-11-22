using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public Slider energySlider, foodSlider, studySlider, entertainmentSlider;
	public float cash;
	public float energy, food, study, entertainment;
	public float perEnergy, perFood, perEntertainment;
	
	// Adding money to a player from: work, parents etc.
	public void AddMoney(float money){
		this.cash += money;
	}

	// Substract money from player
	public void SpendMoney(float money){
		this.cash -= money;
	}

	public void timePassage(float hours){
		needPassage (this.energy, hours, perEnergy, energySlider);
		needPassage (this.food, hours, perFood, foodSlider);
		needPassage (this.entertainment, hours, perEntertainment, entertainmentSlider);
	}

	private void needPassage(float param, float hours, float percent, Slider slider)
	{
		param -= (hours * percent);
		align (param);
		slider.value = param;
	}

	public void ResetStudy(){
		this.study = 0.0f;
		studySlider.value = this.study;
	}

	private void align(float number)
	{
		if (number > 100.0f) number = 100.0f;
		if (number < 0.0f)number = 0.0f;
	}

	public void Change(float param, float value, Slider slider)
	{
		param += value;
		align (param);
		slider.value = param;
	}
}
