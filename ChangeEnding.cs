using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ChangeEnding : MonoBehaviour
{
    public int GoodEnding;
    public int BadEnding;
    public UnityEvent GoodEndingEvents;
    public UnityEvent BadEndingEvents;
    public void GoodEndingIncrease()
    {
        GoodEnding++;
        SaveManager.instance.activeSave.goodEndings++;
        BadEnding = 5 - GoodEnding;
    }
    public void tookseaShell()
    {
        GoodEnding++;
        SaveManager.instance.activeSave.goodEndings++;
        SaveManager.instance.activeSave.tookSeaShell = true;
        BadEnding = 5 - GoodEnding;
    }
    public void CheckEndingStatus()
    {
        GoodEnding = SaveManager.instance.activeSave.goodEndings; //Or SaveManager
        if (GoodEnding > BadEnding)
        {
            GoodEndingEvents.Invoke();
        }
        else
        {
            BadEndingEvents.Invoke();
        }
    }
}
