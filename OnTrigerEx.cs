using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class OnTrigerEx : MonoBehaviour
{
    public UnityEvent @event;
    private void OnTriggerExit(Collider other)
    {
        @event.Invoke();
    }
}
