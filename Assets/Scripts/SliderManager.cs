using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour {

	Color green, blue, yellow, red;
	Slider slider;
	Image img;

	void Start () 
	{
		slider =  GetComponent<Slider> ();
		img = slider.fillRect.GetComponent<Image>();
		setColors ();
		float val = slider.value;
		changeSliderColor (val);
		FindObjectOfType<Player> ().setStartSliders();
	}

	public void OnValueChange(float val)
	{
		//print (slider);
		//slider.value = val;
		changeSliderColor (val);
	}

	private Color getColor(float param)
	{
		if (param <= 0.2f) return red;
		if (param <= 0.5f) return yellow;
		if (param <= 0.8f) return blue;
		else return green;
	}
	
	private void changeSliderColor(float param)
	{
		if(slider) img.color = getColor (param);
	}
	
	private Color parseColor(int r, int g, int b)
	{
		float rF = r / 255.0f;
		float gF = g / 255.0f;
		float bF = b / 255.0f;
		return new Color (rF, gF, bF);
	}

	private void setColors()
	{
		green = parseColor (64,126,41);
		blue = parseColor (12, 56, 121);
		yellow = parseColor (225,189,36);
		red = parseColor (188,0,0);
	}
}
