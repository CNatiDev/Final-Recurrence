using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Objective7 : MonoBehaviour
{
    bool hasPlayed = false;
    public string text;
    public Text objectiveText;
    public Text currentObjectiveText;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public GameObject objectiveCanvas;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void startObjective()
    {
        hasPlayed = true;
        objectiveText.text = text;
        currentObjectiveText.text = text;
        StartCoroutine(disable());
        SaveManager.instance.activeSave.currentObjective = text;
        SaveManager.instance.activeSave.objective7 = true;
    }
    IEnumerator disable()
    {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.Play();
        objectiveCanvas.SetActive(true);
        yield return new WaitForSeconds(4.5f);
        objectiveCanvas.SetActive(false);
        yield return null;
    }
}
