using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGrade : MonoBehaviour
{
    public void RotateObject(float grade)
    {
        transform.Rotate(transform.rotation.x, grade, transform.rotation.z);
    }
    public void RotateObjectTo0DegreesYAxis()
    {
        this.transform.Rotate(new Vector3(0f, 1f, 0f), -this.transform.localEulerAngles.y, Space.Self);
    }
}
