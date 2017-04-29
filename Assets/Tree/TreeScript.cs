using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour {

	float objectSpeed=-0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	//make the trees moves in the scene
	void Update () {
		transform.Translate(0, 0, objectSpeed);
	}
}
