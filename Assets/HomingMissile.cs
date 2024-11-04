using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    Transform target; // The object to home in on
    public float speed = 10f; // Speed of the missile
    public float rotationSpeed = 5f; // Rotation speed (how fast it turns to target)
    public float destroyDistance = 0.5f; // Distance at which the missile destroys itself

    public LayerMask mask;
    public float Redius;

    public int Damage;


    Homing_Missile_State state;

    private void Start()
    {
        state = Homing_Missile_State.Finding;
    }

    void Update()
    {   
        if (state == Homing_Missile_State.Finding)
        {   

            var colider = Physics2D.OverlapCircle(transform.position, Redius, mask);
            target = colider.transform;
            state = Homing_Missile_State.Follow;

        }

        if (state == Homing_Missile_State.Follow)
        {
            // Calculate the direction towards the target
            Vector3 direction = (target.position - transform.position).normalized;

            // Rotate gradually towards the target direction
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Move forward in the direction it’s facing
            transform.position += transform.forward * speed * Time.deltaTime;

            // Check if close enough to the target to destroy itself
            if (Vector3.Distance(transform.position, target.position) < destroyDistance)
            {
                Destroy(gameObject); // Destroy the missile
                target.GetComponent<Enemy>().Damage(Damage,transform.position);

            }
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(transform.position, Redius);
    //}
}

public enum Homing_Missile_State
{

    Finding,
    Follow

}

