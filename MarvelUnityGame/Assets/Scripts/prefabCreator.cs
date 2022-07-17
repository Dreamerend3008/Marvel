using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabCreator : MonoBehaviour
{
    public GameObject prefab;
    public Transform point;
    public int livingTime;
    public bool atack = false;

    public void Intantiate(Vector2 direction)
    {
        if (atack == true)
        {
            GameObject instantiateObject = Instantiate(prefab, point.position, Quaternion.identity) as GameObject;
            instantiateObject.SendMessage("giveDirection", direction);
            atack = true;
        }
    }
    public void atacks(bool infoAtack)
    {
        atack = infoAtack;
    }
}
