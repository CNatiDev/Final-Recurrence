using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableFog : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            RenderSettings.fog = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            RenderSettings.fog = true;
    }
    public void DisableFogFunction()
    {
        RenderSettings.fog = false;

    }
    public void EnableFogFunction()
    {
        RenderSettings.fog = true;

    }
}

