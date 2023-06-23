using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnimation : MonoBehaviour
{
    private Animation animationComponent;
    private AnimationClip animationClip;

    private void Awake()
    {
        animationComponent = GetComponent<Animation>();
        animationClip = animationComponent.clip;
    }

    private void Start()
    {
        animationComponent.Play(animationClip.name);
    }

    private void Update()
    {
        if (animationComponent.isPlaying && animationComponent[animationClip.name].time >= animationClip.length)
        {
            animationComponent.Stop();
        }
    }
}
