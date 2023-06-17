using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private Collider2D ground;
    [SerializeField]
    LayerMask groundObjects;
    [SerializeField]
    Transform groundPoint;
    [SerializeField]
    private float checkRadius;

    private Rigidbody2D rd;
    private bool facingRight = true;
    




    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        handleMove();
        handleJump();
    }

    private void handleJump()
    {
        
        if (isGrounded() && Input.GetButton("Jump"))
        {
            rd.AddForce(new Vector2(0, jumpForce));
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundPoint.position, checkRadius, groundObjects);
    }

    private void handleMove()
    {
        float moveDirection = Input.GetAxis("Horizontal");
        rd.velocity = new Vector2(moveDirection * moveSpeed, rd.velocity.y);

        if(moveDirection < 0 && facingRight) {
            FlipPlayer();
        }

        if (moveDirection > 0 && !facingRight)
        {
            FlipPlayer();
        }
    }

    private void FlipPlayer()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}
