using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

	public BikeController bikeController;
	public GradeController gradeController;
	public AudioSource alertSound;

	void OnGUI()
	{
		int currentGear = bikeController.getCurrentGear();
		string gearMessage = "";

		if(bikeController.pedalCadence > 7.5f)
		{
			gearMessage = "UPSHIFT";
			if (Input.GetKeyDown(KeyCode.DownArrow) && bikeController.gear > 1) {
				playSound();
			}

		}
		else if(bikeController.pedalCadence < 6.5)
		{
			gearMessage = "DOWNSHIFT";
			if (Input.GetKeyDown(KeyCode.UpArrow) && bikeController.gear < 9) {
				playSound();
			}
		}
		else
		{
			gearMessage = "PERFECT";
		}

		GUI.Box(new Rect(Screen.width * 0.6f, 0f, Screen.width * 0.4f, Screen.height * 0.3f), "<size=50>Incline: " + gradeController.grade + "\n" + gearMessage + "\n" + "Gear: " + bikeController.gear +"</size>");
	}

	public void playSound () {
		alertSound.volume = 1f;
		alertSound.Play ();
	}
}
