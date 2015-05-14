using UnityEngine;
using System.Collections;

public class Score2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "Score2: "+Ball.Player2_Score+"\nPlayer2";

	}
}
