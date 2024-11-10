using UnityEngine;

public class FireBulletEnemy : MonoBehaviour
{
    public GameObject bullet;
    public float bulletForce = 10f;
    public int fireRate = 5; //bullet per min
    public AudioSource AudioSource;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= (60f / fireRate))
        {
            Shoot();
            timer = 0;
        }

    }

    void Shoot()
    {
        if (AudioSource != null)
            AudioSource.Play();
        GameObject GG = Instantiate(bullet, transform.position, Quaternion.identity);
        GG.GetComponent<EnemyBullet>().ShootAtPlayer();
    }
}
