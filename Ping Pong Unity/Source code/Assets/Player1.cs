using UnityEngine;
using System.Collections;

public class Player1 : MonoBehaviour {
	
	// Use this for initialization
	public float speed;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			
			transform.Translate(Vector3.up*speed);
			
		}
		if (Input.GetKey (KeyCode.S)) {
			
			transform.Translate(Vector3.down*speed);
			
		}
		if (transform.position.y > 12) {
			
			Vector3 temp = transform.position; 
			temp.y = 12; 
			transform.position = temp; 
			
			
		}
		if (transform.position.y < -12) {
			
			Vector3 temp = transform.position; 
			temp.y = -12; 
			transform.position = temp; 
			
			
		}
		
	}
}
