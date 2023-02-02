using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    public Animator animator;
    public string OpenAnimation;
    public string CloseAnimation;
    public AudioSource openSFX, closeSFX;
    private bool isOpened = false;
    public bool canInteract = true;
    private void Start()
    {
        if(animator == null)
            animator = GetComponent<Animator>();
    }
    public void OpenDrawer()
    {
        if(isOpened == false && canInteract == true)
        {
            animator.Play(OpenAnimation);
            openSFX.Play();
            isOpened = !isOpened;
        }
        else if(isOpened == true && canInteract == true)
        {
            animator.Play(CloseAnimation);
            closeSFX.Play();
            isOpened = !isOpened;
        }
    }

}
