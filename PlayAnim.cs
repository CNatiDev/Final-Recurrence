using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    private Animator Animator;
    private void Start()
    {
        Animator = this.gameObject.GetComponent<Animator>();
    }
    public void PlayAnima(string AnimName)
    {
        Animator.Play(AnimName);
    }
}
