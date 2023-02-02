using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class checkClockTime : MonoBehaviour
{
    public UnityEvent @event;
    private int[] correctCode = { 12 , 12 };
    public void CheckTime()
    {
        //Check if the current clock hands are the same as the correct times'
        if (ClockRotate.instance.time == correctCode[0] && ClockRotate1.instance.time == correctCode[1])
        {
            Debug.Log("Corect");
            @event.Invoke();
        }
    }
}
