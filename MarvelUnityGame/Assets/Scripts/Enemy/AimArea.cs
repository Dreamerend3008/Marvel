using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimArea : MonoBehaviour
{
    public GameObject receiver;
    public GameObject Creator;
    bool atack = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, collision.transform.position, 100f);
        if (hit && atack == false)
        {
            Creator.SendMessage("Intantiate", hit.point);
            atack = true;
        }
        
    }
}