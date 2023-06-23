using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
    [SerializeField]
    float ttl = 3000;

    private float startTime;

    public float TTL
    {
        get => ttl;
        set => ttl = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.realtimeSinceStartup - startTime > ttl)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")
            || collision.gameObject.CompareTag("Fire")
            || collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
