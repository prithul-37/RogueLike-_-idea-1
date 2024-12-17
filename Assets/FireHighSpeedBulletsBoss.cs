using UnityEngine;

public class FireHighSpeedBulletsBoss : MonoBehaviour
{
    public GameObject bulletPrefab;       // Bullet prefab
    public Transform[] firePoint;           // Point where the bullets are spawned
    public float fireRate = 0.5f;         // Time between each shot

    private float nextFireTime = 0f;

    void Update()
    {
        // Fire bullet when enough time has passed
        if (Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Fire()
    {
        // Instantiate the bullet at the firepoint's position and rotation
        foreach (Transform t in firePoint)
        {
            var b = Instantiate(bulletPrefab, t.position, t.rotation);
            b.GetComponent<EnemyBullet>().ShootAtDierctionGiven(transform.up);
        }
    }
}
