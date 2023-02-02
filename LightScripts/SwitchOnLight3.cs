using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOnLight3 : MonoBehaviour
{
    public GameObject light2;
    public GameObject switch2;
    public GameObject chandelier;
    public Material materialOn, materialOff;
    //default pos x = -65
    private bool on = false;
    public AudioSource onSound;
    public AudioSource offSound;
    public void SwitchLight()
    {
        if (on == false)
        {
            light2.SetActive(true);
            if (chandelier)
                chandelier.GetComponent<MeshRenderer>().material = materialOn;
            on = true;
            switch2.transform.rotation = Quaternion.Euler(new Vector3(0f, -180f, 0f));
            onSound.Play();
        }
        else
        {
            light2.SetActive(false);
            if (chandelier)
                chandelier.GetComponent<MeshRenderer>().material = materialOff;
            on = false;
            switch2.transform.rotation = Quaternion.Euler(new Vector3(-65f, -180f, 0f));
            offSound.Play();
        }
    }
}
