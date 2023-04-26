using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialThingToHappen : MonoBehaviour
{
    [SerializeField] InteractionManager interactionManager;

    [Header ("Special Objects to Appear")]
    [SerializeField] private List <GameObject> specialButtons = new List<GameObject>();


    [SerializeField] private GameObject wallButton;
    private Image buttonImage;

    [Header("Sprites")]
    [SerializeField] private Sprite wallSprite;
    [SerializeField] private Sprite screamerImage;
    [SerializeField] private Sprite blackOutImage;

    private void Awake()
    {
        foreach (var objects in specialButtons)
        {
            objects.SetActive(false);
        }

        wallButton.SetActive(true);
        buttonImage = wallButton.GetComponent<Image>();
    }

    void Update()
    {
        if (interactionManager.textCollectionIndex == 14)
        {
            //buttonImage.sprite = blackOutImage;
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;

#else
        Application.Quit();
#endif
        }

        if (interactionManager.textCollectionIndex == 13)
        {
            //buttonImage.sprite = screamerImage;
        }

        if (interactionManager.textCollectionIndex == 8)
        {
            specialButtons[0].SetActive(false);
            specialButtons[1].SetActive(true);
        }

        if (interactionManager.textCollectionIndex == 7)
        {
            specialButtons[0].SetActive(true);
        }
    }


}
