using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
	public bikeController testing;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		testing.SPEED_CONSTANT = 0f;
	}
}
