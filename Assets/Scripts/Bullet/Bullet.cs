using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject,0.1f);
    }
}
