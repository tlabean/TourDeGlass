using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class CarMove : MonoBehaviour {

public AudioClip sound;
public Vector3 startPoint;
public Vector3 endPoint;
public Vector3 currentPoint;
public float startTime;
public int keyPress;
public float dist;
public GameObject go1;
public AudioSource alarmSource;
public AudioClip alarm;

void Awake(){

//startPoint = transform.position;
startTime = Time.time;
endPoint = new Vector3(2.3f,1.0f,-10.0f);
go1 = GameObject.Find("Bike");
alarmSource.clip = alarm;
}

void FixedUpdate(){

		 dist = Vector3.Distance(go1.transform.position, this.transform.position);

		if(Input.GetKeyDown(KeyCode.A)){
		keyPress = 1;
		this.transform.position = new Vector3(2.3f,1.0f,20f);
		startPoint = this.transform.position;
		playSound("car_pass");
		}
		
		if(transform.position == endPoint){
		keyPress = 0;
		transform.position = new Vector3(8f,15f,23f);
		}
		
		if(keyPress==1)
		transform.position = Vector3.Lerp(startPoint,endPoint,(Time.time-startTime)/11.0f);
		
		if(dist > 8f){
		alarmSource.Play();
        }
		
		
		}
		
void playSound(string file){
sound = (AudioClip)Resources.Load(file);
audio.clip = sound;
audio.Play();
}
	
}

