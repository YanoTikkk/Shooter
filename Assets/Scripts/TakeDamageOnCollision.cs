using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private Health health;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<BulletPistol>())
            {
                health.TakeDamage(10);
            }
            if (collision.rigidbody.GetComponent<BulletRifle>())
            {
                health.TakeDamage(25);
            }
            if (collision.rigidbody.GetComponent<BulletTommy>())
            {
                health.TakeDamage(15);
            }
        }
    }
}
