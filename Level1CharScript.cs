using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[SerializeField]
public class Level1CharScript : MonoBehaviour {

	public static Level1CharScript instance;
	public float speed;
	public float sensitivity = 30.0f;
	public float WaterHeight = 15.5f;
	CharacterController character;
	public GameObject cam;
	float moveFB, moveLR;
	float rotX, rotY;
	public bool webGLRightClickRotation = true;
	float gravity = -9.8f;
	public Rigidbody CharacterFizic;

	public bool canMove;
	public float JumpDistance = 40f;
	public float sprint;

	public AudioSource StepsSound;
	public Texture2D cursorTexture;
	public float jumpHeight = 2f;
	public Transform groundCheck;
	public float groundDistance = 1f;
	public LayerMask groundMask;


	Vector3 velocity;
	bool isGrounded;
	private Vector3 oldPos;

    private void Awake()
    {
		instance = this;
    }

    void Start(){
		//LockCursor ();

		oldPos = transform.position;
		character = GetComponent<CharacterController> ();

			webGLRightClickRotation = false;
			sensitivity = sensitivity * 1.5f;
		SetCursor(false);
	}


	void CheckForWaterHeight(){
		if (transform.position.y < WaterHeight) {
			gravity = 0f;
		} else {
			gravity = -9.8f;
		}
	}
	void Update(){

		if(canMove == false)
			return;

		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
		
		if(isGrounded && velocity.y < 0)
        {
			velocity.y = -2f;
        }

		velocity.y += gravity * Time.deltaTime;


		character.Move(velocity * Time.deltaTime);

		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 move = transform.right * x + transform.forward * z;

		moveFB = Input.GetAxis ("Horizontal") * speed;
		moveLR = Input.GetAxis ("Vertical") * speed;

		rotX = Input.GetAxis ("Mouse X") * sensitivity;
		rotY = Input.GetAxis ("Mouse Y") * sensitivity;

		//rotX = Input.GetKey (KeyCode.Joystick1Button4);
		//rotY = Input.GetKey (KeyCode.Joystick1Button5);

		CheckForWaterHeight ();


		Vector3 movement = new Vector3 (moveFB, gravity, moveLR);

		CameraRotation (cam, rotX, rotY);

		character.Move(move * speed * Time.deltaTime);


		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			Jump();
        }
		//Cand o sa avem animatie la umblat o sa mearga footstepu
		//if(isGrounded && transform.position != oldPos)
        //{
			//StepsSound.Play();
        //}
		else
		{
			StepsSound.Stop();
        }
		/*if(Input.GetKey(KeyCode.Escape))
		{
			SetCursor(true);
		}
		if(Input.GetKey(KeyCode.Space))
		{
			SetCursor(false);
			
		}*/
		oldPos = transform.position;

	}


	void CameraRotation(GameObject cam, float rotX, float rotY){
		transform.Rotate (0, rotX * Time.deltaTime, 0);
		cam.transform.Rotate (-rotY * Time.deltaTime, 0, 0);
	}
	public void Jump()
	{
		velocity.y = Mathf.Sqrt(jumpHeight * -0.8f * gravity);
	}



	private void SetCursor(bool trigger)
	{
		Cursor.visible = trigger;
		Cursor.lockState = trigger ? CursorLockMode.None : CursorLockMode.Locked;
		Cursor.SetCursor(trigger ? null : cursorTexture, Vector2.zero, trigger ? CursorMode.Auto : CursorMode.ForceSoftware);
	}

}
