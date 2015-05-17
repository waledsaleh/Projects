using UnityEngine;
using System.Collections;

public class MoveShip : MonoBehaviour {

	public GameObject bullet;
	void Update () {
		float value = Input.GetAxis ("Horizontal");
		Vector3 v = rigidbody2D.velocity;
		v.x = value * 10;
		rigidbody2D.velocity= v;
		 value = Input.GetAxis ("Vertical");
		 v = rigidbody2D.velocity;
		v.y = value * 10;
		rigidbody2D.velocity= v;

		if(Input.GetKey(KeyCode.Space))
		   {

			Instantiate(bullet, transform.position, Quaternion.identity);
		}

						if (transform.position.x < -6) {
			           Vector2 v2 = transform.position;
			           v2.x=-5;
			           v2.y= -4;
			renderer.enabled=false;
								transform.position = v2;
			renderer.enabled=true;
						}
						if (transform.position.x > 5) {
			
								transform.position = new Vector2 (5, -4);
						}
		renderer.enabled=false;
		renderer.enabled=true;

	}
}
