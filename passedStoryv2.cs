using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class passedStoryv2 : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public float time;
    private void Awake()
    {
        AudioListener.volume = 1f;
    }
    public void Start()
    {
        if (SaveManager.instance)
        {
            if(SaveManager.instance.activeSave.passedStory)
                playableDirector.time = time;
        }
    }

}
