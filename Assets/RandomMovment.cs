using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    [Header("Movement Area")]
    public Vector2 movementBoundsMin; // Minimum bounds for movement (x, y)
    public Vector2 movementBoundsMax; // Maximum bounds for movement (x, y)

    [Header("Movement Settings")]
    public float movementSpeed = 3f;     // Speed of the boss movement
    public float movementChangeInterval = 2f; // How often to pick a new random target position

    private Vector2 targetPosition;      // Current random target position
    private float movementTimer;         // Timer to track movement change
    Boss1 boss1;

    void Start()
    {
        // Pick an initial random target position
        PickRandomTargetPosition();
        boss1 = GetComponent<Boss1>();
    }

    void Update()
    {
        if (boss1.GetCurrentBossState() != Boss1.BossState.PrimaryCannonAttack)
        {// Move the boss towards the target position
            MoveTowardsTarget();
        }

        // Update the timer and pick a new target position if needed
        movementTimer -= Time.deltaTime;
        if (movementTimer <= 0)
        {
            PickRandomTargetPosition();
        }
    }

    void MoveTowardsTarget()
    {
        // Smoothly move the boss towards the target position
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
    }

    void PickRandomTargetPosition()
    {
        // Pick a new random position within the movement bounds
        float randomX = Random.Range(movementBoundsMin.x, movementBoundsMax.x);
        float randomY = Random.Range(movementBoundsMin.y, movementBoundsMax.y);
        targetPosition = new Vector2(randomX, randomY);

        // Reset the movement timer
        movementTimer = movementChangeInterval;
    }

    // Optional: Visualize the movement area in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube((movementBoundsMin + movementBoundsMax) / 2, movementBoundsMax - movementBoundsMin);
    }
}
