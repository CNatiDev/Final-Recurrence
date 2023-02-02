using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDis : MonoBehaviour
{

    private void OnDisable()
    {
        Debug.LogError("OnDisable: " + gameObject.name, gameObject);
    }

    private void OnEnable()
    {
        Debug.LogError("OnEnable: " + gameObject.name, gameObject);
    }
}
