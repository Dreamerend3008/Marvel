using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDamge : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SendMessageUpwards("AddDamage", 1);
    }
}
