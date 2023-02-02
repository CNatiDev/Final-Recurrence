using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Footsteps;
public class disableFootstepsSounds : MonoBehaviour
{
    public void disableFootsteps()
    {
        GetComponent<CharacterFootsteps>().enabled = false;
    }
    public void enableFootsteps()
    {
        GetComponent<CharacterFootsteps>().enabled = true;
    }
    public void changeFootstepDistance(int distance)
    {
        GetComponent<CharacterFootsteps>().distanceBetweenSteps = distance;
    }
}
