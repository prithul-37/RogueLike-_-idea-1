using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    private GameObject player;
    public Rigidbody2D rb;
    public float speed;

    Vector3 currPos;
    Vector3 target;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {   
        currPos = rb.position;
        target = Vector3.MoveTowards(currPos, player.transform.position, (float)speed * Time.deltaTime); //Form,to,distance
        rb.MovePosition(target);
    }
}
