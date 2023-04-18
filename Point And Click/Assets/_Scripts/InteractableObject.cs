using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TextCollection
{
    [Tooltip("Texto con el que se accede a esta coleccion de strings")] public string tag;
    public string[] texts = new string[1];
}
public class InteractableObject : MonoBehaviour
{
    #region Serialized Variables
    [SerializeField][Tooltip("SOLO ASIGNAR EN CASO DE QUE NO SEA CHILD DEL GAME OBJECT, COMO ES EL CASO DE DAN, CUYO TEXTWRITTER SIEMPRE ES USADO POR OTROS INTERACTABLE OBJECTS")]
    private GameObject textWritingPanel;
    [SerializeField][Tooltip("Clase serializable que guarda un string 'tag' y un array de strings que son todos los que va a decir el objeto al hacerle click")]
    private List<TextCollection> textCollections = new List<TextCollection>();
    #endregion

    private int textsIndex=0;
    private int textsCollectionIndex=0;

    private string[] actualCollection= new string[1];

    private TW_Regular textWritter;
    private Button button;
    private InteractionManager interactionMng;

    private void Awake()
    {
        interactionMng = InteractionManager.Instance;
        button = GetComponent<Button>();
        if (textWritingPanel!=null)
        {
            textWritter = textWritingPanel.GetComponentInChildren<TW_Regular>();
        }
        else
        {
            textWritter = GetComponentInChildren<TW_Regular>();
        }
  
        button.onClick.AddListener(OnObjectInteraction);
        actualCollection = textCollections[0].texts;
    }

    public void OnObjectInteraction()
    {
        if (textWritter.CheckTextWritten())
        {
            textWritter.SkipTypewriter();
        }
        else
        {
            if (textsIndex < actualCollection.Length)
            {
                textWritter.SetAndStart(actualCollection[textsIndex]);
                textsIndex++;
            }
            else 
            {
                interactionMng.NextEvent();
            }
           
        }
    
    }

}
