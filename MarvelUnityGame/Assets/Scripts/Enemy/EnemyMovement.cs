using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float wallAware = 0.5f;
    public LayerMask groundLayer;
    public Transform _floorPoint;

    private bool _facingRight;

    private Rigidbody2D _rigidBody;

    private void Awake()
    {
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
        RaycastHit2D hit = Physics2D.Raycast(_floorPoint.position, -Vector2.up, 0.1f, groundLayer);
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

        _rigidBody.velocity = new Vector2(horizontalVelocity, _rigidBody.velocity.y);
    }

    public void flip()
    {
        _facingRight = !_facingRight;
        float localScalex = transform.localScale.x;
        localScalex = localScalex * -1f;
        transform.localScale = new Vector3(localScalex, transform.localScale.y, transform.localScale.z);
    }
}
