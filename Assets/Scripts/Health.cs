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

    public void TakeElectroDamage(int damagePerSecond, int alldamage , float damageDelay)
    {
        StartCoroutine(ToDamageElectro(damagePerSecond, alldamage, damageDelay));
    }

    private IEnumerator ToDamageElectro(int damagePerSecond, int allDamage , float damageDelay)
    {
        while (allDamage > 0)
        {
            allDamage -= damagePerSecond;
            health -= damagePerSecond;
            
            if (health <= 0)
            {
                health = 0;
                Die();
            }
            
            yield return new WaitForSeconds(damageDelay);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
