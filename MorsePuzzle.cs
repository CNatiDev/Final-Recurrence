using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MorsePuzzle : MonoBehaviour
{
    public static MorsePuzzle instance;
    public GameObject icon1, icon2, icon3, icon4;
    public UnityEvent allCorrect, allWrong, pulledLeverEvent1, pulledLeverEvent2, pulledLeverEvent3, pulledLeverEvent4;
    private int[] solution = new int[] { 1, 2, 3, 4 };
    public int[] input = new int[] { -1, 2, -1, -1 };
    int leversPulled = 0;
    public bool canPull1 = true, canPull2 = true, canPull3 = true, canPull4 = true;
    Color colorRed = new Color32(255, 0, 0, 255);
    Color colorWhite = new Color32(255, 255, 255, 255);
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        StartCoroutine(fadeOutButton1());
        StartCoroutine(fadeOutButton2());
        StartCoroutine(fadeOutButton3());
        StartCoroutine(fadeOutButton4());
    }
    public void PullLever(int leverNumber)
    {
        switch(leverNumber)
        {
            case 1:
                if (canPull1)
                {
                    leversPulled++;
                    input[0] = input[2];
                    input[2] = input[3];
                    input[3] = leverNumber;
                    if (leversPulled == 0 || leversPulled == 1 || leversPulled == 2)
                    {
                        pulledLeverEvent1.Invoke();
                        StartCoroutine(fadeButton1());
                        canPull1 = false;
                        break;
                    }
                    if (leversPulled == 3 && input[0] == solution[0] && input[2] == solution[2] && input[3] == solution[3])
                    {
                        pulledLeverEvent1.Invoke();
                        allCorrect.Invoke();
                        break;
                    }
                    else
                    {
                        allWrong.Invoke();
                        StopAllCoroutines();
                        StartCoroutine(fadeOutButton1());
                        StartCoroutine(fadeOutButton2());
                        StartCoroutine(fadeOutButton3());
                        StartCoroutine(fadeOutButton4());
                        leversPulled = 0;
                        input = new int[] { -1, 2, -1, -1 };
                        canPull1 = canPull2 = canPull3 = canPull4 = true;
                    }
                }
                break;
            case 2:
                if (canPull2)
                {
                    leversPulled++;
                    input[0] = input[2];
                    input[2] = input[3];
                    input[3] = leverNumber;
                    if (leversPulled == 0 || leversPulled == 1 || leversPulled == 2)
                    {
                        pulledLeverEvent2.Invoke();
                        StartCoroutine(fadeButton2());
                        canPull2 = false;
                        break;
                    }
                    if (leversPulled == 3 && input[0] == solution[0] && input[2] == solution[2] && input[3] == solution[3])
                    {
                        pulledLeverEvent2.Invoke();
                        allCorrect.Invoke();
                        break;
                    }
                    else
                    {
                        allWrong.Invoke();
                        StopAllCoroutines();
                        StartCoroutine(fadeOutButton1());
                        StartCoroutine(fadeOutButton2());
                        StartCoroutine(fadeOutButton3());
                        StartCoroutine(fadeOutButton4());
                        leversPulled = 0;
                        input = new int[] { -1, 2, -1, -1 };
                        canPull1 = canPull2 = canPull3 = canPull4 = true;
                    }
                }
                break;
            case 3:
                if (canPull3)
                {
                    leversPulled++;
                    input[0] = input[2];
                    input[2] = input[3];
                    input[3] = leverNumber;
                    if (leversPulled == 0 || leversPulled == 1 || leversPulled == 2)
                    {
                        pulledLeverEvent3.Invoke();
                        StartCoroutine(fadeButton3());
                        canPull3 = false;
                        break;
                    }
                    if (leversPulled == 3 && input[0] == solution[0] && input[2] == solution[2] && input[3] == solution[3])
                    {
                        pulledLeverEvent3.Invoke();
                        allCorrect.Invoke();
                        break;
                    }
                    else
                    {
                        allWrong.Invoke();
                        StopAllCoroutines();
                        StartCoroutine(fadeOutButton1());
                        StartCoroutine(fadeOutButton2());
                        StartCoroutine(fadeOutButton3());
                        StartCoroutine(fadeOutButton4());
                        leversPulled = 0;
                        input = new int[] { -1, 2, -1, -1 };
                        canPull1 = canPull2 = canPull3 = canPull4 = true;
                    }
                }
                break;
            case 4:
                if (canPull4)
                {
                    leversPulled++;
                    input[0] = input[2];
                    input[2] = input[3];
                    input[3] = leverNumber;
                    if (leversPulled == 0 || leversPulled == 1 || leversPulled == 2)
                    {
                        pulledLeverEvent4.Invoke();
                        StartCoroutine(fadeButton4());
                        canPull4 = false;
                        break;
                    }
                    if (leversPulled == 3 && input[0] == solution[0] && input[2] == solution[2] && input[3] == solution[3])
                    {
                        pulledLeverEvent4.Invoke();
                        allCorrect.Invoke();
                        break;
                    }
                    else
                    {
                        allWrong.Invoke();
                        StopAllCoroutines();
                        StartCoroutine(fadeOutButton1());
                        StartCoroutine(fadeOutButton2());
                        StartCoroutine(fadeOutButton3());
                        StartCoroutine(fadeOutButton4());
                        leversPulled = 0;
                        input = new int[] { -1, 2, -1, -1 };
                        canPull1 = canPull2 = canPull3 = canPull4 = true;
                    }
                }
                break;
        }
        if (leversPulled == 3)
        {
            if(input[0] == solution[0] && input[2] == solution[2] && input[3] == solution[3])
            {
                allCorrect.Invoke();
            }
            else
            {
                allWrong.Invoke();
                StartCoroutine(fadeOutButton1());
                StartCoroutine(fadeOutButton2());
                StartCoroutine(fadeOutButton3());
                StartCoroutine(fadeOutButton4());
                leversPulled = 0;
                input = new int[] { -1, 2, -1, -1 };
                canPull1 = canPull2 = canPull3 = canPull4 = true;
            }
        }
    }
    IEnumerator fadeButton1()
    {

        float timeElapsed = 0;
        while(timeElapsed <= 1f)
        {
            icon1.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", Color.Lerp(colorWhite, colorRed, timeElapsed));
            timeElapsed += Time.fixedDeltaTime * 2;
            yield return null;
        }
        icon1.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", colorRed);
        yield return null;
    }
    IEnumerator fadeButton2()
    {

        float timeElapsed = 0;
        while (timeElapsed <= 1f)
        {
            icon2.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", Color.Lerp(colorWhite, colorRed, timeElapsed));
            timeElapsed += Time.fixedDeltaTime * 2;
            yield return null;
        }
        icon2.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", colorRed);
        yield return null;
    }
    IEnumerator fadeButton3()
    {

        float timeElapsed = 0;
        while (timeElapsed <= 1f)
        {
            icon3.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", Color.Lerp(colorWhite, colorRed, timeElapsed));
            timeElapsed += Time.fixedDeltaTime * 2;
            yield return null;
        }
        icon3.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", colorRed);
        yield return null;
    }
    IEnumerator fadeButton4()
    {

        float timeElapsed = 0;
        while (timeElapsed <= 1f)
        {
            icon4.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", Color.Lerp(colorWhite, colorRed, timeElapsed));
            timeElapsed += Time.fixedDeltaTime * 2;
            yield return null;
        }
        icon4.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", colorRed);
        yield return null;
    }
    IEnumerator fadeOutButton1()
    {

        float timeElapsed = 0;
        while (timeElapsed <= 1f)
        {
            icon1.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", Color.Lerp(colorRed, colorWhite, timeElapsed));
            timeElapsed += Time.fixedDeltaTime * 2;
            yield return null;
        }
        icon1.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", colorWhite);
        yield return null;
    }
    IEnumerator fadeOutButton2()
    {

        float timeElapsed = 0;
        while (timeElapsed <= 1f)
        {
            icon2.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", Color.Lerp(colorRed, colorWhite, timeElapsed));
            timeElapsed += Time.fixedDeltaTime * 2;
            yield return null;
        }
        icon2.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", colorWhite);
        yield return null;
    }
    IEnumerator fadeOutButton3()
    {

        float timeElapsed = 0;
        while (timeElapsed <= 1f)
        {
            icon3.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", Color.Lerp(colorRed, colorWhite, timeElapsed));
            timeElapsed += Time.fixedDeltaTime * 2;
            yield return null;
        }
        icon3.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", colorWhite);
        yield return null;
    }
    IEnumerator fadeOutButton4()
    {

        float timeElapsed = 0;
        while (timeElapsed <= 1f)
        {
            icon4.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", Color.Lerp(colorRed, colorWhite, timeElapsed));
            timeElapsed += Time.fixedDeltaTime * 2;
            yield return null;
        }
        icon4.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", colorWhite);
        yield return null;
    }
}
