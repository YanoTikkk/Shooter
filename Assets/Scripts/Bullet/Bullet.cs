using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float destroyTime = 1f;

    protected void Start()
    {
        Destroy(gameObject,destroyTime);
    }

    protected void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject,0.1f);
    }
}
