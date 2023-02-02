using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlTransparency : MonoBehaviour
{
    public Renderer renderer1;
    public UnityEvent @event;
    public Color32 colorToGoTo, normalColor;
    [SerializeField] bool startAuto = false;
    [SerializeField] float time;
    private void Start()
    {
        if(startAuto)
        makeTransparent();
    }
    public void makeTransparent()
    {
        StartCoroutine(MakeTransparent(time));
    }
    IEnumerator MakeTransparent(float timeToPass)
    {
        float timeElapsed = 0f;
        while (timeElapsed <= timeToPass)
        {
            renderer1.material.SetColor("_TintColor", Color32.Lerp(normalColor, colorToGoTo, timeElapsed));
            timeElapsed += Time.fixedDeltaTime;
            yield return null;
        }
        @event.Invoke();
        yield return null;
    }
}
