using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2f;
    public float tiempoVida = 2f;
    private float _startingTime;

    public int damage = 1;

    private bool _returning;

    public GameObject player;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        // cambiando de color la bala conforme el tiempo
        float _TimeSincestarted = Time.time - _startingTime;
        float _porcetanjeCompleto = _TimeSincestarted / tiempoVida;

        _renderer.color = Color.Lerp(initialColor, finalColor, _porcetanjeCompleto);

        //move
        _rigidbody.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_returning == false && collision.CompareTag("Player"))
        {
            
        }

        if (_returning == true && collision.CompareTag("Enemy"))
        {
            // damage
            collision.SendMessageUpwards("AddDamage", damage);
        }
    }
    public void giveDirection(Vector2 NewDireccion)
    {
       direction = NewDireccion.normalized;
    }
}
