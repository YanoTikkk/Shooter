using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    
    public void TakeDamage(int damageValue)
    {
        health -= damageValue;
        
        if (health <= 0)
        {
                health = 0;
                Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
