using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public Slider energySlider, foodSlider, studySlider, entertainmentSlider;
	public float cash;
	public float energy, food, study, entertainment;
	public float perEnergy, perFood, perEntertainment;
	private Color green, blue, yellow, red;
	public Text currentCash;

	// Adding money to a player from: work, parents etc.
	public void changeMoney(float money){
		this.cash += money;
		currentCash.text = this.cash.ToString ();
	}

	//przy każdym przesunięciu czasu należy to wywoływać
	public void timePassage(float hours){ 
		this.energy = needPassage (this.energy, hours, perEnergy, energySlider);
		this.food = needPassage (this.food, hours, perFood, foodSlider);
		this.entertainment = needPassage (this.entertainment, hours, perEntertainment, entertainmentSlider);
	}

	private float needPassage(float param, float hours, float percent, Slider slider)
	{
		param -= (hours * percent);
		align (ref param);
		slider.value = percentValue (param);
		return param;
	}

	public void ResetStudy(){
		this.study = 0.0f;
		studySlider.value = this.study;
	}

	public void Sleep(float value, float hours)
	{
		this.energy += value + (hours * perEnergy);
		energySlider.value = percentValue(this.energy);
	}

	public void Change(ref float param, float value, ref Slider slider)
	{
		param += value;
		align (ref param);
		slider.value = percentValue (param);
	}

	private void align(ref float number)
	{
		if (number > 100.0f) number = 100.0f;
		if (number < 0.0f)number = 0.0f;
	}
	
	private float percentValue(float value)
	{
		return value / 100.0f;
	}

	public void setStartSliders()
	{
		energySlider.value = percentValue (this.energy);
		foodSlider.value = percentValue (this.food);
		entertainmentSlider.value = percentValue (this.entertainment);
		studySlider.value = percentValue (this.study);
		currentCash.text = this.cash.ToString() + " zł";
	}
}
