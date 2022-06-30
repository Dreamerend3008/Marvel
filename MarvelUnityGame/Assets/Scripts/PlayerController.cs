using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private Rigidbody2D _rigidBody;

    private Vector2 _movement;
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float HorizontalInput = Input.GetAxisRaw("Horizontal");
        _movement = new Vector2(HorizontalInput, 0f);

        if (Input.GetButtonDown("Jump"))
        {
            _rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    void FixedUpdate()
    {
            float horizontalVelocity = _movement.normalized.x * speed;
            _rigidBody.velocity = new Vector2(horizontalVelocity, _rigidBody.velocity.y);
    }
}
