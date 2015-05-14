using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {

	// Use this for initialization
	void Start () {
		guiText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Ball.check1) {

			guiText.text="Player 1 is Win";
			guiText.enabled=true;
//			Time.timeScale=0;

				}
		if (Ball.check2) {

			guiText.text="Player 2 is Win";
			guiText.enabled=true;
		//	Time.timeScale=0;
				}


	}
}
