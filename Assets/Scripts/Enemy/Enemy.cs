using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float shotDelay = 3f;
    [SerializeField] private List<Weapon> weaponsIndex = new List<Weapon>();
    [SerializeField] private List<GameObject> indexWeapon = new List<GameObject>();
    [SerializeField] private float speed = 3f;
    [SerializeField] private float timeToReachSpeed = 1f;

    private Vector3 toPlayer;
    private Vector3 force;
    private Rigidbody rigidbodyEnemy;
    private float shotColdown = 0f;
    private bool CanAttack => shotColdown <= 0f;

    private void Awake()
    {
        RandomWeapon();
        rigidbodyEnemy = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        toPlayer = (playerTransform.position - transform.position).normalized; 
        force = rigidbodyEnemy.mass * (toPlayer * speed - rigidbodyEnemy.velocity) / timeToReachSpeed;
        rigidbodyEnemy.AddForce(force);
    }

    private void Update()
    {
        RotateToPlayer();
        Attack();
    }

    private void RotateToPlayer()
    {
        transform.LookAt(playerTransform);
    }

    private void Attack()
    {
        if (CanAttack)
        {
            for (int i = 0; i < weaponsIndex.Count; i++)
            {
                weaponsIndex[i].GetComponent<Weapon>().Shoot();
            }
            
            shotColdown = shotDelay;
        }
        
        if (shotColdown > 0)
        {
            shotColdown -= Time.deltaTime;
        }
    }

    private void RandomWeapon()
    {
        indexWeapon[Random.Range(0,3)].SetActive(true);
    }
}
