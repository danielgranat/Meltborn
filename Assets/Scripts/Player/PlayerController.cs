using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController obj;
    
    public int Lives = 3;
    public bool isGrounded = false;
    public bool isMoving = false;
    public bool isInmune = false;
    public bool isDemage = false;

    public float speed = 5f;
    public float jumpForce = 5f;
    public float movHor;
    
    public float inmuneTimeCnt = 0f;
    public float inmuneTime = 0.5f;
    
    public LayerMask groundLayer;
    public float radius = 0.8f; //Radio del circulo que detecta el suelo
    public float groundRayDistance = 0.5f; //Distancia del rayo que detecta el suelo
    
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;

    private bool facingRight = true;
    private float lastHitTime;

    void Awake()
    {
        obj = this;
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void OnDestroy()
    {
        obj = null;
    }

    private void Update()
    {
        movHor = Input.GetAxisRaw("Horizontal");
        isMoving = movHor != 0f;
        flip(movHor); /*REVISAR*/

        isGrounded =
            Physics2D.CircleCast(transform.position, radius, Vector2.down, groundRayDistance,
                groundLayer); //Verifica si el jugador esta en el suelo
        if (Input.GetKeyDown(KeyCode.Space))
            jump();
        
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isMoving", isMoving);
    }

    private void FixedUpdate()
    {
        if(Time.realtimeSinceStartup - lastHitTime > 1)
            rb.velocity = new Vector2(movHor * speed, rb.velocity.y);
    }
    
    public void jump()
    {
        if (!isGrounded) return;
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void flip (float movHor) /*REVISAR*/
    {
        if ((movHor < 0 && facingRight) || (movHor > 0 && !facingRight))
        {
            //sr.flipX = true;
            facingRight = !facingRight;
            transform.Rotate(0, 180, 0);
        }
    }


    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && Time.realtimeSinceStartup - lastHitTime > 1 )
        {
            takeHit(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FBProjectile"))
        {
            if (!collision.gameObject.active) return;

            takeHit(collision.gameObject);
        }
    }

    private void takeHit(GameObject other)
    {
        lastHitTime = Time.realtimeSinceStartup;
        Debug.Log($"Enemy hit, {other.name}");
        GameManager.obj.enemyDemage();
        anim.SetTrigger("isHit");
        Vector3 dir = (other.transform.position - gameObject.transform.position).normalized;
        Vector2 velocity = new Vector2(dir.x*-1, 1);
        //if (dir.x < 0)
        //{
        //    velocity.x *= -1;
        //}
        
        Debug.Log($"velocity:{velocity * jumpForce}");
        rb.velocity = new Vector2(velocity.x * speed, jumpForce/2);
        //rb.AddForce(velocity * jumpForce, ForceMode2D.Impulse);
    }

}
