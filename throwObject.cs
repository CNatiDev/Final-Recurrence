using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwObject : MonoBehaviour
{
    public Rigidbody rb;
    public int power;
    public void pushObject()
    {
        rb.AddForce(-transform.forward * (Time.deltaTime + power));
    }
}
