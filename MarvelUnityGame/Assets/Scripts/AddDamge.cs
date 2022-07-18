using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDamge : MonoBehaviour
{
    public Collider2D Enemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != Enemy.tag)
        {
            Destroy(collision.gameObject);
            SendMessageUpwards("AddDamage", 1);
        }
       

    }

}

