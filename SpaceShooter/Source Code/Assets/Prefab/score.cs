using UnityEngine;
using System.Collections;

public class score : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	

	void Update () {
		guiText.text = "Score: " + EnemyMove.score;
	}
}
