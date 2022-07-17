using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float wallAware = 0.5f;
    public float aimingTime = 0.5f;
    public float shootingTime = 1.5f;
    public LayerMask groundLayer;
    public Transform _floorPoint;

    private bool _facingRight;
    private bool _Atack;

    private Rigidbody2D _rigidBody;
    private Animator _animator;

    public Rigidbody2D projectile;

    public GameObject Creator;
    public Collider2D player;

    private bool isWalking = true;
    public bool isShooting = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Start()
    {
        if (transform.localScale.x < 0f)
        {
            _facingRight = false;
        }
        else if (transform.localScale.x > 0f)
        {
            _facingRight = true;
        }
    }

    void Update()
    {
        if(_rigidBody.velocity != Vector2.zero)
        {
            isShooting = false;
        }
        Vector2 direction = Vector2.right;
        if (_facingRight == false)
        {
            direction = Vector2.left;
        }
        if (Physics2D.Raycast(transform.position, direction, wallAware, groundLayer))
        {
            flip();
        }
    }
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(_floorPoint.position, Vector2.down, 1f, groundLayer);
        if (hit.collider != null && hit.collider.tag == "Ground")
        {

        }
        else
        {
            flip();
        }
        float horizontalVelocity = speed;

        if (_facingRight == false)
        {
            horizontalVelocity = horizontalVelocity * -1f;
        }
        else
        {
            horizontalVelocity = horizontalVelocity * 1f;
        }
        if(isWalking == true && isShooting == false)
        {
            _rigidBody.velocity = new Vector2(horizontalVelocity, _rigidBody.velocity.y);
            _animator.SetBool("_isWalking", true);
        }
        else
        {
            _rigidBody.velocity = Vector2.zero;
        }
    }

    public void flip()
    {        
        _facingRight = !_facingRight;
        float localScalex = transform.localScale.x;
        localScalex = localScalex * -1f;
        transform.localScale = new Vector3(localScalex, transform.localScale.y, transform.localScale.z);
    }
    public void atack()
    {
        _rigidBody.velocity = Vector2.zero;
    }
    public void getAtack(bool atack)
    {
        StartCoroutine("AimAndShoot");            
    }
    private IEnumerator AimAndShoot()
    {
        isShooting = true;
        isWalking = false;
        _animator.SetTrigger("Shoot");
        yield return new WaitForSeconds(aimingTime);
        RaycastHit2D hit = Physics2D.Raycast(Creator.transform.position, player.transform.position, 1000f);
        for (int i = 0; i <= 2; i++)
        {

            Rigidbody2D p = Instantiate(projectile, Creator.transform.position, Creator.transform.rotation);
            int speed = i + 10;
            p.velocity = new Vector2(-hit.normal.x * speed, -hit.normal.y + i);

        }

        yield return new WaitForSeconds(shootingTime);

        isShooting = false;
        isWalking=true;
    }
}
