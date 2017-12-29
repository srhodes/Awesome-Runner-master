using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float movementSpeed = 5f;
	private Rigidbody myBody;
	public float JumpPower = 10f;
	public float secondJumpPower = 10f;
	public Transform groundCheckPosition;
	public float radius = 0.3f;
	public LayerMask LayerGround;
	public GameObject smokePosition;

	private bool isGrounded;
	private bool playerJumped = false;
	private bool canDoubleJump = false;
	private PlayerAnimation playerAnim;
	private bool gameStarted;

	private BGScroller bgScroller;

	void Awake(){

		myBody = GetComponent<Rigidbody> ();
		playerAnim = GetComponent<PlayerAnimation> ();
		bgScroller = GameObject.Find (Tags.BACKGROUND_GAME_OBJ).GetComponent<BGScroller> ();

	}

	void Start(){
		StartCoroutine (StartGame());
	}

	void FixedUpdate(){
		if (gameStarted) {
			PlayerMove ();
			PlayerGrounded ();
			PlayerJump ();
		}
	}

	void PlayerMove(){
		//myBody.velocity = new Vector3 (movementSpeed, 0f, 0f);
		myBody.velocity = new Vector3 (movementSpeed, myBody.velocity.y, 0f);

	}// Use this for initialization

	void PlayerGrounded(){
		isGrounded = Physics.OverlapSphere (groundCheckPosition.position, radius, LayerGround).Length > 0;
		if(isGrounded && playerJumped){
			playerJumped = false;
			playerAnim.DidLand ();
		}
	}

	void PlayerJump(){
		if (Input.GetKeyDown (KeyCode.Space) && !isGrounded && canDoubleJump) {
			canDoubleJump = false;
			myBody.AddForce (new Vector3(0, secondJumpPower, 0));
		}
		else if (Input.GetKeyUp (KeyCode.Space) && isGrounded){
			Debug.Log ("Animation");

			playerAnim.DidJump ();
			myBody.AddForce (new Vector3 (0, JumpPower, 0));
			playerJumped = true;
			canDoubleJump = true;
		}
	}

	IEnumerator StartGame(){
		yield return new WaitForSeconds (2f);
		gameStarted = true;
		bgScroller.canScroll = true;
		smokePosition.SetActive (true);
		playerAnim.PlayerRun();
	}
}
