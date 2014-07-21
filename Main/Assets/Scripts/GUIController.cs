using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

	public BikeController bikeController;
	public GradeController gradeController;

	void OnGUI()
	{

		string gearMessage = "";

		if(bikeController.pedalCadence > 7.5f)
		{
			gearMessage = "UPSHIFT";
		}
		else if(bikeController.pedalCadence < 6.5)
		{
			gearMessage = "DOWNSHIFT";
		}
		else
		{
			gearMessage = "PERFECT";
		}

		GUI.Box(new Rect(Screen.width * 0.6f, 0f, Screen.width * 0.4f, Screen.height * 0.3f), "<size=50>Incline: " + gradeController.grade + "\n" + gearMessage + "\n" + "Gear: " + bikeController.gear +"</size>");
	}
}
