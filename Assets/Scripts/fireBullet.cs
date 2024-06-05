using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBullet : MonoBehaviour
{
    public GameObject bullet;
    public float bulletForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject GG =  Instantiate(bullet,transform.position,Quaternion.identity);
            GG.GetComponent<Rigidbody2D>().AddForce(transform.up*bulletForce,ForceMode2D.Impulse);

        }
    }
}
