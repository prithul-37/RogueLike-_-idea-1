using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{

    private Transform tf;
    public Rigidbody2D rb;
    public float MoveSpeed;
    
    private Vector3 currPos;
    private Vector3 target;
    private Vector3 viewDir;

    // Start is called before the first frame update
    void Start()
    {
       tf =  GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    private void FixedUpdate()
    {   currPos = rb.position; 
        target = Vector3.MoveTowards(currPos,tf.position,MoveSpeed* Time.deltaTime);

        viewDir = tf.position - currPos;
        float angle = Mathf.Atan2(viewDir.y, viewDir.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;
        rb.MovePosition(target);
        
    }
}
