using UnityEngine;
using System.Collections;

public class SkyBoxManager : MonoBehaviour {
	
	public Material morning, day, midday, sunset, night;
    public ClockManager clock;
	int hour;
    public Color morningColor = new Color(0.796f, 0.784f, 0.756f, 0.729f);
    public Color dayColor = new Color(0.792f, 0.776f, 0.631f, 0.67f);
    public Color middayColor = new Color(0.796f, 0.784f, 0.756f, 0.729f);
    public Color sunsetColor = new Color(0.996f, 0.862f, 0.596f, 1f);
    public Color nightColor = new Color(0.678f, 0.721f, 0.729f, 0.662f);

	void FixedUpdate (){
        GetHour();
        SetColors ();
		SetSkybox();
	}

    public void GetHour()
    {
        hour = clock.Hour();
    }

	public void SetSkybox(){
		if (hour >= 6 && hour < 8) {
			RenderSettings.skybox = morning;
			RenderSettings.ambientLight = morningColor;
		} else if (hour >= 8 && hour < 12) {
			RenderSettings.skybox = day;
			RenderSettings.ambientLight = dayColor;
		}else if (hour >=12 && hour <= 16){
			RenderSettings.skybox = midday;
			RenderSettings.ambientLight = middayColor;
		}else if (hour > 16 && hour <= 19){
			RenderSettings.skybox = sunset;
			RenderSettings.ambientLight = sunsetColor;
		} else {
			RenderSettings.skybox = night;
			RenderSettings.ambientLight = nightColor;
		}
	}

	private void SetColors(){
		morningColor = new Color(0.99f, 0.917f, 0.619f, 0.764f);
		dayColor = new Color(0.792f, 0.776f, 0.631f, 0.67f);
		middayColor = new Color(0.796f, 0.784f, 0.756f, 0.729f);
        sunsetColor = sunsetColor;
		nightColor = new Color(0.678f, 0.721f, 0.729f, 0.662f);
	}

}
