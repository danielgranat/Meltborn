using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeProjectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if(collision.gameObject.CompareTag("Ground")
            || collision.gameObject.CompareTag("Fire")
            || collision.gameObject.CompareTag("Enemy")) { 
            Destroy(gameObject);
        }
    }
}
