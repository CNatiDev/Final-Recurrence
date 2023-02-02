using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class RobinetScrip : MonoBehaviour
{
    private bool FRot = false;
    public UnityEvent @event;
    public UnityEvent @event1;
    public void RoatateRob(bool TF)
    {
        FRot = TF;

    }
    public void CheckRob()
    {
        if (FRot == true)
        {
            @event.Invoke();
            FRot = false;
        }
        else
        {
            event1.Invoke();
            FRot = true;
        }
    }
}
