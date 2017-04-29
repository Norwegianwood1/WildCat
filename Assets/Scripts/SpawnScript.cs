using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

	public GameObject powerup;
	public GameObject obstacle;
	public GameObject fishblue;
	public GameObject flower;
	public GameObject tree;
	public GameObject tree2;
	float timeElapsed = 0;
	float spawnCycle = 0.5f;
	bool spawnPowerup = true;
	bool isFish=true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		timeElapsed += Time.deltaTime;
		if(timeElapsed > spawnCycle)
		{
			GameObject temp;
			if (spawnPowerup ) { 
                
				if (isFish) {

					temp = (GameObject)Instantiate (powerup);
					Vector3 pos = temp.transform.position;
					temp.transform.position = new Vector3 (Random.Range (-3, 4), pos.y, pos.z);
				} 
				else {
					temp = (GameObject)Instantiate (fishblue);
					Vector3 pos = temp.transform.position;
					temp.transform.position = new Vector3 (Random.Range (-3, 4), pos.y, pos.z);

					}
				isFish = !isFish;
			} 

			else  {
				temp = (GameObject)Instantiate (obstacle);
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3 (Random.Range (-3, 4), pos.y, pos.z);
			} 


			timeElapsed -= spawnCycle;
			spawnPowerup = !spawnPowerup;
			if (spawnPowerup) {
				temp = (GameObject)Instantiate (flower);
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3 (Random.Range (-3, 4), pos.y, pos.z);
			} 

			 temp = (GameObject)Instantiate (tree);
			temp = (GameObject)Instantiate (tree2);
		}
		
	}

	void spawnTrees() {


	



	}
}
