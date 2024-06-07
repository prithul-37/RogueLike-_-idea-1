using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBullet : MonoBehaviour
{
    public GameObject bullet;
    public float bulletForce = 10f;
    public int fireRate = 5;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer> (float)1/fireRate)
        {
            GameObject GG =  Instantiate(bullet,transform.position,Quaternion.identity);
            GG.GetComponent<Rigidbody2D>().AddForce(transform.up*bulletForce,ForceMode2D.Impulse);
            timer = 0f;

        }
    }
}
