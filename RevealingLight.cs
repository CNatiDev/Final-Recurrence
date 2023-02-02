using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealingLight : MonoBehaviour
{
    public Transform tfLight;
    // Start is called before the first frame update
    void Start()
    {
        //This is the flashlight's first light
        var goLight = GameObject.Find("Spotlight1");
        if (goLight) tfLight = goLight.transform;
    }

    void Update()
    {
        //If a light was found and the flashlight is enabled, get the object's renderer material and make it visible
        //as the flashlight's light is moving
        if (tfLight && Flashlight_PRO.instance.is_enabled)
        {
            GetComponent<Renderer>().material.SetVector("_LightPos", tfLight.position);
            GetComponent<Renderer>().material.SetVector("_LightDir", tfLight.forward);
        }
        else
        {
            GetComponent<Renderer>().material.SetVector("_LightPos", Vector3.zero);
            GetComponent<Renderer>().material.SetVector("_LightDir", Vector3.zero);
        }
    }
}
