using UnityEngine;
using System.Collections.Generic;

// Written by Steve Streeting 2017
// License: CC0 Public Domain http://creativecommons.org/publicdomain/zero/1.0/

/// <summary>
/// Component which will flicker a linked light while active by changing its
/// intensity between the min and max values given. The flickering can be
/// sharp or smoothed depending on the value of the smoothing parameter.
///
/// Just activate / deactivate this component as usual to pause / resume flicker
/// </summary>
public class LightFlickerEffect : MonoBehaviour
{
    [Tooltip("External light to flicker; you can leave this null if you attach script to a light")]
    public new Light light;
    [Tooltip("Minimum random light intensity")]
    public float minIntensity = 0f;
    [Tooltip("Maximum random light intensity")]
    public float maxIntensity = 1f;
    [Tooltip("How much to smooth out the randomness; lower values = sparks, higher = lantern")]
    [Range(1, 50)]
    public float smoothing = 5;
    public GameObject lightMaterial;
    // Continuous average calculation via FIFO queue
    // Saves us iterating every time we update, we just change by the delta
    Queue<float> smoothQueue;
    float lastSum = 0;
    Color colour;

    /// <summary>
    /// Reset the randomness and start again. You usually don't need to call
    /// this, deactivating/reactivating is usually fine but if you want a strict
    /// restart you can do.
    /// </summary>
    public void Reset()
    {
        smoothQueue.Clear();
        lastSum = 0;
    }

    void Start()
    {
        smoothQueue = new Queue<float>((int)smoothing);
        // External or internal light?
        if (light == null)
        {
            light = GetComponent<Light>();
        }
        if(lightMaterial != null)
        {
        lightMaterial.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        colour = new Color32(255, 255, 255, 255);
        }

    }

    void Update()
    {
        if (light == null)
            return;

        float newVal = Random.Range(minIntensity, maxIntensity);
        // pop off an item if too big
        while (smoothQueue.Count >= smoothing)
        {
            lastSum -= smoothQueue.Dequeue();
            if (lightMaterial != null)
            {
                lightMaterial.GetComponent<Renderer>().material.SetColor("_EmissionColor", colour * (lastSum / (float)smoothQueue.Count));
            }
        }
        smoothQueue.Enqueue(newVal);
        lastSum += newVal;
        // Generate random new item, calculate new average
        /*        float newVal = Random.Range(minIntensity, maxIntensity);
                if (lightMaterial != null)
                {
                    lightMaterial.GetComponent<Renderer>().material.SetColor("_EmissionColor", colour * newVal);
                }

                smoothQueue.Enqueue(newVal);
                lastSum += newVal;*/

        // Calculate new smoothed average
        light.intensity = lastSum / (float)smoothQueue.Count;
    }

}