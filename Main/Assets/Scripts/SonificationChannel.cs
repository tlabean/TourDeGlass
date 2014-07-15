using UnityEngine;
using System.Collections;

public class SonificationChannel : MonoBehaviour {

	public BikeController bikeController;
	public AudioClip sonifySound;
	private AudioSource audioSource;
	public float cadenceTarget = 10f;
	// Use this for initialization
	void Start () {
		InitializeAudioSource();
		audioSource.Play ();
		audioSource.loop = true;
	}
	
	// Update is called once per frame
	void Update () {
		audioSource.volume = Mathf.Abs(1 - (Mathf.Abs(bikeController.pedalCadence / cadenceTarget)));
		audioSource.pitch = Mathf.Abs(1 - (Mathf.Abs(bikeController.pedalCadence / cadenceTarget)));
	}

	void InitializeAudioSource()
	{
		//we setup a new AudioSource here to not conflict with any ambient sound effects
		//we may have put on objects in our scene
		
		//This lets us have an ambient loop play while also playing a different
		//sound on collision with the character or another object.
		
		if (audioSource != null) //if we have already set it up
			return;
		GameObject go = new GameObject();
		go.transform.parent = transform;
		go.name = "Sonify-" + gameObject.name;
		audioSource = go.AddComponent<AudioSource>();
		audioSource.clip = sonifySound;
	}
}
