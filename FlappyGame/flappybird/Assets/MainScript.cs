using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {


	public GameObject pipeObject;	
	public GameObject birdObject;	
	public float pipeHole;			


	void Start () {

		Instantiate(birdObject);

		InvokeRepeating("CreateObstacle", 0f, 1.5f);
	}


	void CreateObstacle(){

		float randomPos = 4f-(4f-0.8f-pipeHole)*Random.value;
	
		GameObject upperPipe = (GameObject)Instantiate(pipeObject);

		upperPipe.transform.position = new Vector2(4f,randomPos);
	
		GameObject lowerPipe = (GameObject)Instantiate(pipeObject);

		lowerPipe.transform.position = new Vector2(4f,randomPos-pipeHole-4.8f);

	
	}
}