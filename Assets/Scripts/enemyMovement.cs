using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{

    private Transform tf;
    public Rigidbody2D rb;
    
    private Vector3 currPos;
    private Vector3 target;
    private Vector3 viewDir;

    // Start is called before the first frame update
    void Start()
    {

       tf =  GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(tf.position);
        //print(transform.position);
    }

    private void FixedUpdate()
    {   currPos = rb.position; 
        target = Vector3.MoveTowards(currPos,tf.position,(float)2.0* Time.deltaTime);

        viewDir = tf.position - currPos;
        float angle = Mathf.Atan2(viewDir.y, viewDir.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;
        rb.MovePosition(target);
        
    }
}
