using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//LA IDEA DE ESTE SCRIPT ES QUE SEA EL QUE DES/ACTIVE LOS INTERACTUABLES Y DES/HABILITE SUS BUTTONS

//caracter invisible '?'

[System.Serializable]
public class TextCollection
{
    [Tooltip("EN QUE POSICION SE TIENE QUE ESCRIBIR EL TEXTO")]public TextEmitter textEmitter;
    [Tooltip("Que va a pasar ANTES de que se muestren los textos")] public UnityEvent textEvent= new UnityEvent();
    [Tooltip("SI EL TEXTO SE TIENE QUE MOSTRAR DESPUES DE UNA ANIMACION TILDAR ESTO, AVISAR A PROGRAMMERS")] public bool waitForAnimation = false;
    [Tooltip("QUE TEXTOS SE VAN A DECIR")][TextArea] public string[] texts = new string[1];
    [Tooltip("CUANTO HAY QUE ESPERAR PARA QUE SE MUESTRE LA SIGUIENTE COLECCION")] public float delayForNextEvent=0;

}

public enum TextEmitter 
{
    Dan, Herb, Door, Window, Mostrador
}

public class InteractionManager : MonoBehaviour
{
    [SerializeField]
    private Text danText;
    [SerializeField]
    private Text herbText;
    [SerializeField]
    private Text doorText;
    [SerializeField]
    private Text windowText;
    [SerializeField]
    private Text mostradorText;
    [SerializeField]
    private List<TextCollection> textCollections = new List<TextCollection>();


    private TextCollection actualTextCollection;
    private TW_Regular actualTextWritter;
    private string[] actualTextCollectionTexts = new string[1];
    private int textIndex;
    private int textCollectionIndex;
    private Text actualText;

    #region Singleton
    public static InteractionManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        Setup(textCollections[0]);
    }
    #endregion

    public void OnObjectInteraction()
    {

        if (actualTextWritter.CheckTextWritten())
        {

        }
        else
        {
            if (textIndex < actualTextCollectionTexts.Length)
            {
                NextText();
            }
            else
            {
                NextCollection();
            }

        }

    }

    public void NextText()
    {
        actualTextWritter.SetAndStart(actualTextCollectionTexts[textIndex]);
        textIndex++;
    }

    private void NextCollection()
    {
        print(actualTextCollection.delayForNextEvent);
        StartCoroutine(WaitForNewCollection(actualTextCollection.delayForNextEvent));
    }

    IEnumerator WaitForNewCollection(float time)
    {
     
        yield return new WaitForSeconds(time);

        SetNextCollection();
    }

    private void SetNextCollection()
    {
        textCollectionIndex++;
        Setup(textCollections[textCollectionIndex]);
        if (!actualTextCollection.waitForAnimation)
        {
            NextText();
        }
      
    }

    private void Setup(TextCollection collection)
    {
        actualTextCollection = collection;
        switch (collection.textEmitter)
        {
            case TextEmitter.Dan:
                actualText = danText;
                break;
            case TextEmitter.Herb:
                actualText = herbText;
                break;
            case TextEmitter.Door:
                actualText = doorText;
                break;
            case TextEmitter.Window:
                actualText = windowText;
                break;
            case TextEmitter.Mostrador:
                actualText = mostradorText;
                break;
        }

        textIndex = 0;
        actualTextWritter = actualText.GetComponent<TW_Regular>();
        actualTextCollectionTexts = collection.texts;
        collection.textEvent.Invoke();
    }
}
