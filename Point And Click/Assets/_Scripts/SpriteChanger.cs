using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SpriteChangers
{
    Dan, Herb, Door, Window, Mostrador
}

public class SpriteChanger : MonoBehaviour
{
    //public SpriteChangers spriteChangers;

    
    //private void Setup(SpriteChangers srChangers)
    //{
    //    switch (srChangers)
    //    {
    //        case srChangers.Dan:
    //            break;
    //    }
    //}


    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void ChangeSprite(Sprite newSprite)
    {
        image.sprite = newSprite;
    }

}

