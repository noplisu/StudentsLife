using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour {

	private Color green, blue, yellow, red;
	private Slider slider;

	void Start () 
	{
		slider =  gameObject.GetComponent<Slider> ();
		setColors ();
		changeSliderColor (slider.value);
		FindObjectOfType<Player> ().setStartSliders ();
	}

	public void OnValueChange(float val)
	{
		print ("On value changed");
		print (val);
		slider.value = val;
		changeSliderColor (slider.value);
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
		Image img = slider.fillRect.GetComponent<Image>();
		img.color = getColor (param);
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
