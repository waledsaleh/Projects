using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject enemy;
	// Use this for initialization
	public float spawnTime=2f;
	void Start () {
		GameObject.Find ("spaceship").SetActive (true);
		InvokeRepeating("addEnemy", spawnTime, spawnTime);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void addEnemy() {  
		// Variables to store the X position of the spawn object
		// See image below
		float x1 = transform.position.x - renderer.bounds.size.x/2;
		float x2 = transform.position.x + renderer.bounds.size.x/2;
		
		// Randomly pick a point within the spawn object
		Vector2 spawnPoint = new Vector2(Random.Range(x1,x2), transform.position.y);
		
		// Create an enemy at the 'spawnPoint' position
		Instantiate(enemy, spawnPoint, Quaternion.identity);
	}
}
