using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBullet : MonoBehaviour
{
    public GameObject bullet;
    public float bulletForce = 10f;
    public int fireRate = 5; //bullet per min

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(shoot());
    }

    IEnumerator shoot()
    {
        WaitForSeconds wait = new WaitForSeconds((float)60/fireRate);
        while (true) 
        {
            yield return wait;
            GameObject GG = Instantiate(bullet, transform.position, Quaternion.identity);
            GG.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
        }
        
    }
}
