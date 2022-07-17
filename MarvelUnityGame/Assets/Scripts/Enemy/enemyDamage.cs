using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
	private Animator _animator;
    public GameObject enemy;
    public Collider2D player;
    private void Awake()
    {
        _animator = enemy.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == player)
        {
            AddDamage();
        }
    }
    public void AddDamage()
	{
        _animator.SetBool("_isAlive", false);
        enemy.SetActive(false);
	}
}
