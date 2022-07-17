using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2f;
    public float tiempoVida = 2f;
    private float _startingTime;

    public int damage = 1;


    public GameObject player;
    public GameObject Creator;
    public Vector2 direction; 

    public Color initialColor;
    public Color finalColor;

    private SpriteRenderer _renderer;
    
    private Rigidbody2D _rigidbody;
    

    void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _startingTime = Time.time;

        // Destrozando la bala despues de un tiempo
        Destroy(this.gameObject, tiempoVida);
    }

    // Update is called once per frame
    void Update()
    {
        // cambiando de color la bala conforme el tiempo
        float _TimeSincestarted = Time.time - _startingTime;
        float _porcetanjeCompleto = _TimeSincestarted / tiempoVida;

        _renderer.color = Color.Lerp(initialColor, finalColor, _porcetanjeCompleto);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }

        if (collision.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            // damage
            
        }
    }
    private void OnDestroy()
    {
        //Creator.SendMessage("atacks", false);
    }
}
