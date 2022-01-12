using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float shotingRate;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnBullet;
    [SerializeField] private float bulletSpeed = 3f;
    [SerializeField] private float dispersionMax = 5f;
    [SerializeField] private float dispersionMin = 5f;
    [SerializeField] private int maxAmmo = 10;
    [SerializeField] private float reloadTime = 4f;
    [SerializeField] protected float distanceBullet = 1f;
    
    private float shotColdown = 0f;
    private bool canAttack => shotColdown <= 0f;
    private int curentAmmo;

    protected void Awake()
    {
        curentAmmo = maxAmmo;
    }

    protected virtual void Update()
    {
        if (shotColdown > 0)
        {
            shotColdown -= Time.deltaTime;
        }
    }

    public void Shoot()
    {
        if (canAttack && curentAmmo > 0)
        {
            shotColdown = shotingRate;
            float randomDispersion = Random.Range(1f * dispersionMin,1f * dispersionMax);
            GameObject newBullets = Instantiate(bullet,spawnBullet.position, 
                Quaternion.Euler(new Vector3(spawnBullet.rotation.x + randomDispersion,spawnBullet.rotation.y +randomDispersion,spawnBullet.rotation.z)));
            newBullets.GetComponent<Rigidbody>().velocity = newBullets.transform.TransformDirection(spawnBullet.forward) * bulletSpeed;
            Destroy(newBullets,distanceBullet);
            curentAmmo -= 1;
        }

        if (curentAmmo <= 0)
        {
            Invoke("Reload",reloadTime);
        }
    }

    private void Reload()
    {
        curentAmmo = maxAmmo;
    }
}
