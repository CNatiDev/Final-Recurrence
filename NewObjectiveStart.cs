using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class NewObjectiveStart : MonoBehaviour
{
    private bool hasPlayed = false;
    public string On;
    public string text, textFR, textDE, textIT, textPL, textPT, textRO, textES, textTR;
    public Animator animator;
    public Text objectiveText;
    public Text currentObjectiveText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !hasPlayed)
        {
            switch (LocalizationSettings.SelectedLocale.Formatter.ToString())
            {
                case "en":
                    objectiveText.text = text;
                    currentObjectiveText.text = text;
                    break;
                case "fr":
                    objectiveText.text = textFR;
                    currentObjectiveText.text = textFR;
                    break;
                case "de":
                    objectiveText.text = textDE;
                    currentObjectiveText.text = textDE;
                    break;
                case "it":
                    objectiveText.text = textIT;
                    currentObjectiveText.text = textIT;
                    break;
                case "pl":
                    objectiveText.text = textPL;
                    currentObjectiveText.text = textPL;
                    break;
                case "pt":
                    objectiveText.text = textPT;
                    currentObjectiveText.text = textPT;
                    break;
                case "ro":
                    objectiveText.text = textRO;
                    currentObjectiveText.text = textRO;
                    break;
                case "es":
                    objectiveText.text = textES;
                    currentObjectiveText.text = textES;
                    break;
                case "tr-TR":
                    objectiveText.text = textTR;
                    currentObjectiveText.text = textTR;
                    break;
            }
/*            objectiveText.text = text;
            currentObjectiveText.text = text;*/
            animator.Play(On);
            hasPlayed = true;
        }
    }
}
