using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChanger : MonoBehaviour
{
    [SerializeField]
    private Vector3 targetScale1;

    [SerializeField]
    private Vector3 targetScale2;

    private Vector3 originalScale;
    private void Awake()
    {
        originalScale = transform.localScale;
    }

    public void ChangeScale(int num)
    {
        switch (num)
        {
            case 1:
             transform.localScale = targetScale1;
                break;
            case 2:
                transform.localScale = targetScale2;
                break;
        }
    }
       
    
    public void DefaultScale()
    {
        transform.localScale = originalScale;
    }

}
