using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpLevelScript : MonoBehaviour {
	public GUISkin myskin;  //custom GUIskin reference
	public string gameLevel;


	void OnGUI() {


		GUI.skin=myskin;

		if (GUI.Button(new Rect(450, 370, 100, 50), "RETURN")){
			Application.LoadLevel(gameLevel);



	}
}
}