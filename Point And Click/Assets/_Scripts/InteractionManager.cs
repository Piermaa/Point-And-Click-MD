using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public int textIndex;
    
    public int textCollectionIndex;

    [SerializeField]
    private Text actualText;

    string lastText;

    public bool isWaiting;
    public static InteractionManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

         Setup(0);
        //Next();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(1);
        }
    }


    public void Next()
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

    public void OnObjectInteraction()
    {
        if (textCollectionIndex ==0 &&textIndex==0)
        {
            NextText();
        }
        else if (!isWaiting)
        { 
            if (!CheckCompletion())
            {
                print("didnt finish");
            }
            else
            {
                if (actualTextCollectionTexts.Length > 0 && textIndex < actualTextCollectionTexts.Length)
                {
                    NextText();
                }
                else
                {
                    NextCollection();
                }

            }
           
        }
      

    }
    public void NextText()
    {
        if (actualTextCollectionTexts[textIndex]!=null)
        {
            lastText = actualTextCollectionTexts[textIndex];
        }
     
 
        actualTextWritter.SetAndStart(actualTextCollectionTexts[textIndex]);
        textIndex++;
    }

    private void NextCollection()
    {
        StartCoroutine(WaitForNewCollection(actualTextCollection.delayForNextEvent));
    }

    IEnumerator WaitForNewCollection(float time)
    {
        if (time>0)
        {
            isWaiting = true;
        }
       
        yield return new WaitForSeconds(time);
        isWaiting = false;
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

    public void Setup(TextCollection collection)
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


    public void Setup(int collectionIndex)
    {
        print("setupped: " + collectionIndex);
        textCollectionIndex = collectionIndex;
        TextCollection collection = textCollections[collectionIndex];

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

    bool CheckCompletion()
    {
        print("testo a escribir: " + actualText.text + "testo escroto: " + lastText);
        return actualText.text == lastText;
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void CrashGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#else
        Application.Quit();
#endif
    }
}
