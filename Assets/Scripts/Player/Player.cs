using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Weapon> weaponsIndex = new List<Weapon>();
    [SerializeField] private float speedMove = 5f;
    [SerializeField] private float jumpSpeed = 5f;

    private Rigidbody rigidbodyPlayer;
    private bool ground;
    
    private void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Jump(jumpSpeed);
    }
    
    private void FixedUpdate()
    {
        Move(speedMove);
        
        if (Input.GetMouseButton(0))
        {
            for (int i = 0; i < weaponsIndex.Count; i++)
            {
                weaponsIndex[i].GetComponent<Weapon>().Shoot();
            }
        }
    }

    private void Move(float speed)
    {
        float h = Input.GetAxis("Horizontal") * speed;
        float v = Input.GetAxis("Vertical") * speed;
        rigidbodyPlayer.AddForce(h,0,v,ForceMode.Acceleration);
    }

    private void Jump(float speed)
    {
        if (Input.GetKey(KeyCode.Space) && ground)
        {
            rigidbodyPlayer.AddForce(0,speed,0,ForceMode.Acceleration);
        }
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        ground = true;
    }

    private void OnCollisionExit(Collision other)
    {
        ground = false;
    }
}
