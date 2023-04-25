using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChanger : MonoBehaviour
{
    public void ChangePosition(GameObject newPosition)
    {
        transform.position = newPosition.transform.position;
    }

    public void ChangeCameraPosition (GameObject newPosition)
    {
        transform.position = newPosition.transform.position;
        transform.rotation = newPosition.transform.rotation;
    }

}
