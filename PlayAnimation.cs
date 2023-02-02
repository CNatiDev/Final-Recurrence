using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationFunction : MonoBehaviour
{
    private Animator Animator;
    private void Start()
    {
        Animator = this.gameObject.GetComponent<Animator>();
    }
    public void PlayAnimation(string AnimationName)
    {
        Animator.Play(AnimationName);
    }
}
