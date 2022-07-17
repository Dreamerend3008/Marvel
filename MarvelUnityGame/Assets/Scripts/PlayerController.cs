using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;

    public float speed;
    public float jumpForce;

    private bool _facingRight;
    private bool _isGrounded;

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
        if (Input.GetButtonDown("Jump") && _isGrounded == true)
        {
            _rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        if (Input.GetButtonDown("Fire1") && _isGrounded == true)
        {
            _animator.SetTrigger("Atack");
        }

        if (HorizontalInput > 0f && _facingRight == true)
        {
            flip();
        }
        else if (HorizontalInput < 0f && _facingRight == false)
        {
            flip();
        }

        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
    private void LateUpdate()
    {
        _animator.SetBool("_isGrounded", _isGrounded);
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
