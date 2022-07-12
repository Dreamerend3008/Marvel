using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private bool _facingRight;

    private Rigidbody2D _rigidBody;
    private Animator _animator;

    private Vector2 _movement;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float HorizontalInput = Input.GetAxisRaw("Horizontal");
        _movement = new Vector2(HorizontalInput, 0f);

        if(HorizontalInput != 0f)
        {
            _animator.SetBool("Walking", true);
        }
        else
        {
            _animator.SetBool("Walking", false);
        }
        if (Input.GetButtonDown("Jump"))
        {
            _rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (HorizontalInput > 0f && _facingRight == true)
        {
            flip();
        }
        else if (HorizontalInput < 0f && _facingRight == false)
        {
            flip();
        }
    }
    void FixedUpdate()
    {
            float horizontalVelocity = _movement.normalized.x * speed;
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
