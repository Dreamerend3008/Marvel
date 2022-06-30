using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimArea : MonoBehaviour
{
    public GameObject receiver;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, collision.transform.position, 100f);
        receiver.SendMessage("giveDirection", hit.point);
    }
}