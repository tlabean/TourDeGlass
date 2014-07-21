using UnityEngine;
using System.Collections;

public class AlertNotify : MonoBehaviour {

	public AudioSource alertSound;
	public BikeController bikeController;
	private bool flagSet = false;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		if (bikeController.pedalCadence > 10 && !alertSound.isPlaying && !flagSet) {
						alertSound.volume = 0.25f;
						alertSound.Play ();
						flagSet = true;
				}
		if (bikeController.pedalCadence < 10 && flagSet) {
						flagSet = false;
						alertSound.volume = 0;
				}


	}
}
