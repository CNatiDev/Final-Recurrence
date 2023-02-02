using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RotateMirror : MonoBehaviour
{
    //Variables on how much and how fast the door can be opene
    public static RotateMirror instance;
    public float ySensitivity;

    public bool isLocked = false;
    public GameObject frontDoorCollider;
    [SerializeField]
    private Camera mainCamera;
    float yRot = 0;
    DoorCollision doorCollision = DoorCollision.NONE;
    public Image crosshair;
    public Sprite rotateObject;
    [Space]
    [Header("Audio")]
    bool moveDoor = false;
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
                    crosshair.sprite = rotateObject;
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
            moveDoor = false;
            Fps_Script.instance.canRotate = true;
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
                    yRot += -Input.GetAxis("Mouse Y") * ySensitivity * Time.deltaTime;
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
        NONE, FRONT
    }
}
