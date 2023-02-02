using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class RebindButton : MonoBehaviour
{
    public PlayerInputActions m_Action; // Reference to an action to rebind.
    public int m_BindingIndex; // Index into m_Action.bindings for binding to rebind.
    public Text text;
    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;
    private void Awake()
    {
        //If there is a player (this won't work in levels where the script isn't present), get the movement input actions
        //and enable them
        if(Fps_Script.instance != null)
        m_Action = Fps_Script.instance.playerInputActions;
        m_Action.Player.Movement.Enable();
    }
    //These functions are used on an on click event on buttons, once clicked the button's text will change to "..."
    //and whatever key the player presses next will be saved and rebinded for the current action inside the player movement
    //input action map
    //If they press ESC the action will be canceled and the button won't be rebinded
    //The same happens if they press a key that is already binded to a different action.
    public void FunctionW()
    {
        m_Action.Player.Movement.Disable();
        text.text = "...";
        rebindingOperation = m_Action.Player.Movement.PerformInteractiveRebinding()
                    .WithTargetBinding(m_BindingIndex)
                    .WithCancelingThrough("<Keyboard>/escape")
                    .OnCancel(operation =>
                    {
                        m_Action.Player.Movement.Enable();
                        rebindingOperation.Dispose();
                        UpdateDisplayText(text, m_BindingIndex);
                    })
                    .OnComplete(operation =>
                    {
                        rebindingOperation.Dispose();
                        if (CheckDuplicateBindingsW(m_Action.Player.Movement, m_BindingIndex) == false)
                        {
                            PlayerPrefs.SetString("WKey", m_Action.Player.Movement.controls[m_BindingIndex - 1].name.ToUpper());
                            PlayerPrefs.Save();
                            UpdateDisplayText(text, m_BindingIndex);
                        }
                        else
                        {
                            m_Action.Player.Movement.RemoveBindingOverride(m_BindingIndex);
                            UpdateDisplayText(text, m_BindingIndex);
                        }
                    })
                    .Start();
        m_Action.Player.Movement.Enable();
    }
    public void FunctionA()
    {
        m_Action.Player.Movement.Disable();
        text.text = "...";
        rebindingOperation = m_Action.Player.Movement.PerformInteractiveRebinding()
                    .WithTargetBinding(m_BindingIndex)
                    .WithCancelingThrough("<Keyboard>/escape")
                    .OnCancel(operation =>
                    {
                        m_Action.Player.Movement.Enable();
                        UpdateDisplayText(text, m_BindingIndex);
                    })
                    .OnComplete(operation =>
                    {
                        rebindingOperation.Dispose();
                        if (CheckDuplicateBindingsA(m_Action.Player.Movement, m_BindingIndex) == false)
                        {
                            PlayerPrefs.SetString("AKey", m_Action.Player.Movement.controls[m_BindingIndex - 1].name.ToUpper());
                            PlayerPrefs.Save();
                            UpdateDisplayText(text, m_BindingIndex);
                        }
                        else
                        {
                            m_Action.Player.Movement.RemoveBindingOverride(m_BindingIndex);
                            UpdateDisplayText(text, m_BindingIndex);
                        }
                    })
                    .Start();
        m_Action.Player.Movement.Enable();
    }
    public void FunctionS()
    {
        m_Action.Player.Movement.Disable();
        text.text = "...";
        rebindingOperation = m_Action.Player.Movement.PerformInteractiveRebinding()
                    .WithTargetBinding(m_BindingIndex)
                    .WithCancelingThrough("<Keyboard>/escape")
                    .OnCancel(operation =>
                    {
                        m_Action.Player.Movement.Enable();
                        UpdateDisplayText(text, m_BindingIndex);
                    })
                    .OnComplete(operation =>
                    {
                        rebindingOperation.Dispose();
                        if (CheckDuplicateBindingsS(m_Action.Player.Movement, m_BindingIndex) == false)
                        {
                            PlayerPrefs.SetString("SKey", m_Action.Player.Movement.controls[m_BindingIndex - 1].name.ToUpper());
                            PlayerPrefs.Save();
                            UpdateDisplayText(text, m_BindingIndex);
                        }
                        else
                        {
                            m_Action.Player.Movement.RemoveBindingOverride(m_BindingIndex);
                            UpdateDisplayText(text, m_BindingIndex);
                        }
                    })
                    .Start();
        m_Action.Player.Movement.Enable();
    }
    public void FunctionD()
    {
        m_Action.Player.Movement.Disable();
        text.text = "...";
        rebindingOperation = m_Action.Player.Movement.PerformInteractiveRebinding()
                    .WithTargetBinding(m_BindingIndex)
                    .WithCancelingThrough("<Keyboard>/escape")
                    .OnCancel(operation =>
                    {
                        m_Action.Player.Movement.Enable();
                        UpdateDisplayText(text, m_BindingIndex);
                    })
                    .OnComplete(operation =>
                    {
                        rebindingOperation.Dispose();
                        if (CheckDuplicateBindingsD(m_Action.Player.Movement, m_BindingIndex) == false)
                        {
                            PlayerPrefs.SetString("DKey", m_Action.Player.Movement.controls[m_BindingIndex - 1].name.ToUpper());
                            PlayerPrefs.Save();
                            UpdateDisplayText(text, m_BindingIndex);
                        }
                        else
                        {
                            m_Action.Player.Movement.RemoveBindingOverride(m_BindingIndex);
                            UpdateDisplayText(text, m_BindingIndex);
                        }
                    })
                    .Start();
        m_Action.Player.Movement.Enable();
    }
    private void UpdateDisplayText(Text text, int BindingIndex)
    {
        text.text = m_Action.Player.Movement.GetBindingDisplayString(BindingIndex);
    }
    private bool CheckDuplicateBindingsW(InputAction action, int m_BindingIndex)
    {
        InputBinding newBinding = action.bindings[m_BindingIndex];
        for (int i=2; i <= 4; ++i)
        {
            if (action.bindings[i].effectivePath.ToLower() == newBinding.effectivePath.ToLower())
            {
                return true;
            }
        }
        return false;
    }
    private bool CheckDuplicateBindingsS(InputAction action, int m_BindingIndex)
    {
        InputBinding newBinding = action.bindings[m_BindingIndex];
        for (int i = 3; i <= 4; ++i)
        {
            if (action.bindings[i].effectivePath.ToLower() == newBinding.effectivePath.ToLower() ||
                action.bindings[1].effectivePath.ToLower() == newBinding.effectivePath.ToLower())
            {
                return true;
            }
        }
        return false;
    }
    private bool CheckDuplicateBindingsA(InputAction action, int m_BindingIndex)
    {
        InputBinding newBinding = action.bindings[m_BindingIndex];
        for (int i = 1; i <= 2; ++i)
        {
            if (action.bindings[i].effectivePath.ToLower() == newBinding.effectivePath.ToLower() ||
                action.bindings[4].effectivePath.ToLower() == newBinding.effectivePath.ToLower())
            {
                return true;
            }
        }
        return false;
    }
    private bool CheckDuplicateBindingsD(InputAction action, int m_BindingIndex)
    {
        InputBinding newBinding = action.bindings[m_BindingIndex];
        for (int i = 1; i <= 3; ++i)
        {
            if (action.bindings[i].effectivePath.ToLower() == newBinding.effectivePath.ToLower())
            {
                return true;
            }
        }
        return false;
    }
}