using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public int damage = 20;
    private float timer = 0;
    public float lifeTime = 4.0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1.0f) { Destroy(gameObject); }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<enemy>().Damage(damage);
            Destroy(gameObject);
        }
    }
}
