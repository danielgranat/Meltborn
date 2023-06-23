using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    [SerializeField]
    GameObject projectilePref;
    [SerializeField]
    Transform fbSpawnPoint;
    [SerializeField]
    float shootSpeed;

    [SerializeField]
    float fireInterval = 3;

    float lastFireball;
    private PlayerSensor playerSensor;
    

    new protected void Start()
    {
        base.Start();
        playerSensor = GetComponentInChildren<PlayerSensor>();
    }

    new protected void Update()
    {
        base.Update();
        if (playerSensor.Player != null && Time.realtimeSinceStartup - lastFireball > fireInterval)
        {
            shootAt(playerSensor.Player);
        }
    }

    

    private void shootAt(GameObject player)
    {
        lastFireball = Time.realtimeSinceStartup + UnityEngine.Random.Range(0.1f,1.5f);
        GameObject fireball = Instantiate(projectilePref, fbSpawnPoint.position, transform.rotation);
        fireball.GetComponent<FireballProjectile>().TTL = fireInterval;
        Vector3 dir = (player.transform.position - gameObject.transform.position).normalized;

        Rigidbody2D fbrb = fireball.GetComponent<Rigidbody2D>();
        //crb.AddForce(gameObject.transform.forward * shootSpeed);

        fbrb.velocity = dir * shootSpeed;

    }
}
