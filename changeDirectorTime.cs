using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class changeDirectorTime : MonoBehaviour
{
    public PlayableDirector director;
    public void ChangeTime(float time)
    {
        director.time = time;
    }
}
