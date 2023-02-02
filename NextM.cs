using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class NextM : MonoBehaviour
{
    public bool[] Ok;
    public UnityEvent Event;
    private void Update()
    {
        for (int i = 0; i < Ok.Length; i++)
        {
            Event.Invoke();
        }
    }
    public void SetOk(int i)
    {
        Ok[i] = true;
    }
}
