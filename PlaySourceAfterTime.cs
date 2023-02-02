using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySourceAfterTime : MonoBehaviour
{
    public AudioSource audioSource;
    public float minimumRepeat, maximumRepeat;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Play", 2f, audioSource.clip.length * Random.Range(minimumRepeat, maximumRepeat));
    }
    public void Play()
    {
        audioSource.Play();
    }
}
