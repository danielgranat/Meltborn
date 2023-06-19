using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public float timeGiven = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.obj.addScore(1);//Modify this addScore Function in GAMEMANAGER for add Time to Timer
            Destroy(gameObject);
        }
    }
}
