using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float bulletForce;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();

        Vector3 dir = player.transform.position - gameObject.transform.position;
        dir = dir.normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        rb.AddForce(dir*bulletForce,ForceMode2D.Impulse);
        StartCoroutine(DestroyObject());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.GetComponent<Player>().death();
            Destroy(gameObject);
        }
    }

    private IEnumerator DestroyObject()
    {
        WaitForSeconds wait = new WaitForSeconds((float)3.0f);
        yield return wait;
        Destroy(gameObject);
    }

}
