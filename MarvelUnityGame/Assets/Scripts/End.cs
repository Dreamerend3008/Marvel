using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public GameObject Game;
    public GameObject Hub;
    public GameObject Message1;
    public GameObject Message2;
    public Collider2D Player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == Player)
        {
            Game.SetActive(false);
            Hub.SetActive(true);
            Message1.SetActive(true);
            Message2.SetActive(false);
        }
    }
}
