using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class KindaInventorySystem : MonoBehaviour
{
    public static KindaInventorySystem instance;
    public UnityEvent closeEvent, openEvent;
    [SerializeField] GameObject[] clues;
    [SerializeField] int currentClue = 0;
    [SerializeField] Vector3 currentCluePos, nextCluePos;
    [SerializeField] public bool isOpened = false, canGoNext = true, canOpen = true;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.JoystickButton4)) && canOpen == true)
        {
            if(PauseMenu.instance.IsGamePaused == false && isOpened == true && canOpen == true)
                closeEvent.Invoke();
            else if(PauseMenu.instance.IsGamePaused == false && isOpened == false && canOpen == true)
                openEvent.Invoke();
        }
/*        if (Input.GetKeyDown(KeyCode.A) && isOpened == true && currentClue - 1 >= 0)
        {
            if (canGoNext == true)
            {
                currentCluePos = clues[currentClue].transform.localPosition;
                currentCluePos.x -= 1.55f;
               // clues[currentClue].transform.position = currentCluePos;
                nextCluePos = clues[currentClue - 1].transform.localPosition;
                nextCluePos.x -= 1.55f;
                StartCoroutine(goLeft());
            }

            //clues[currentClue - 1].transform.position = nextCluePos;
            //currentClue--;
        }
        if (Input.GetKeyDown(KeyCode.D) && isOpened == true && currentClue + 1 < clues.Length)
        {
            if (canGoNext == true)
            {
                currentCluePos = clues[currentClue].transform.localPosition;
                currentCluePos.x += 1.55f;
                //clues[currentClue].transform.position = currentCluePos;
                nextCluePos = clues[currentClue + 1].transform.localPosition;
                nextCluePos.x += 1.55f;
                StartCoroutine(goRight());
            }
            //clues[currentClue + 1].transform.position = nextCluePos;
        }*/
    }
/*    IEnumerator goRight()
    {
        canGoNext = false;
        float timeElapsed = 0;
        while (timeElapsed <= .4f)
        {
            clues[currentClue].transform.localPosition = Vector3.Lerp(clues[currentClue].transform.localPosition, currentCluePos, timeElapsed);
            clues[currentClue + 1].transform.localPosition = Vector3.Lerp(clues[currentClue + 1].transform.localPosition, nextCluePos, timeElapsed);
            timeElapsed += Time.fixedDeltaTime;
            yield return null;
        }
        clues[currentClue].transform.localPosition = currentCluePos;
        clues[currentClue + 1].transform.localPosition = nextCluePos;
        currentClue++;
        canGoNext = true;
    }
    IEnumerator goLeft()
    {
        canGoNext = false;
        float timeElapsed = 0;
        while (timeElapsed <= .4f)
        {
            clues[currentClue].transform.localPosition = Vector3.Lerp(clues[currentClue].transform.localPosition, currentCluePos, timeElapsed);
            clues[currentClue - 1].transform.localPosition = Vector3.Lerp(clues[currentClue - 1].transform.localPosition, nextCluePos, timeElapsed);
            timeElapsed += Time.fixedDeltaTime;
            yield return null;
        }
        clues[currentClue].transform.localPosition = currentCluePos;
        clues[currentClue - 1].transform.localPosition = nextCluePos;
        currentClue--;
        canGoNext = true;
    }*/
    public void OpenInventory()
    {
        if(PauseMenu.instance.IsGamePaused == false && isOpened == false && canOpen == true)
        {
            openEvent.Invoke();
        }
    }
    public void CloseInventory()
    {
        if (PauseMenu.instance.IsGamePaused == false && isOpened == true && canOpen == true)
        {
            closeEvent.Invoke();
        }
    }
    public void canOpenTAB()
    {
        SaveManager.instance.activeSave.canOpenInventory = true;
    }
    public void cantOpenTAB()
    {
        SaveManager.instance.activeSave.canOpenInventory = false;
    }
    public void cantOpenBOARD()
    {
        canOpen = false;
    }
    public void canOpenBOARD()
    {
        canOpen = true;
    }
}
