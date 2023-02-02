using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayAudioJumpScare : MonoBehaviour
{
    public UnityEvent @instantEvent;
    public AudioSource Audio;
    public AudioSource Audio1;
    public bool disable = false;
    public float TimeToDisable = 3;
    public float TimeToPlay;
    public bool shouldPlayOnce = false;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (shouldPlayOnce)
            {
                callOnce();
                return;
            }
            instantEvent.Invoke();
            Invoke("Enable", TimeToPlay);
            Invoke("Disable", TimeToDisable);
        }
    }
    public void callOnce()
    {
        instantEvent.Invoke();
        Invoke("Enable", TimeToPlay);
        Invoke("Disable", TimeToDisable);
        this.enabled = false;
    }
    public void PlayAudio()
    {
        Audio.Play();
        if (Audio1 != null)
            Audio1.Play();
        Invoke("Disable", TimeToDisable);
    }
    public void Enable()
    {
        Audio.Play();
        if (Audio1 != null)
            Audio1.Play();
    }    
    public void Disable()
    {
        if (disable == true)
        {
            this.gameObject.SetActive(false);
        }
    }
}
