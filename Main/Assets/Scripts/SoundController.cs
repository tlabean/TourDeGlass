using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {


	public AudioSource mainSource;
	public AudioClip slowSound;
	public AudioClip fastSound;
	public float mainAudioVolumeScale = 1f;
	public AudioSource secondarySource;

	public AudioClip bikePassing;
	public AudioClip carPassing;

	public GradeController gradeController;
	public BikeController bikeController;
	public Transform pedals;

	private float mainAudioVolume;
	private float pedalsLastXRotation;

	void Awake()
	{
		mainAudioVolume = 0.2f;
		pedalsLastXRotation = pedals.rotation.eulerAngles.x;
	}

	void FixedUpdate()
	{

		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			secondarySource.clip = bikePassing;
			secondarySource.Play();
		}


		if(pedalsLastXRotation < 180f && pedals.rotation.eulerAngles.x > 180f)
		{

			if(!mainSource.isPlaying)
			{
				if(bikeController.pedalCadence > 7f)
					mainSource.clip = fastSound;
				else
					mainSource.clip = slowSound;

				mainSource.volume = mainAudioVolume + Mathf.Abs(bikeController.pedalCadence - 7f) * mainAudioVolumeScale;

				mainSource.Play();
			}
		}
		pedalsLastXRotation = pedals.rotation.eulerAngles.x;
	}
}
