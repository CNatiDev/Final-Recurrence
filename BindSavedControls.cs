using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class BindSavedControls : MonoBehaviour
{
    private PlayerInputActions m_Action; // Reference to an action to rebind.
    public Text WText;
    public Text SText;
    public Text AText;
    public Text DText;
    private void Awake()
    {
        //Movement input actions
        m_Action = Fps_Script.instance.playerInputActions;
        UpdateDisplayText();
    }
    private void Start()
    {
        m_Action = Fps_Script.instance.playerInputActions;
        UpdateDisplayText();
    }
    private void UpdateDisplayText()
    {
        //If we already changed our settings we will load and change them along with thei corresponding text
        WText.text = m_Action.Player.Movement.GetBindingDisplayString(1);
        if (PlayerPrefs.HasKey("WKey"))
            WText.text = PlayerPrefs.GetString("WKey");
        AText.text = m_Action.Player.Movement.GetBindingDisplayString(3);
        if (PlayerPrefs.HasKey("AKey"))
            AText.text = PlayerPrefs.GetString("AKey");
        SText.text = m_Action.Player.Movement.GetBindingDisplayString(2);
        if (PlayerPrefs.HasKey("SKey"))
            SText.text = PlayerPrefs.GetString("SKey");
        DText.text = m_Action.Player.Movement.GetBindingDisplayString(4);
        if (PlayerPrefs.HasKey("DKey"))
            DText.text = PlayerPrefs.GetString("DKey");
    }
}
