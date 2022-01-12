using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float shotingRate;
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected Transform spawnBullet;
    [SerializeField] protected float bulletSpeed = 3f;
    [SerializeField] protected float dispersionMax = 5f;
    [SerializeField] protected float dispersionMin = 5f;
    [SerializeField] protected int maxAmmo = 10;
    [SerializeField] protected float reloadTime = 4f;
    [SerializeField] protected float distanceBullet = 1f;
    
    protected float shotColdown = 0f;
    protected bool canAttack => shotColdown <= 0f;
    protected int curentAmmo;

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

    public abstract void Shoot();
    
    public abstract void Reload();
}

