using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	float speed = .5f;
	void Start () {
		
	}
	
	// Update is called once per frame

	//material of the Ground simulates the movement
	void Update () {
		float offset = Time.time * speed;                             
		gameObject.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, -offset); 
		
	}
}
