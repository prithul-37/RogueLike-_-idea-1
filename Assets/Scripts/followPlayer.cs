using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    private GameObject player;
    public Rigidbody2D rb;

    Vector3 currPos;
    Vector3 target;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {   
        currPos = rb.position;
        target = Vector3.MoveTowards(currPos, player.transform.position, (float)3.0f * Time.deltaTime); //Form,to,distance
        rb.MovePosition(target);
    }
}
