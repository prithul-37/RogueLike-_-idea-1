using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour
{

    public Transform target;

    public float speed = 5f;
    public float rotateSpeed = 200f;

    private Rigidbody2D rb;
    public LayerMask targetMask;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FindTarget();
    }

    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * speed;
    }


    void FindTarget()
    {
        // Detect potential targets within a radius
        Collider2D collider = Physics2D.OverlapCircle(transform.position, 50, targetMask);

        if (collider != null)
        {
            target = collider.transform; // Assign the detected target
        }
    }
    void OnTriggerEnter2D()
    {
        Debug.Log("hitting");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Put a particle effect here
        Debug.Log("hitting");
        //Destroy(gameObject);

    }
}