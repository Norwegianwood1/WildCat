using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlScript : MonoBehaviour {
	float timeRemaining = 30;   //Pre-earned time
	float timeExtension = 3f;   //time to extend by on collecting powerup
	float totalTimeElapsed = 0;   
	float score=0f;      //total score
	public bool isGameOver = false;  
	public GUISkin skin;
	public string gameLevel;
	public GUIText guiTextScore;
	public GUIText guiTextTime;

	public void FishClownCollected()
	{
		timeRemaining += timeExtension; //add time to the time remaining
		StartCoroutine(Delay(guiTextTime)); //make the GUIText "+ 2 seconds" appears for 1 sec


	}

	IEnumerator Delay(GUIText text) {   
		text.enabled = true;
		yield return new WaitForSeconds (1);
		text.enabled = false;
	
	}


	public void FishBlueCollected() {
		score += 50; //increase points
		StartCoroutine (Delay (guiTextScore)); //function to make appear GUIText "+ 50 points" for 1 sec

	}

	public void StonesCollected()
	{
		
		isGameOver = true; //end game when player hit a Stone
	}

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		guiTextScore.enabled = false; //disable the GUIText "+ 50 POINTS" and "+ 2 SECONDS" on Start
		guiTextTime.enabled = false;

		
	}
	
	// Update is called once per frame
	void Update () {

		if(isGameOver)     //check if isGameOver is true
			return;      //move out of the function

		totalTimeElapsed += Time.deltaTime; 
		score = totalTimeElapsed*100;  //calculate the score based on total time elapsed
		timeRemaining -= Time.deltaTime; //decrement the time remaining by 1 sec every update
		if(timeRemaining <= 0){
			isGameOver = true;    // set the isGameOver flag to true if timeRemaining is zero
		}
		
	} 



	void OnGUI()
	{    
		GUI.skin=skin;


		//check if game is not over, if so, display the score and the time left
		if(!isGameOver)    
		{
			GUI.Label(new Rect(10, 10, Screen.width/5, Screen.height/6),"TIME LEFT: "+((int)timeRemaining).ToString());
			GUI.Label(new Rect(Screen.width-(Screen.width/6), 10, Screen.width/6, Screen.height/6), "SCORE: "+((int)score).ToString());
		}

		//if game over, display game over menu with score

		else
		{
			Time.timeScale = 0; //set the timescale to zero so as to stop the game world

			//display the final score
			GUI.Box(new Rect(Screen.width/4, Screen.height/4, Screen.width/2, Screen.height/2), "GAME OVER\nYOUR SCORE: "+(int)score);


			//restart the game on click
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+Screen.height/10+10, Screen.width/2-20, Screen.height/10), "RESTART")){
				Application.LoadLevel(Application.loadedLevel);
			}

			//load the main menu, which as of now has not been created
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+2*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "MAIN MENU")){
				Application.LoadLevel(gameLevel);
			}

			//exit the game
			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+3*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "EXIT GAME")){
				Application.Quit();

			}
		}
	}
}
