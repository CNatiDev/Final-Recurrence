using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class checkFlashlight : MonoBehaviour
{
    public TextMeshProUGUI textBox;
    public PlayableDirector playableDirector;
    bool hasntPlayed = false;
    public void check()
    {
        //If the player picked the flashlight and the note, a subtitle text will be play which directs the player to leave the
        //house and prepare for the next level
        if (SaveManager.instance.activeSave.hasFlashlight && SaveManager.instance.activeSave.note1 && hasntPlayed == false)
        {
            playableDirector.Play();
            hasntPlayed = true;
        }
    }
    private void Update()
    {
        //De-activate the subtitle from settings menu
        if (SettingsMenu.instance.subDec == true)
        {
            textBox.enabled = true;
            return;
        }
        if (SettingsMenu.instance.subDec == false)
        {
            textBox.enabled = false;
            return;
        }
    }

    void Start()
    {
        if (SettingsMenu.instance.subDec == true)
            textBox.enabled = true;
        else
            textBox.enabled = false;
    }
}
