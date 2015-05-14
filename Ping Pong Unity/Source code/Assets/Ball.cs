using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	  public static int Player1_Score=5;
	  public static int Player2_Score=5;
	  public float speed =10;
	public static bool check1 = false;
	public static bool check2 = false;
	  // Use this for initialization
	void Start () {
	
		rigidbody2D.velocity = Vector2.one.normalized * speed;
	}
	
	// Update is called once per frame
	void Update () {
		 if (Player1_Score == 0) {

			check2=true; 
			Destroy(gameObject);
		}
		if (Player2_Score == 0) {

			check1=true; 
			Destroy(gameObject);
		}
		if(transform.position.x >21)
		{
			Player2_Score--;
			Vector3 temp = transform.position; 
			temp.x = 0;
			temp.y=0;
			transform.position = temp; 
		}
		if(transform.position.x <-21)
		{
			Player1_Score--;
			Vector3 temp = transform.position; 
			temp.x = 0;
			temp.y=0;
			transform.position = temp; 
		}
	}
	float hitFactor(Vector2 ballPos, Vector2 racketPos,  float racketHeight) {
	                
	              

		return (ballPos.y - racketPos.y) / racketHeight;
		
	}
	void OnCollisionEnter2D(Collision2D col) {
		
		// Hit the left Rec
		
		if (col.gameObject.name == "Player1") {
			
			// Calculate hit Factor
			
			float y=hitFactor(transform.position,
			                  
			                  col.transform.position,
			                  
			                  ((BoxCollider2D)col.collider).size.y);
			
			
			
			// Calculate direction, set length to 1
			
			Vector2 dir = new Vector2(1, y).normalized;
			
			
			
			// Set Velocity with dir * speed
			
			rigidbody2D.velocity = dir * speed;
			
		}
		
		
		
		// Hit the right Rec
		
		if (col.gameObject.name == "Player2") {
			
			// Calculate hit Factor
			
			float y=hitFactor(transform.position,
			                  
			                  col.transform.position,
			                  
			                  ((BoxCollider2D)col.collider).size.y);
			
			
			
			// Calculate direction, set length to 1
			
			Vector2 dir = new Vector2(-1, y).normalized;
			
			
			
			// Set Velocity with dir * speed
			
			rigidbody2D.velocity = dir * speed;
			
		}
		
	}
	
	


}
