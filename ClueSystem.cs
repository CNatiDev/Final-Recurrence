using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ClueSystem : MonoBehaviour
{
    public GameObject[] ClueMesh;
    public bool hasAll = false;
    public UnityEvent hasALL_Event;
    public UnityEvent @event;
    public bool canAudio;
    private void Start()
    {
        for (int i = 0; i < ClueMesh.Length; i++)
        {
            if (SaveManager.instance.activeSave.clue[i] == true)
            {
                ClueMesh[i].SetActive(true);
            }
            else
            {
                hasAll = false;
                ClueMesh[i].SetActive(false);
            }
        }
    }
    public void SetClueStatus(int i)
    {
        SaveManager.instance.activeSave.clue[i] = true;
        ClueMesh[i].SetActive(true);
        for (int j = 0; j < ClueMesh.Length; j++)
        {
            if (SaveManager.instance.activeSave.clue[j] == false)
                hasAll = false;
        }
    }
    public void HasAll()
    {
        bool ok = true;
        for (int i = 0; i < ClueMesh.Length; i++)
        {

            if (SaveManager.instance.activeSave.clue[i] == false)
            {
                ok = false;
            }
        }
        if (ok == true)
        {
            hasAll = true;
            hasALL_Event.Invoke();
        }
    }
    public void SetCanAudio(bool status)
    {
        canAudio = status;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && canAudio)
        {
            @event.Invoke();
        }
    }
}
