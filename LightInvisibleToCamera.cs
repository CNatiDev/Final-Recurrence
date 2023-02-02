using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightInvisibleToCamera : MonoBehaviour
{
    public Light limelight;
    void OnPreCull()
    {
        if (limelight != null)
            limelight.enabled = false;
    }
    void OnPostRender()
    {
        limelight.enabled = true;
    }
}
