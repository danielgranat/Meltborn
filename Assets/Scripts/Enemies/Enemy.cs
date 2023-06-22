using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    public float movHor;
    public float speed = 3f;
    public int maxDemage;
    public GameObject spawnCubePref;
    public int cubesToSpawn = 3;

    public bool isGroundFloor = true;
    public bool isGroundFront = false;

    public LayerMask groundLayer;
    public float frontGrndRayDistance = 0.25f;
    public float floorCheckY = 0.52f;
    public float frontCheck = 0.51f;
    public float frontDist = 0.001f;

    private bool canFlip = true;

    private RaycastHit2D hit;
    private int currDemage;
    private HealthBar healthBar;


    public float DemagePercent => currDemage / (float)maxDemage;


    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        healthBar = GetComponentInChildren<HealthBar>();
        currDemage = maxDemage;
        movHor = 1;
    }

    protected void Update()
    {
        healthBar.Health = DemagePercent;

        // Evita caer en el precipicio
        isGroundFloor = Physics2D.Raycast(
            new Vector3(transform.position.x, transform.position.y - floorCheckY, transform.position.z),
            new Vector3(movHor, 0f, 0f), frontGrndRayDistance, groundLayer);

        if (isGroundFloor)
            movHor = movHor * -1;

        // Choque con pared
        Vector3 frontOrigin = new Vector3(transform.position.x + movHor * frontCheck, transform.position.y, transform.position.z);

        if (Physics2D.OverlapCircle(frontOrigin, frontCheck, groundLayer))
            movHor = movHor * -1;

        
        flip(movHor);
    }

    private void FixedUpdate()
    {
        if(speed > 0)
            rb.velocity = new Vector2(movHor * speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            movHor = movHor * -1;
            flip(movHor);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            if (!collision.gameObject.active) return;

            currDemage -= 1;
            collision.gameObject.SetActive(false);
            //Destroy(collision.gameObject);
            Debug.Log($"currDemage:{currDemage}");
            if(currDemage == 0)
            {
                for(int idx = 0; idx < cubesToSpawn; idx++)
                {
                    GameObject cube = Instantiate(spawnCubePref, transform.position, transform.rotation);
                    cube.transform.position = cube.transform.position + new Vector3(UnityEngine.Random.Range(-1, 1), 1, 0);
                }
                
                Destroy(gameObject);
            }
        }
    }

    void flip(float movHor)
    {
        if (movHor > 0)
        {
            sr.flipX = true;
        }
        else if (movHor < 0)
        {
            sr.flipX = false;
        }
    }

    private void OnDrawGizmos()
    {
        // Dibuja el rayo de comprobación del suelo frontal
        Gizmos.color = Color.blue;
        Vector3 frontOrigin = new Vector3(transform.position.x + movHor * frontCheck, transform.position.y, transform.position.z);
        Gizmos.DrawRay(frontOrigin, new Vector3(movHor, 0f, 0f) * frontDist);

        // Dibuja el rayo de comprobación del suelo frontal en el editor
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(frontOrigin, frontCheck);

        // Dibuja el rayo de comprobación del suelo inferior en el editor
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y - floorCheckY, transform.position.z), frontGrndRayDistance);
    }
}


/*if (hit != null)
        if (hit.transform != null)
            if (hit.transform.CompareTag("Enemy"))
                shouldFlip = true;*/


//Choque con otro enemigo
/*hit = Physics2D.Raycast(
    new Vector3(transform.position.x + movHor * frontCheck, transform.position.y, transform.position.z),
    new Vector3(movHor, 0f, 0f), frontDist);
if (hit != null)
    if (hit.transform != null)
        if (hit.transform.CompareTag("Enemy"))
            movHor = movHor * -1;

flip(movHor);*/
