using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SwitchOnLight4 : MonoBehaviour
{
    public UnityEvent @OnEvent, @OffEvent;
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
            @OnEvent.Invoke();
            light2.SetActive(true);
            if (chandelier)
                chandelier.GetComponent<MeshRenderer>().material = materialOn;
            on = true;
            switch2.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
            onSound.Play();
        }
        else
        {
            @OffEvent.Invoke();
            light2.SetActive(false);
            if (chandelier)
                chandelier.GetComponent<MeshRenderer>().material = materialOff;
            on = false;
            switch2.transform.rotation = Quaternion.Euler(new Vector3(-65f, 0f, 0f));
            offSound.Play();
        }
    }
}
