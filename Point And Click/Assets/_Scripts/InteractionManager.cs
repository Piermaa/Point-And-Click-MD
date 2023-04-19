using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//LA IDEA DE ESTE SCRIPT ES QUE SEA EL QUE DES/ACTIVE LOS INTERACTUABLES Y DES/HABILITE SUS BUTTONS

//caracter invisible '?'

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager Instance;

    [SerializeField]
    private List<GameObject> interactables = new List<GameObject>();
    [SerializeField][Tooltip("Array de eventos, se llaman por orden, se llaman solo cuando ya no hay mas textos")]
    private UnityEvent[] interactionEvents = new UnityEvent[1];
    [SerializeField]

    private int interactionIndex=0;
    public int InteractionIndex
    {
        set { interactionIndex=value; }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void NextEvent()
    {
        print("nexxt");
        interactionEvents[interactionIndex].Invoke();
        interactionIndex++;
    }

    public void NextEventWithDelay(float delay)
    {
        StartCoroutine(Delay(delay));
    }

    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        NextEvent();
    }

   
}
