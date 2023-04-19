using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationActivator : MonoBehaviour
{

    [SerializeField] UnityEvent ue;
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

    public void AnimationFinishEvent()
    {
        //ue.Invoke();
        InteractionManager.Instance.NextText();
    }
}

