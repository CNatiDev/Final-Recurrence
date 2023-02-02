using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Events;
public class Door1 : MonoBehaviour
{
    //Variables on how much and how fast the door can be opene
    public static Door1 instance;
    public float ySensitivity, ySensitivityController;
    public float frontOpenPosLimit;
    public float backOpenPosLimit;

    public bool isLocked = false;
    public GameObject frontDoorCollider;
    public GameObject backDoorCollider;
    [SerializeField]
    private Camera mainCamera;
    public float yRot = 0, creakAng;
    public AudioClip[] creak;
    private float angle = 0;
    private float lastAngle = 0;
    private float lastCreak = 0;
    DoorCollision doorCollision = DoorCollision.NONE;
    public Image crosshair;
    [Space]
    [Header("Audio")]
    bool moveDoor = false;
    public AudioSource closeDoor;
    public AudioClip openDoorSFX;
    public UnityEvent @event;
    public void unlockDoor()
    {
        isLocked = false;
    }
    public void lockDoor()
    {
        isLocked = true;
    }
    public void changeLimitFrontDoor(int x)
    {
        frontOpenPosLimit = x;
    }
    public void changeLimitBackDoor(int y)
    {
        backOpenPosLimit = y;
    }
    void Awake()
    {
        if (instance == null)
            instance = this;
        StartCoroutine(doorMover());
    }
    void Update()
    {
        //Set a ray starting from the camera's middle
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Mathf.Abs(this.gameObject.transform.localPosition.y) >= 35)
            @event.Invoke();
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            if (PauseMenu.instance.IsGamePaused == true)
                return;
            RaycastHit hitInfo;
            //Draw a ray from the ray's starting point forwards with a specified distance
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo, 10f))
            {
                //If the object hit was either the front door collider or the back door collider play a quick door opening sound
                //along with specifying which collision was hit
                if (hitInfo.collider.gameObject == frontDoorCollider)
                {
                    moveDoor = true;
                    doorCollision = DoorCollision.FRONT;
                    Fps_Script.instance.canRotate = false;
/*                    Fps_Script.instance.walkingSpeed = 3f;
                    Fps_Script.instance.runningSpeed = 3f;*/
                    if (closeDoor != null)
                        closeDoor.PlayOneShot(openDoorSFX);
                }
                else if (hitInfo.collider.gameObject == backDoorCollider)
                {
                    moveDoor = true;
                    doorCollision = DoorCollision.BACK;
                    Fps_Script.instance.canRotate = false;
/*                    Fps_Script.instance.walkingSpeed = 3f;
                    Fps_Script.instance.runningSpeed = 3f;*/
                    if (closeDoor != null)
                        closeDoor.PlayOneShot(openDoorSFX);
                }
                else
                {
                    doorCollision = DoorCollision.NONE;
                }
            }
        }

        if ((Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.JoystickButton3)) && moveDoor == true)
        {
            //Move at the normal speed after releasing the click
            angle = lastAngle = 0;
            moveDoor = false;
            Fps_Script.instance.canRotate = true;
            Stamina.instance.normalWalk = 11;
            Stamina.instance.normalSprint = 22;
        }
    }

    IEnumerator doorMover()
    {
        bool stoppedBefore = false;
        while (true)
        {
            if (moveDoor)
            {
                stoppedBefore = false;
                //Rotate the door's local angles depending on the location and the mouse's Y axis
                //And make sure the rotation doesn't go past the opening limit
                if (doorCollision == DoorCollision.FRONT)
                {
                    angle += Input.GetAxis("Mouse X");
                    if (Mathf.Abs(angle - lastAngle) > creakAng && (this.gameObject.transform.localEulerAngles.y > 0 
                        && this.gameObject.transform.localEulerAngles.y < backOpenPosLimit))
                    {
                        Stamina.instance.normalSprint = 1f;
                        Stamina.instance.normalWalk = 1f;
                        lastAngle = angle; // update lastAngle
                        float deltaT = Time.time - lastCreak; // calc time from last creak
                        lastCreak = Time.time;
                        // increase pitch somewhat according to speed:
                        closeDoor.pitch = Mathf.Clamp((0.5f + 0.1f) / (0.5f + deltaT), 0.8f, 1f);
                        // play a randomly selected creak sound:
                        closeDoor.PlayOneShot(creak[Random.Range(0, creak.Length)]);
                    }
                    Gamepad gamepad = Gamepad.current;
                    if (gamepad == null)
                        yRot += -Input.GetAxis("Mouse Y") * ySensitivity * Time.fixedDeltaTime;
                    else
                        yRot += Input.GetAxis("MouseYDoor") * ySensitivityController * Time.fixedDeltaTime;
                    yRot = Mathf.Clamp(yRot, 0, backOpenPosLimit);
                    transform.localEulerAngles = new Vector3(0, yRot, 0);
                }
                else if (doorCollision == DoorCollision.BACK)
                {
                    Stamina.instance.normalSprint = 1f;
                    Stamina.instance.normalWalk = 1f;
                    angle += Input.GetAxis("Mouse X");
                    if (Mathf.Abs(angle - lastAngle) > creakAng && (this.gameObject.transform.localEulerAngles.y < backOpenPosLimit
                        && this.gameObject.transform.localEulerAngles.y > 0))
                    {
                        lastAngle = angle; // update lastAngle
                        float deltaT = Time.time - lastCreak; // calc time from last creak
                        lastCreak = Time.time;
                        // increase pitch somewhat according to speed:
                        closeDoor.pitch = Mathf.Clamp((0.5f + 0.1f) / (0.5f + deltaT), 0.8f, 1f);
                        // play a randomly selected creak sound:
                        closeDoor.PlayOneShot(creak[Random.Range(0, creak.Length)]);
                    }
                    Gamepad gamepad = Gamepad.current;
                    if (gamepad == null)
                        yRot += Input.GetAxis("Mouse Y") * ySensitivity * Time.fixedDeltaTime;
                    else
                        yRot += Input.GetAxis("MouseYDoor") * ySensitivityController * Time.fixedDeltaTime;
                    yRot = Mathf.Clamp(yRot, 0, backOpenPosLimit);
                    transform.localEulerAngles = new Vector3(0, yRot, 0);
                }
            }
            else
            {
                if (!stoppedBefore)
                {
                    stoppedBefore = true;
                    //Debug.Log("Stopped Moving Door");
                }
            }
            yield return null;
        }

    }

    enum DoorCollision
    {
        NONE, FRONT, BACK
    }
}
