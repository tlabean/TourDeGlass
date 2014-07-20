using UnityEngine;
using System.Collections;

public class GradeController : MonoBehaviour {

	public float grade = 0f;
	public GameObject ground;
	public BikeController bikeController;

	void FixedUpdate()
	{


		Material groundMaterial = ground.GetComponent<MeshRenderer>().material;
		groundMaterial.mainTextureOffset = new Vector2(0f, groundMaterial.mainTextureOffset.y + bikeController.velocity * Time.deltaTime);
		transform.rotation = Quaternion.Euler (grade, 0f, 0f);

	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.W) && grade < 50) 
			grade++;
		if(Input.GetKeyDown(KeyCode.S) && grade > -50)
			grade--;
	}
}