using UnityEngine;

public class Tommy : Weapon
{
    public override void Shoot()
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

    public override void Reload()
    {
        curentAmmo = maxAmmo;
    }
}
