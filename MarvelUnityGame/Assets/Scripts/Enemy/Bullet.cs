using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 direction;
    public int damage = 1;

    public float tiempoVida = 2f;
    public Color initialColor;
    public Color finalColor;

    private SpriteRenderer _renderer;
    private float _startingTime;
    private Rigidbody2D _rigidbody;
    private bool _returning;

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
        //Destroy(this.gameObject, tiempoVida);

    }

    // Update is called once per frame
    void Update()
    {
        // cambiando de color la bala conforme el tiempo
        float _TimeSincestarted = Time.time - _startingTime;
        float _porcetanjeCompleto = _TimeSincestarted / tiempoVida;

        _renderer.color = Color.Lerp(initialColor, finalColor, _porcetanjeCompleto);
    }

    private void FixedUpdate()
    {
        Vector2 movement = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_returning == false && collision.CompareTag("Player"))
        {
            // damage
            //collision.SendMessageUpwards("AddDamage", damage);
            //Destroy(gameObject);
        }

        if (_returning == true && collision.CompareTag("Enemy"))
        {
            // damage
            collision.SendMessageUpwards("AddDamage", damage);
            //Destroy(gameObject);
        }
    }
    public void giveDirection(Vector2 NewDireccion)
    {
       _rigidbody.velocity = NewDireccion * speed;
    }
}
