using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine9 : MonoBehaviour
{
    private void Start()
    {
        if (SaveManager.instance.hasLoaded)
        {
            if (SaveManager.instance.activeSave.medicine9 == true)
            {
                Destroy(this.gameObject);
            }
        }
    }
    public void PickupBattery()
    {
        HealthSystem.instance.DrugsAmount += 1;
        SaveManager.instance.activeSave.medicine9 = true;
        HealthSystem.instance.pillAmount.text = HealthSystem.instance.DrugsAmount + "x";
        Destroy(this.gameObject);
    }
}
