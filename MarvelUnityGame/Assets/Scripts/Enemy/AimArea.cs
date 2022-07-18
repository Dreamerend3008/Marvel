using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimArea : MonoBehaviour
{
    public Rigidbody2D Enemy;
    public Collider2D player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == player)
            {
                Enemy.SendMessage("getAtack", true);
            }
    }
}