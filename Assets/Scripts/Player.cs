using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public Slider energySlider, foodSlider, studySlider, entertainmentSlider;
	public float cash;
	public float energy, food, study, entertainment;
	public float perEnergy, perFood, perEntertainment;
	private Color green, blue, yellow, red;

	void Start () {
		setColors ();
		setStartSliders ();
		print ("Student entertainment: " + this.entertainment);
	}

	// Adding money to a player from: work, parents etc.
	public void changeMoney(float money){
		this.cash += money;
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
		print ("Before align: " + param);
		align (ref param);
		print ("After align: " + param);
		slider.value = percentValue (param);
		changeSliderColor (slider, param);
		return param;
	}

	public void ResetStudy(){
		this.study = 0.0f;
		studySlider.value = this.study;
		changeSliderColor (studySlider, this.study);
	}

	public void Change(ref float param, float value, ref Slider slider)
	{
		param += value;
		align (ref param);
		slider.value = percentValue (param);
		changeSliderColor (slider, param);
	}

	private void align(ref float number)
	{
		if (number > 100.0f) number = 100.0f;
		if (number < 0.0f)number = 0.0f;
	}
	
	private Color getColor(float param)
	{
		if (param <= 20.0f) return red;
		if (param <= 50.0f) return yellow;
		if (param <= 80.0f) return blue;
		else return green;
	}

	private Color parseColor(int r, int g, int b)
	{
		float rF = r / 255.0f;
		float gF = g / 255.0f;
		float bF = b / 255.0f;
		return new Color (rF, gF, bF);
	}

	private void changeSliderColor(Slider slider, float param)
	{
		Image img = slider.fillRect.GetComponent<Image>(); //slider.GetComponentInChildren<Image> ();
		img.color = getColor (param);
		print (img.color);
	}

	private float percentValue(float value)
	{
		return value / 100.0f;
	}

	private void setStartSliders()
	{
		energySlider.value = percentValue (this.energy);
		changeSliderColor (energySlider, this.energy);

		foodSlider.value = percentValue (this.food);
		changeSliderColor (foodSlider, this.food);

		entertainmentSlider.value = percentValue (this.entertainment);
		changeSliderColor (entertainmentSlider, this.entertainment);

		studySlider.value = percentValue (this.study);
		changeSliderColor (studySlider, this.study);
	}

	private void setColors()
	{
		green = parseColor (64,126,41);
		blue = parseColor (12, 56, 121);
		yellow = parseColor (225,189,36);
		red = parseColor (188,0,0); 
	}
}
