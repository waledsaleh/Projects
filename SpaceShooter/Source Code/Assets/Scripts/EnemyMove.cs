using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	public int speed = 5;
	//public GameObject explosion;
	public static int score=0;
	public static bool gameover=false;
	void Start () {
		Vector3 v = rigidbody2D.velocity;
		v.y = -speed;
		rigidbody2D.velocity = v;
		rigidbody2D.angularVelocity = Random.Range (-200, 200);
		Destroy(gameObject, 3);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D obj) {  

		
		// If it collided with a bullet
		if (obj.gameObject.name == "bullet(Clone)") {
			// Destroy itself (the enemy)
		//	 Instantiate(explosion,transform.position,Quaternion.identity);
			Destroy(gameObject);
			score++;

			// And destroy the bullet
			Destroy(obj.gameObject);
		}
		
		// If it collided with the spaceship
		if (obj.gameObject.name == "spaceship") {
			// Destroy itself (the enemy) to keep things simple

			Destroy(obj.gameObject);

			gameover=true;}
	}
	void OnGUI () {
		if (gameover) {
			if(Application.isPlaying)
			{
				Time.timeScale=0;
				GUI.Label(new Rect(Screen.width/2-30, Screen.height/2, 70, 50), "Game Over");
				//gameover=false;
			}

						if (GUI.Button (new Rect (Screen.height/2, Screen.width/2, 80, 20), "Restart ?")) {
				           Time.timeScale=1;
				           gameover=false;
				score=0;
								Application.LoadLevel (0);

						}
			if (GUI.Button (new Rect (Screen.height/2, Screen.width/2+20, 80, 20), "Exit")) {

				Application.Quit();
				
			}
			
		}
	}
}
