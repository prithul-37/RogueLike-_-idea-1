using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    
    private Vector2 mv;
    public Rigidbody2D rb;
    private float moveSpeed;
    public Camera cam;
    private Vector2 mousePos;
    private Vector2 viewDir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mv.x = Input.GetAxis("Horizontal");
        mv.y = Input.GetAxis("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        
    }

    private void FixedUpdate()
    {
        moveSpeed = gameObject.GetComponent<player>().speed;
        rb.MovePosition(rb.position + mv * moveSpeed * Time.deltaTime);
        viewDir = mousePos - rb.position;
        float angle = Mathf.Atan2(viewDir.y, viewDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
