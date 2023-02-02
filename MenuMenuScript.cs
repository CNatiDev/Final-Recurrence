using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class MenuMenuScript : MonoBehaviour
{
	Transform menuPanel;
	Event keyEvent;
	Text buttonText;
	KeyCode newKey;

	bool waitingForKey;

    void Start ()
	{
		//Assign menuPanel to the Panel object in our Canvas
		//Make sure it's not active when the game starts
		menuPanel = transform.Find("Panel");
		waitingForKey = false;

		/*iterate through each child of the panel and check
		 * the names of each one. Each if statement will
		 * set each button's text component to display
		 * the name of the key that is associated
		 * with each command. Example: the ForwardKey
		 * button will display "W" in the middle of it
		 */
		for(int i = 0; i < menuPanel.childCount; i++)
		{
			if(menuPanel.GetChild(i).name == "ForwardKey")
				menuPanel.GetChild(i).GetComponentInChildren<Text>().text = PlayerPrefs.GetString("WKey", "W");
			else if(menuPanel.GetChild(i).name == "BackwardKey")
				menuPanel.GetChild(i).GetComponentInChildren<Text>().text = PlayerPrefs.GetString("SKey", "S");
			else if(menuPanel.GetChild(i).name == "LeftKey")
				menuPanel.GetChild(i).GetComponentInChildren<Text>().text = PlayerPrefs.GetString("AKey", "A");
			else if(menuPanel.GetChild(i).name == "RightKey")
				menuPanel.GetChild(i).GetComponentInChildren<Text>().text = PlayerPrefs.GetString("DKey", "D");
			else if(menuPanel.GetChild(i).name == "JumpKey")
				menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.instance.jump.ToString();
			else if (menuPanel.GetChild(i).name == "CrouchKey")
				menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.instance.crouch.ToString();
			else if (menuPanel.GetChild(i).name == "ShiftKey")
				menuPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.instance.shift.ToString();
		}
	}
	void OnGUI()
	{
		/*keyEvent dictates what key our user presses
		 * bt using Event.current to detect the current
		 * event
		 */
		keyEvent = Event.current;

		//Executes if a button gets pressed and
		//the user presses a key
		if(keyEvent.isKey && waitingForKey)
		{
			newKey = keyEvent.keyCode; //Assigns newKey to the key user presses
			waitingForKey = false;
		}
	}

	/*Buttons cannot call on Coroutines via OnClick().
	 * Instead, we have it call StartAssignment, which will
	 * call a coroutine in this script instead, only if we
	 * are not already waiting for a key to be pressed.
	 */
	public void StartAssignment(string keyName)
	{
		if(!waitingForKey)
			StartCoroutine(AssignKey(keyName));
		buttonText.text = "Press any key";
	}
	//Assigns buttonText to the text component of
	//the button that was pressed
	public void SendText(Text text)
	{
		buttonText = text;
	}

	//Used for controlling the flow of our below Coroutine
	IEnumerator WaitForKey()
	{
		while(!keyEvent.isKey)
			yield return null;
	}

	/*AssignKey takes a keyName as a parameter. The
	 * keyName is checked in a switch statement. Each
	 * case assigns the command that keyName represents
	 * to the new key that the user presses, which is grabbed
	 * in the OnGUI() function, above.
	 */
	public IEnumerator AssignKey(string keyName)
	{
		waitingForKey = true;

		yield return WaitForKey(); //Executes endlessly until user presses a key

		switch(keyName)
		{
		case "forward":
				GameManager.instance.forward = newKey; //Set forward to new keycode
			buttonText.text = GameManager.instance.forward.ToString(); //Set button text to new key
			PlayerPrefs.SetString("forwardKey", GameManager.instance.forward.ToString()); //save new key to PlayerPrefs
			break;
		case "backward":
				GameManager.instance.backward = newKey; //set backward to new keycode
			buttonText.text = GameManager.instance.backward.ToString(); //set button text to new key
			PlayerPrefs.SetString("backwardKey", GameManager.instance.backward.ToString()); //save new key to PlayerPrefs
			break;
		case "left":
				GameManager.instance.left = newKey; //set left to new keycode
			buttonText.text = GameManager.instance.left.ToString(); //set button text to new key
			PlayerPrefs.SetString("leftKey", GameManager.instance.left.ToString()); //save new key to playerprefs
			break;
		case "right":
				GameManager.instance.right = newKey; //set right to new keycode
			buttonText.text = GameManager.instance.right.ToString(); //set button text to new key
			PlayerPrefs.SetString("rightKey", GameManager.instance.right.ToString()); //save new key to playerprefs
			break;
		case "jump":
				GameManager.instance.jump = newKey; //set jump to new keycode
			buttonText.text = GameManager.instance.jump.ToString(); //set button text to new key
			PlayerPrefs.SetString("jumpKey", GameManager.instance.jump.ToString()); //save new key to playerprefs
			break;
		case "crouch":
				GameManager.instance.crouch = newKey; //set jump to new keycode
				buttonText.text = GameManager.instance.crouch.ToString(); //set button text to new key
				PlayerPrefs.SetString("crouchKey", GameManager.instance.crouch.ToString()); //save new key to playerprefs
				break;
		case "shift":
				GameManager.instance.shift = newKey; //set jump to new keycode
				buttonText.text = GameManager.instance.shift.ToString(); //set button text to new key
				PlayerPrefs.SetString("shiftKey", GameManager.instance.shift.ToString()); //save new key to playerprefs
				break;
		}

		yield return null;
	}
}
