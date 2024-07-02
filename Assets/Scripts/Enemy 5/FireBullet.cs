using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public float nextFire;
    private float timer = 5f;
    public float force;

    private void Start()
    {
        fire();
        timer = nextFire;

    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            fire();
            timer = 5f;
        }
        
    }

    void fire()
    {
        //gameObject.GetComponent<BoxCollider2D>().enabled = false;
        transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(transform.up * force, ForceMode2D.Impulse);
        transform.GetChild(1).GetComponent<Rigidbody2D>().AddForce(transform.up * -force, ForceMode2D.Impulse);
        transform.GetChild(2).GetComponent<Rigidbody2D>().AddForce(transform.right * force, ForceMode2D.Impulse);
        transform.GetChild(3).GetComponent<Rigidbody2D>().AddForce(transform.right * -force, ForceMode2D.Impulse);

    }
}
