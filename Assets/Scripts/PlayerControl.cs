using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	CharacterController controller; //reference to the controller
	bool isGrounded=false; //check if the kitten is on the ground 
	public float speed = 6.0f; 
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;
	public GameControlScript control; //reference to the game controller

	//Android variables
	Vector3 ZeroAcc;
	Vector3 CurrentAcc;
	float sensitivityH = 3;
	float smooth = 0.5f;
	float getAxisH=0;

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		controller = GetComponent<CharacterController> ();
		GetComponent<Animation>().Play ("Jump");
		//init Android variables
		ZeroAcc = Input.acceleration;
		CurrentAcc = Vector3.zero;
		
	}



	// Update is called once per frame
	void Update () {


		//Android part
		CurrentAcc = Vector3.Lerp (CurrentAcc, Input.acceleration - ZeroAcc, Time.deltaTime / smooth);
		getAxisH = Mathf.Clamp (CurrentAcc.x * sensitivityH, -1, 1);
		int fingerCount = 0;
		foreach (Touch touch in Input.touches) {

			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
				fingerCount++;
		}



	

		//end
		if (controller.isGrounded) {
			GetComponent<Animation>().Play ("Run");          //play "run" animation if spacebar is not pressed
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);  //get keyboard input to move in the horizontal direction
			moveDirection = transform.TransformDirection(moveDirection);  //apply this direction to the character
			moveDirection *= speed;            //increase the speed of the movement by the factor "speed" 

			if (Input.GetButton ("Jump")) {          //play "Jump" animation if character is grounded and spacebar is pressed
				GetComponent<Animation>().Stop ("Run"); 
				GetComponent<Animation>().Play ("Jump"); 
				moveDirection.y = jumpSpeed;   //add the jump height to the character
			}
			if(controller.isGrounded)           //set the flag isGrounded to true if character is grounded
				isGrounded = true;
		
			   
		}  
		//Android part
		moveDirection = new Vector3 (getAxisH, 0, 0);
		if (fingerCount >= 1) {

			GetComponent<Animation> ().Stop ("Run"); 
			GetComponent<Animation> ().Play ("Jump");
			moveDirection.y = jumpSpeed;
		}
	//end

		moveDirection.y -= gravity * Time.deltaTime;       //Apply gravity  
		controller.Move(moveDirection * Time.deltaTime);      //Move the controller
	}



	//check if the character collects the powerups(blue and clown fishes) or the snags(stones)
	void OnTriggerEnter(Collider other)
	{    

		if (other.gameObject.name == "FishClown(Clone)") {   
			
			control.FishClownCollected ();
		} 
		else if (other.gameObject.name == "Stone(Clone)") {
			control.StonesCollected ();
		} 
		else if (other.gameObject.name == "Fish(Clone)") {
			control.FishBlueCollected ();

		}
		Destroy(other.gameObject); 

	}
}
