using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorJumpScare : MonoBehaviour
{
    public string AnimationOpenName;
    public string AnimationCloseName;
    public Animator DoorAnimator;

    public void OpenDoor()
    {
        DoorAnimator.Play(AnimationOpenName, 0, 0.0f);
    }
    public void CloseDoor()
    {
        DoorAnimator.Play(AnimationCloseName, 0, 0.0f);
    }
}
