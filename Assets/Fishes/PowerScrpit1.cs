using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScrpit1 : MonoBehaviour {


	void Start () {
		
	}

	//use this function to move the fishes in the scene;
	public float objectSpeed = 0.5f;

	void Update () {
		transform.Translate(0, 0, objectSpeed);
	}
}
