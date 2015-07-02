using UnityEngine;
using System.Collections;

public class BirdScript : MonoBehaviour {


	public Vector2 jumpForce = new Vector2();

	AudioSource flyAudio ;
	public AudioClip fly;
	void Start () {
		flyAudio = GetComponent<AudioSource>();

		transform.position = new Vector2(-2f,0f);
	}
	 	
	void Update () {

		if (Input.GetButtonDown("Fire1")) {
		
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;

			GetComponent<Rigidbody2D>().AddForce(jumpForce);
			flyAudio.clip=fly;
			flyAudio.Play();

		}	

		Camera camera =(Camera) GameObject.Find ("Camera").camera;
	
		Vector2 stagePos = camera.WorldToScreenPoint(transform.position);

		if (stagePos.y > Screen.height || stagePos.y < 0){
 
		 	die();

		}
	}


	void OnCollisionEnter2D(){
 
		die();
	}
	
	void die(){

		Application.LoadLevel(Application.loadedLevel);
	}
}