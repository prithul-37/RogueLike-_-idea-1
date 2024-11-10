using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    
    private GameObject player;
    private Rigidbody2D rb;
    public GameObject bullet;
        
    

    private Vector3 currPos;
    private Vector3 target = new Vector3(-10,5,0);
    private Vector3 viewDir;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(shoot());
    }

    private void FixedUpdate()
    {
        currPos = rb.position;
        viewDir = player.transform.position - currPos;
        float angle = Mathf.Atan2(viewDir.y, viewDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        

    }

    IEnumerator shoot()
    {
        WaitForSeconds wait = new WaitForSeconds((float)60 / 60);
        while (true)
        {
            yield return wait;
            GameObject GG = Instantiate(bullet, transform.position, Quaternion.identity);
            GG.GetComponent<EnemyBullet>().ShootAtPlayer();
        }

    }

    
}
