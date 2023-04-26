using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//QUE CHUSMEAS GIL!!!1!!
[System.Serializable]
public class Colors
{
    [Tooltip("POR ESTE COLOR ME LLAMAS EN INTERACTIONMANAGER.CS")]public string colorName;
    public Color color;
}
public class ColorSwapper : MonoBehaviour
{
    public List<Colors> colors = new(1);
    public Dictionary<string,Colors> colorsDic = new();
    private Button butt;
    private Image img;
    private void Awake()
    {
        foreach (Colors col in colors)
        {
            colorsDic.Add(col.colorName, col);
        }
        img = GetComponent<Image>();
        butt = GetComponent<Button>();
    }

    public void SwapColor(string colorName)
    {
       img.color = colorsDic[colorName].color;
    }
}
