using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Jumpscare2 : MonoBehaviour
{
    public UnityEvent IfDestroyed;
    private void Start()
    {
        if (SaveManager.instance.hasLoaded)
        {
            if (SaveManager.instance.activeSave.jumpscare2 == true)
            {
                Destroy(this.gameObject);
                IfDestroyed.Invoke();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.tag != null)
        {
            if (other.tag == "Player")
            {
                SaveManager.instance.activeSave.jumpscare2 = true;
            }
        }
    }
}
