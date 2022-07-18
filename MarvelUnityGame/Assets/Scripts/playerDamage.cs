using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDamage : MonoBehaviour
{
    public int totalhealth = 4;
    public int DamageBorder = 0;
    public RectTransform heartUI;
    public SpriteRenderer DamageBorderUI;
    public Color temp;

    public GameObject GameOverMenu;
    public GameObject Game;
    //public GameObject hordes;
    public GameObject CheckPoint;
    //public GameObject Audio;
   //public GameObject Audio2;

    //Camera 
    public GameObject Camera;
    public GameObject CenterPoint;
    public Vector2 CameraPosition;

    //particle
    public ParticleSystem particle;

    private int health;
    private float heartSize = 66f;

    private SpriteRenderer _renderer;
    private Animator _animator;
    private PlayerController _controller;
    private Vector2 _savedPosition;


    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _controller = GetComponent<PlayerController>();
    }
    void Start()
    {
        health = totalhealth;
        _savedPosition = CheckPoint.transform.position;

    }
    public void AddDamage(int amount)
    {
        health = health - amount;
        DamageBorder = DamageBorder + amount;
        // vidual feadback
        //StartCoroutine("VisualFeedback");
        StartCoroutine("CameraShaking");
        //StartCoroutine("ParticleSystem");

        // game over
        if (health <= 0)
        {
            health = 0;
            gameObject.SetActive(false);
            temp = DamageBorderUI.color;
            DamageBorderUI.enabled = false;
            temp.a = 0;
            DamageBorderUI.color = temp;
        }
        //DamageBorderUI.enabled = true;
        //temp = DamageBorderUI.color;
        //temp.a = temp.a + 0.4f;
        //DamageBorderUI.color = temp;
        heartUI.sizeDelta = new Vector2(heartSize * health, heartSize);
    }
    public void Addhealth(int amount)
    {
        health = health + amount;

        // Max health
        if (health >= totalhealth)
        {
            health = totalhealth;
        }
        //temp = DamageBorderUI.color;
        //temp.a = temp.a - 0.4f;
        //DamageBorderUI.color = temp;
        heartUI.sizeDelta = new Vector2(heartSize * health, heartSize);
    }

    private IEnumerator VisualFeedback()
    {
        _renderer.color = Color.red;
        float cameraBackUpX = Camera.transform.position.x;
        yield return new WaitForSeconds(0.1f);

        _renderer.color = Color.white;
    }
    private void OnEnable()
    {
        health = totalhealth;
        _renderer.color = Color.white;
        MaxHerath();
        this.transform.position = _savedPosition;
        health = totalhealth;
        //DamageBorderUI.enabled = false;
        temp.a = 0;
    }
    private void OnDisable()
    {
        GameOverMenu.SetActive(true);
        Game.SetActive(false);
        //Audio.SetActive(true);
        //Audio2.SetActive(false);
        health = 0;
    }
    public void MaxHerath()
    {
        health = totalhealth;
        heartUI.sizeDelta = new Vector2(heartSize * health, heartSize);
    }
    private IEnumerator CameraShaking()
    {
        Camera.transform.position = new Vector2(CenterPoint.transform.position.x + 1f, Camera.transform.position.y);

        yield return new WaitForSeconds(0.025f);

        Camera.transform.position = new Vector2(CenterPoint.transform.position.x - 3f, Camera.transform.position.y);

        yield return new WaitForSeconds(0.025f);

        Camera.transform.position = new Vector2(CenterPoint.transform.position.x + 1f, Camera.transform.position.y);

        yield return new WaitForSeconds(0.025f);

        Camera.transform.position = new Vector2(CenterPoint.transform.position.x, Camera.transform.position.y);
    }
    private IEnumerator ParticleSystem()
    {
        particle.Play();
        yield return new WaitForSeconds(0.1f);
        particle.Stop();
    }
}
