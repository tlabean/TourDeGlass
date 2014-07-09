using UnityEngine;
using System.Collections;

public class BikeController : MonoBehaviour {

	public GradeController gradeController;
	public float fluidFriction;
	public float pedalTorque;
	public float bikeMass;
	public float gearMultiplier;
	public int gear;

	public Transform frontWheel;
	public Transform backWheel;
	public float wheelRadius;
	public Transform pedals;

	public float velocity;

	void Awake()
	{

	}

	void FixedUpdate()
	{
		velocity -= velocity * velocity * fluidFriction / bikeMass;

		frontWheel.Rotate ( velocity * Time.deltaTime / wheelRadius / 2f * Mathf.PI * Mathf.Rad2Deg, 0f, 0f);
		backWheel.Rotate ( velocity * Time.deltaTime / wheelRadius / 2f * Mathf.PI * Mathf.Rad2Deg, 0f, 0f);
		pedals.Rotate ( velocity * Time.deltaTime / wheelRadius / 2f * Mathf.PI * Mathf.Rad2Deg / ((float)(gear-1) * gearMultiplier + 1f) , 0f, 0f);

	}

}
