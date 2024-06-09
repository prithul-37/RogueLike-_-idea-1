using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2Movement : MonoBehaviour
{
    //public GameObject bullet;
    private GameObject player;
    private Rigidbody2D rb;
    public GameObject bullet;

    public float MoveSpeed;

    private Vector3 currPos;
    private Vector3 target = new Vector3(-10,5,0);
    private Vector3 viewDir;
    private bool inPos;
    private bool goRight = true;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
        //print("OK");
        if(rb.position.x == target.x && rb.position.y == target.y) inPos = true;
        else inPos = false;
        StartCoroutine(shoot());
    }

    private void FixedUpdate()
    {
        if (rb.position.x == target.x && rb.position.y == target.y) inPos = true;
        currPos = rb.position;
        viewDir = player.transform.position - currPos;
        float angle = Mathf.Atan2(viewDir.y, viewDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        if (!inPos)
        {
            Vector3 move = Vector3.MoveTowards(currPos, target, MoveSpeed * Time.deltaTime);
            rb.MovePosition(move);
        }
        else {
            if (goRight) {
                Vector3 move = Vector3.MoveTowards(currPos, new Vector3(10,target.y,0), MoveSpeed * Time.deltaTime);
                rb.MovePosition(move);
                if(rb.position.x > 9) goRight = false;
            }
            else if(!goRight)
            {
                Vector3 move = Vector3.MoveTowards(currPos, target, MoveSpeed * Time.deltaTime);
                rb.MovePosition(move);
                if(rb.position.x <-9) goRight = true;
            }
        }

    }

    IEnumerator shoot()
    {
        WaitForSeconds wait = new WaitForSeconds((float)60 / 60);
        while (true)
        {
            yield return wait;
            GameObject GG = Instantiate(bullet, transform.position, Quaternion.identity); 
        }

    }

}
