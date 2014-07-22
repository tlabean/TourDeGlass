using UnityEngine;
using System.Collections;

public class AlertNotify : MonoBehaviour {

	public AudioSource alertSound;
	public BikeController bikeController;
	private bool flagSet = false;
	// Use this for initialization
	
	// Update is called once per frame
	public void playSound () {
			alertSound.volume = 0.25f;
			alertSound.Play ();
	}
}
