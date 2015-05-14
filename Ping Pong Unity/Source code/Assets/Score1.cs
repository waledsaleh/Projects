using UnityEngine;
using System.Collections;

public class Score1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "Score1: "+Ball.Player1_Score+"\nPlayer1";

	}
}
