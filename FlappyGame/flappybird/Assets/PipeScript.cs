using UnityEngine;
using System.Collections;

public class PipeScript : MonoBehaviour {


	public Vector2 pipeVelocity = new Vector2();


	void Start () {

		GetComponent<Rigidbody2D>().velocity = pipeVelocity;
	}


	void Update () {

		if(transform.position.x<-4){

			Destroy(gameObject);
		}
	}
}
