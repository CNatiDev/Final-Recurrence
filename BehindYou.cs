using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BehindYou : MonoBehaviour
{
    public Transform other;
    //Object to be invisible when you turn
    public GameObject toBeVisible;
    //In case a script should get disabled after you turn
    public AheadOfYou ndScript;
    public bool isInvisible = false, played = false;
    public UnityEvent @event;
    void Update()
    {
        if (other)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 toOther = other.position - transform.position;

            if (Vector3.Dot(forward, toOther) < 0)
            {
                if (isInvisible == true && played == false)
                {
                    other.gameObject.SetActive(false);
                    toBeVisible.gameObject.SetActive(true);
                    ndScript.enabled = true;
                    @event.Invoke();
                    played = true;
                }
            }
            else
            {
                if(isInvisible == false)
                {
                    isInvisible = true;
                }
            }
        }
    }
}
