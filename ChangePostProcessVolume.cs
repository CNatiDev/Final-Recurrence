using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Events;
public class ChangePostProcessVolume : MonoBehaviour
{
    public PostProcessVolume newVolume, oldVolume;
    public float duration, newVal;
    private bool canTrigger = false;
    private ChromaticAberration chromaticAberration1;
    public UnityEvent @event_before;
    public UnityEvent @event_after;
    private void Awake()
    {
        chromaticAberration1 = newVolume.profile.GetSetting<ChromaticAberration>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canTrigger = true;
            StartCoroutine(goTo1());
        }
    }
    private void Update()
    {
        if (canTrigger)
        {
            //Lateral effect for flashback
            newVal = Random.Range(0.1f, 1);
            chromaticAberration1.intensity.value = newVal;
        }
    }
    public void finishedFlashback()
    {
        StartCoroutine(comeTo1());
    }
    public IEnumerator goTo1()
    {
        //Change towards the new post processing settings for the flashback
        //Make the new volume global and activate it over time
        newVolume.isGlobal = true;
        float time = 0;
        while (time < duration)
        {
            newVolume.weight = Mathf.Lerp(0, 1, time / 2);
            time += Time.deltaTime;
            @event_before.Invoke();
            yield return null;
        }
    }
    public IEnumerator comeTo1()
    {
        //Change towards the old post processing settings for the flashback
        float time = 0;
        while (time < duration)
        {
            newVolume.weight = Mathf.Lerp(1, 0, time / duration);
            time += Time.deltaTime;
            @event_after.Invoke();
            yield return null;
        }
        //Make the new volume local and de-activate it
        newVolume.weight = 0;
        newVolume.isGlobal = false;
        this.gameObject.SetActive(false);
    }
    public void FlashBack()
    {
        canTrigger = true;
        StartCoroutine(goTo1());
    }
}
