using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {


	public AudioSource mainSource;
	public AudioClip slowSound;
	public AudioClip fastSound;
	public float mainAudioVolumeScale = 1f;
	public AudioSource secondarySource;

	public GradeController gradeController;
	public BikeController bikeController;
	public Transform pedals;

	private float mainAudioVolume;
	private float pedalsLastXRotation;

	void Awake()
	{
		mainAudioVolume = mainSource.volume;
		pedalsLastXRotation = pedals.rotation.eulerAngles.x;
	}

	void FixedUpdate()
	{
		if(pedalsLastXRotation < 180f && pedals.rotation.eulerAngles.x > 180f)
		{


			if(bikeController.pedalCadence > 7f)
				mainSource.clip = fastSound;
			else
				mainSource.clip = slowSound;

			mainSource.volume = mainAudioVolume + bikeController.pedalCadence * mainAudioVolumeScale;

			mainSource.Play();
		}
		pedalsLastXRotation = pedals.rotation.eulerAngles.x;
	}
}
