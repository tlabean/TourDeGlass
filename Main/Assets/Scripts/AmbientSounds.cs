using UnityEngine;
using System.Collections;

public class AmbientSounds : MonoBehaviour {
	public AudioSource bicycleAmbience;
	public BikeController bikeController;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		bicycleAmbience.volume = (bikeController.velocity / 100f);
	}
}