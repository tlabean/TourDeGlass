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

	public float pedalCadence;
	public float velocity;

	void Awake()
	{

	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.UpArrow) && gear < 9)
			gear++;
		if(Input.GetKeyDown(KeyCode.DownArrow) && gear > 1)
			gear--;
	}

	void FixedUpdate()
	{
		velocity -= (velocity * fluidFriction + velocity * velocity * fluidFriction) / bikeMass * Time.deltaTime;
		velocity += -9.8f * Mathf.Sin (gradeController.grade * Mathf.Deg2Rad) * Time.deltaTime;
		velocity += pedalTorque / ((float)(gear - 1) * gearMultiplier + 1f) * Time.deltaTime;
		if(velocity < 0f)
			velocity = 0f;
		frontWheel.Rotate ( velocity * Time.deltaTime / wheelRadius / 2f * Mathf.PI * Mathf.Rad2Deg, 0f, 0f);
		backWheel.Rotate ( velocity * Time.deltaTime / wheelRadius / 2f * Mathf.PI * Mathf.Rad2Deg, 0f, 0f);
		pedals.Rotate ( velocity * Time.deltaTime / wheelRadius / 2f * Mathf.PI * Mathf.Rad2Deg / ((float)(gear-1) * gearMultiplier + 1f) , 0f, 0f);
		pedalCadence = velocity * Time.deltaTime / wheelRadius / 2f * Mathf.PI * Mathf.Rad2Deg / ((float)(gear-1) * gearMultiplier + 1f);
	}

}
