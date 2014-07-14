using UnityEngine;
using System.Collections;



public class bikeController : MonoBehaviour {
	public float SPEED_CONSTANT = 1.5f;
	
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void FixedUpdate () {
		transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (1 * SPEED_CONSTANT));

	}
	

}
