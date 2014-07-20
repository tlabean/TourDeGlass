using UnityEngine;
using System.Collections;

public class AmbientChannel : MonoBehaviour {

	public float ambientCloseZone = 0.5f;
	public float ambientAudioVolume = 0f;
	public float ambientAudioVolumeScale = 1f;

	public BikeController bikeController;
	public GradeController gradeController;
	//public SoundController soundController;
	//public AudioClip ambientSound;
	public AudioSource audioSource;
	public float cadenceTarget = 7f;
	// Use this for initialization
	/*void Start () {
		InitializeAudioSource();
		audioSource.Play ();
		audioSource.loop = true;
	}*/
	
	// Update is called once per frame
	void Update () {
		if (gradeController.grade > 3) {
			//audioSource.volume = Mathf.Abs(1 - (Mathf.Abs(bikeController.pedalCadence / cadenceTarget)));
			//audioSource.pitch = Mathf.Abs(1 - (Mathf.Abs(bikeController.pedalCadence / cadenceTarget)));
			audioSource.volume = ambientAudioVolume + Mathf.Abs(bikeController.pedalCadence - 7f) * ambientAudioVolumeScale;

			audioSource.pitch = 2f;
		}
		else if ( gradeController.grade < -3) {
			//audioSource.volume = Mathf.Abs(1 - (Mathf.Abs(bikeController.pedalCadence / cadenceTarget)));
			//audioSource.pitch = Mathf.Abs(1 - (Mathf.Abs(bikeController.pedalCadence / cadenceTarget)));
			audioSource.volume = ambientAudioVolume + Mathf.Abs(bikeController.pedalCadence - 7f) * ambientAudioVolumeScale;
			audioSource.pitch = 1f;
		}
		else {
			audioSource.volume = 0;

		}

	}

	/*void InitializeAudioSource()
	{
		//we setup a new AudioSource here to not conflict with any ambient sound effects
		//we may have put on objects in our scene
		
		//This lets us have an ambient loop play while also playing a different
		//sound on collision with the character or another object.
		
		if (audioSource != null) //if we have already set it up
			return;
		GameObject go = new GameObject();
		go.transform.parent = transform;
		go.name = "Amibent-" + gameObject.name;
		audioSource = go.AddComponent<AudioSource>();
		audioSource.clip = ambientSound;
	}*/
}
