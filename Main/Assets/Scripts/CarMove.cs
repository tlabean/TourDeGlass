using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class CarMove : MonoBehaviour {

public AudioClip sound;
public Vector3 startPoint;
public Vector3 endPoint;
public Vector3 currentPoint;
public float startTime;
public int keyPress1;
public float dist;
public GameObject go1;
public AudioSource alarmSource;
public AudioClip alarm;
public float dur;
public AudioClip bike;
public int keyPress2;

void Awake(){

endPoint = new Vector3(2.3f,1.0f,-14.0f);
go1 = GameObject.Find("Bike");
}

void FixedUpdate(){

		 dist = Vector3.Distance(go1.transform.position, this.transform.position);

		if(Input.GetKeyDown(KeyCode.A)){ //if A is pressed
		startTime = Time.time;
		keyPress1 = 1;
		this.transform.position = new Vector3(2.3f,1.0f,20f);
		startPoint = this.transform.position;
		audio.loop = false;
		playSound("car_pass");
		alarmSource.clip = alarm;
		}
		
		if(Input.GetKeyDown(KeyCode.D)){   //if D is pressed
		startTime = Time.time;
		keyPress2 = 1;
		this.transform.position = new Vector3(2.3f,1.0f,20f);
		startPoint = this.transform.position;
		audio.loop = true;
		playSound("BikeWheelSpin");
		alarmSource.clip = bike;
		}
		
		
		if(transform.position == endPoint){
		
		if (keyPress1 == 1)
		keyPress1 = 0;
		
		if(keyPress2 == 1)
		keyPress2 = 0;
		
		audio.Stop();
		transform.position = new Vector3(8f,15f,23f);
		}
		
		if(keyPress1 ==1){
		dur = Time.time-startTime;
		transform.position = Vector3.Lerp(startPoint,endPoint,(dur)/6.5f);
		
		if (dur>= 3 && alarmSource.isPlaying == false && dur<= 3.7){
			alarmSource.Play();
		}
		} else if(keyPress2 ==1){
					dur = Time.time-startTime;
				     transform.position = Vector3.Lerp(startPoint,endPoint,(dur)/7.5f);
				
				if (dur>= 3 && alarmSource.isPlaying == false && dur<= 3.7){
					alarmSource.Play();
				}
		}
		
		}
		
void playSound(string file){
sound = (AudioClip)Resources.Load(file);
audio.clip = sound;
audio.Play();
}
	
}

