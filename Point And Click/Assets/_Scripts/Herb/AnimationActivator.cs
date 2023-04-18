using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationActivator : MonoBehaviour
{
    [SerializeField] Animator anim;

    private void OnEnable()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void SetFadeIn()
    {
        anim.SetTrigger("FadeIn");
    }

    public void SetFadeOut()
    {
        anim.SetTrigger("FadeOut");
    }
}
