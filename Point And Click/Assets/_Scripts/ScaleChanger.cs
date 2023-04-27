using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChanger : MonoBehaviour
{
    [SerializeField]
    private Vector3 targetScale;

    private Vector3 originalScale;
    private void Awake()
    {
        originalScale = transform.localScale;
    }

    public void ChangeScale()
    {
        transform.localScale = targetScale;
    }
    public void DefaultScale()
    {
        transform.localScale = originalScale;
    }

}
