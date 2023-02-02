using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Objective9 : MonoBehaviour
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
    private void OnTriggerEnter(Collider other)
    {
        if (SaveManager.instance.hasLoaded)
        {
            if (SaveManager.instance.activeSave.objective9 == false)
            {
                if (other.gameObject.tag == "Player" && hasPlayed == false)
                {
                    hasPlayed = true;
                    objectiveText.text = text;
                    currentObjectiveText.text = text;
                    StartCoroutine(disable());
                    SaveManager.instance.activeSave.currentObjective = text;
                    SaveManager.instance.activeSave.objective9 = true;
                    //SaveManager.instance.Save();
                }
            }
        }

    }
    IEnumerator disable()
    {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.Play();
        objectiveCanvas.SetActive(true);
        yield return new WaitForSeconds(4.5f);
        objectiveCanvas.SetActive(false);
        Destroy(this.gameObject);
        yield return null;
    }
}
