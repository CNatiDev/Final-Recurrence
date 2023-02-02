using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public static Ladder instance;
    public GameObject playerObject;
    public bool canClimb = false;
    public float speed = 2f;
    private void Awake()
    {
        instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canClimb = true;
            Fps_Script.instance.walkingSpeed = speed;
            Fps_Script.instance.runningSpeed = speed;
            Stamina.instance.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other1)
    {
        canClimb = false;
        Fps_Script.instance.walkingSpeed = Stamina.instance.normalWalk;
        Fps_Script.instance.runningSpeed = Stamina.instance.normalSprint;
        Stamina.instance.enabled = true;
    }
}
