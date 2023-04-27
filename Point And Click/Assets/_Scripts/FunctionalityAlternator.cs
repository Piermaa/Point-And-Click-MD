using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FunctionalityAlternator : MonoBehaviour
{
    [SerializeField]
    private int interactionCounter;
    public int interactionsToAlternateFunctionality;
    private Button butt;

    public UnityEvent firstFunctionality;
    public UnityEvent secondFunctionality;


    private void Awake()
    {
        butt = GetComponent<Button>();
        butt.onClick.AddListener(OnInteraction);
    }

    public void OnInteraction()
    {
        if (interactionCounter < interactionsToAlternateFunctionality)
        {
            firstFunctionality.Invoke();
        }
        else
        {
            secondFunctionality.Invoke();
        }
        interactionCounter++;
    }

}
