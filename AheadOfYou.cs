using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AheadOfYou : MonoBehaviour
{
    public Transform other;
    public UnityEvent @event;
    //Object to be invisible when you turn
    public GameObject toBeInvisible;
    //Check if object is invisible
    [SerializeField] bool isInvisible = false, played = false;

    void Update()
    {
        //If the player is assigned in inspector
        if (other)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 toOther = other.position - transform.position;
            //The dot product is a float value equal to the magnitudes of the two vectors multiplied together and then multiplied
            //by the cosine of the angle between them.
            //If the Vector3.Dot value is less than 0 it means that object is behind the player
            //Otherwise the object is in front of the player
            if (Vector3.Dot(forward, toOther) < 0)
            {
                if (isInvisible == false)
                {
                    isInvisible = true;
                }
            }
            else
            {
                if (isInvisible == true && played == false)
                {
                    other.gameObject.SetActive(true);
                    if(toBeInvisible != null)
                    toBeInvisible.SetActive(false);
                    @event.Invoke();
                    played = true;
                }
            }
        }
    }
}
