using UnityEngine;
using System.Collections;

public class GradeController : MonoBehaviour {

	public float grade = 0f;
	public GameObject ground;
	public BikeController bikeController;

	void FixedUpdate()
	{
		//ground.transform.position = ground.transform.position + Vector3.forward * bikeController.velocity * Time.deltaTime;

		Material groundMaterial = ground.GetComponent<MeshRenderer>().material;
		groundMaterial.mainTextureOffset = new Vector2(0f, groundMaterial.mainTextureOffset.y + bikeController.velocity * Time.deltaTime);
	}
}
