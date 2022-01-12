using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private int damagePistol = 10;
    [SerializeField] private int damageRifle = 25;
    [SerializeField] private int damageTommy = 15;
    [SerializeField] private int damagePerSecondElectro = 5;
    [SerializeField] private int damageAllElectro = 15;
    [SerializeField] private float damageDelayElectro = 3f;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<BulletPistol>())
            {
                health.TakeDamage(damagePistol);
            }
            if (collision.rigidbody.GetComponent<BulletRifle>())
            {
                health.TakeDamage(damageRifle);
            }
            if (collision.rigidbody.GetComponent<BulletTommy>())
            {
                health.TakeDamage(damageTommy);
            }
            if (collision.rigidbody.GetComponent<BulletElectro>())
            {
                health.TakeElectroDamage(damagePerSecondElectro,damageAllElectro,damageDelayElectro);
            }
        }
    }
}
