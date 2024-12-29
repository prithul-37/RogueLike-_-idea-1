using UnityEngine;

public class HomingMissile : MonoBehaviour
{

    public Transform target;

    public float speed = 5f;
    public float rotateSpeed = 200f;

    private Rigidbody2D rb;
    public LayerMask targetMask;
    public GameObject hitAnimationObj;

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

        DetectObjectsInRange();
    }


    void DetectObjectsInRange()
    {
        // Check if there is any collider within the detection circle
        Collider2D detectedObject = Physics2D.OverlapCircle(transform.position, .1f, targetMask);

        if (detectedObject != null)
        {
            Debug.Log($"Detected object: {detectedObject.name}");
            Instantiate(hitAnimationObj, new Vector3(transform.position.x, transform.position.y, -.2f), Quaternion.identity);
            Destroy(gameObject);
        }
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


}