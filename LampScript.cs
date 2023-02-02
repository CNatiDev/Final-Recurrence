using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampScript : MonoBehaviour
{
    public Light light;
    bool turnedOn = false;
    public AudioSource offSound;
    public AudioSource onSound;
    void Start()
    {
        if(light == null)
            light = GetComponent<Light>();

    }
    public void ActivateLight()
    {
        if(turnedOn == false)
        {
            onSound.Play();
            light.enabled = true;
            turnedOn = true;
        }
        else
        {
            offSound.Play();
            light.enabled = false;
            turnedOn = false;
        }
    }
}
