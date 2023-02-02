using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lader : MonoBehaviour
{
    public float Go = 100f;
    public float range = 3f;

    public GameObject LadderGo;
    public bool isRising = false;

    public Camera fpsCam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                StartCoroutine(UpLadder());
            }
        }
    }

    IEnumerator UpLadder()
    {
        isRising = true;
        LadderGo.GetComponent<Animator>().Play("LadderUp");
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(5f);
        LadderGo.GetComponent<Animator>().Play("New State");
        isRising = false;
    }
}
