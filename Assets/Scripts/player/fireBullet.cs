using Unity.VisualScripting;
using UnityEngine;

public class fireBullet : MonoBehaviour
{
    public GameObject bullet;
    public GameObject homingMissile;
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

        if (Input.GetMouseButton(0))
        {
            if(timer >= 60f / fireRate)
            {
                Shoot();
                timer = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject GG = Instantiate(homingMissile, transform.position, Quaternion.identity);
            GG.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
        }
    }


    void Shoot()
    {
        if (AudioSource != null)
            AudioSource.Play();
        GameObject GG = Instantiate(bullet, transform.position, Quaternion.identity);
        GG.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
    }
    public void incFireRate()
    {
        fireRate += 30;

    }
    public void IncBulletForce()
    {
        bulletForce += .4f;
        bulletForce = Mathf.Clamp(bulletForce, 10f, 35f);
    }
}
