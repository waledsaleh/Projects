using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {

	public int speed =10;
	void Start () {
		Vector3 v = rigidbody2D.velocity;
		v.y = 10;
		rigidbody2D.velocity = v;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	// if gameobject go out screen , will destroy
	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
}
