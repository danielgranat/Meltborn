using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCube : MonoBehaviour
{
    [SerializeField]
    GameObject cubePrefab;
    [SerializeField]
    Transform cubeSpawn;
    [SerializeField]
    private float attackInterval;
    [SerializeField]
    private float shootSpeed;
    [SerializeField]
    private float spawnOffset;
    [SerializeField]
    FloatVar CUBES;

    private Animator anim;
    private bool isAttacking = false;
    private bool cubeSpawned = false;
    private float attackStartTime = 0;
    


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttacking)
        {
            if (CUBES.Value <= 0) return;

            float fire = Input.GetAxis("Fire1");
            if (fire > 0)
            {
                Debug.Log($"fire: {fire}");
                isAttacking = true;
                attackStartTime = Time.realtimeSinceStartup;
                anim.SetTrigger("isThrowing");
                CUBES.Decrement(1);
            }
        }
        else
        {
            if(!cubeSpawned && Time.realtimeSinceStartup - attackStartTime >= spawnOffset)
            {
                shoot();
            }

            isAttacking = Time.realtimeSinceStartup - attackStartTime < attackInterval;
            if (!isAttacking)
            {
                attackStartTime = 0;
                cubeSpawned = false;
            }
        }
    }

    private void shoot()
    {
        cubeSpawned = true;
        GameObject cube = Instantiate(cubePrefab, cubeSpawn.position, transform.rotation);
        cube.transform.position = cubeSpawn.position;
        Rigidbody2D crb = cube.GetComponent<Rigidbody2D>();
        //crb.AddForce(gameObject.transform.forward * shootSpeed);

        crb.velocity = transform.TransformDirection(Vector2.right) * shootSpeed;
    }
}
