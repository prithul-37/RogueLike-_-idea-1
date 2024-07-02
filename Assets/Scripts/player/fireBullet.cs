using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBullet : MonoBehaviour
{
    public GameObject bullet;
    public float bulletForce = 10f;
    public int fireRate = 5; //bullet per min
    public AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        StartCoroutine(shoot());

    }

    IEnumerator shoot()
    {
        WaitForSeconds wait = new WaitForSeconds((float)60/fireRate);
        while (true) 
        {
            yield return wait;
            if(AudioSource != null)
                AudioSource.Play();
            GameObject GG = Instantiate(bullet, transform.position, Quaternion.identity);
            GG.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
        }
        
    }
    public void incFireRate()
    {
        fireRate+=30;
        //print(fireRate);
        StopAllCoroutines();
        StartCoroutine(shoot());

    }
    public void incBulletForce()
    {
        bulletForce+=.4f;
        bulletForce = Mathf.Clamp(bulletForce, 10f, 35f);
    }
}
