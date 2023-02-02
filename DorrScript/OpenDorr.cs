using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDorr : MonoBehaviour
{
    [SerializeField] private Animator door = null;
    [SerializeField] private bool IsOpen = false;
    public AudioSource openSound;
    public AudioSource closeSound;
    public bool canOpen = true;
    public string AnimationOpenName;
    public string AnimationCloseName;
    public void OpenDoor()
    {
        if (canOpen == true)
        {
            door.Play(AnimationOpenName, 0, 0.0f);
            IsOpen = true;
            //openSound.Play();
        }
    }
    public void CloseDoor()
    {
        if (canOpen == true)
        {
            door.Play(AnimationCloseName, 0, 0.0f);
            IsOpen = false;
            //closeSound.Play();
        }
    }
    public void Dorr()
    {
        if (IsOpen)
            CloseDoor();
        else
            OpenDoor();
    }
}