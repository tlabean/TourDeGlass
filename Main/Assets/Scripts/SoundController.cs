using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {


	public float closeZone = 0.5f;
	public float mainAudioVolume = 0f;
	public float mainAudioVolumeScale = 1f;
	
	public AudioSource mainSource;
	public AudioClip slowSound;
	public AudioClip closeSound;
	public AudioClip fastSound;
	public AudioSource secondarySource;

	public AudioClip bikePassing;
	public AudioClip carPassing;

	public GradeController gradeController;
	public BikeController bikeController;
	public Transform pedals;

	private float pedalsLastXRotation;

	private bool playAgain = false;

	void Awake()
	{
		pedalsLastXRotation = pedals.rotation.eulerAngles.x;
	}

	void FixedUpdate()
	{

		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			secondarySource.clip = bikePassing;
			secondarySource.Play();
		}

		if(playAgain && !mainSource.isPlaying)
		{
			mainSource.Play ();
			playAgain = false;
		}

		if(pedalsLastXRotation < 180f && pedals.rotation.eulerAngles.x > 180f)
		{

			if(!mainSource.isPlaying)
			{
				if(bikeController.pedalCadence > 7f + closeZone)
					mainSource.clip = fastSound;
				else if(bikeController.pedalCadence < 7f - closeZone)
					mainSource.clip = slowSound;
				else
					mainSource.clip = closeSound;


				mainSource.volume = mainAudioVolume + Mathf.Abs(bikeController.pedalCadence - 7f) * mainAudioVolumeScale;

				mainSource.Play();
			}
			else
			{
				playAgain = true;
			}
		}
		pedalsLastXRotation = pedals.rotation.eulerAngles.x;
	}
}
