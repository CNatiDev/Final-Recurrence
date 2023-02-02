using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class RebindButtonMainMenu : MonoBehaviour
{
    //Action number in input action map
    public string BindingIndex;
    public Text text;
    bool waitingForKey;
    KeyCode newKey;
    Event keyEvent;
    private void Awake()
    {
        waitingForKey = false;
        switch (BindingIndex.ToUpper())
        {
            case "W":
                text.text = PlayerPrefs.GetString("WKey", "W");
                break;
            case "A":
                text.text = PlayerPrefs.GetString("AKey", "A");
                break;
            case "S":
                text.text = PlayerPrefs.GetString("SKey", "S");
                break;
            case "D":
                text.text = PlayerPrefs.GetString("DKey", "D");
                break;
        }

    }
    void OnGUI()
    {
        /*keyEvent dictates what key our user presses
		 * bt using Event.current to detect the current
		 * event
		 */
        keyEvent = Event.current;

        //Executes if a button gets pressed and the user presses a key
        if (keyEvent.isKey && waitingForKey)
        {
            newKey = keyEvent.keyCode; //Assigns newKey to the key user presses
            waitingForKey = false;
        }
    }
    public void FunctionW()
    {
        if (!waitingForKey)
            StartCoroutine(AssignKey(1));
        text.text = "Press any key";
    }
    public void FunctionA()
    {
        if (!waitingForKey)
            StartCoroutine(AssignKey(2));
        text.text = "Press any key";
    }
    public void FunctionS()
    {
        if (!waitingForKey)
            StartCoroutine(AssignKey(3));
        text.text = "Press any key";
    }
    public void FunctionD()
    {
        if (!waitingForKey)
            StartCoroutine(AssignKey(4));
        text.text = "Press any key";
    }
    public IEnumerator AssignKey(int i)
    {
        waitingForKey = true;

        yield return WaitForKey(i); //Executes endlessly until user presses a key
        
        yield return null;
    }
    IEnumerator WaitForKey(int i)
    {
        while (!keyEvent.isKey)
            yield return null;
        text.text = newKey.ToString();
        switch(i)
        {
            case 1:
                PlayerPrefs.SetString("WKey", newKey.ToString()); //Save the pressed key to W/A/S/D
                PlayerPrefs.Save();
                break;
            case 2:
                PlayerPrefs.SetString("AKey", newKey.ToString());
                PlayerPrefs.Save();
                break;
            case 3:
                PlayerPrefs.SetString("SKey", newKey.ToString());
                PlayerPrefs.Save();
                break;
            case 4:
                PlayerPrefs.SetString("DKey", newKey.ToString());
                PlayerPrefs.Save();
                break;
        }
    }
}
