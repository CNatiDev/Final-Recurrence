using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAfterChase : MonoBehaviour
{
    private Animator Door;
    private Transform FirstRot;
    void Start()
    {
        Door = this.gameObject.GetComponent<Animator>();
    }
    public void ResetDoorRot()
    {
        Door.Play("DoorChase2Close");
    }
}
