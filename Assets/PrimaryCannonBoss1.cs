using UnityEngine;


public class PrimaryCannonBoss1 : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;

    [SerializeField] PrimaryCannonState primaryCannonState;
    [SerializeField] GameObject Cannon;
    [SerializeField] float cannonLoadHideTime;
    [SerializeField] float cannonFireTime;
    [SerializeField] float cannonFireDelay;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform Firepoint;
    [SerializeField] float detectionAngle = 90f;
    [SerializeField] float rotationSpeed = 5f;

    Vector2 cannonInitialPos;
    Vector2 cannonEndPosition;
    float timer = 0;
    float recoilTimer = 0;
    bool ready = true;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = Cannon.gameObject.GetComponent<Rigidbody2D>();
        cannonInitialPos = Cannon.transform.position;
    }


    private void Update()
    {

        timer += Time.deltaTime;
        recoilTimer += Time.deltaTime;
        switch (primaryCannonState)
        {

            case (PrimaryCannonState.Load):
                rb.velocity = (Vector2)Cannon.transform.up * 1f / cannonLoadHideTime;
                if (timer > cannonLoadHideTime)
                {
                    rb.velocity = Vector2.zero;
                    timer = 0;
                    primaryCannonState = PrimaryCannonState.Fire;
                    cannonEndPosition = Cannon.transform.position;
                }

                break;

            case (PrimaryCannonState.Fire):
                Vector3 fireDirection = AimTowardsPlayer();

                //fire bullet
                if (ready)
                {
                    Fire(fireDirection);
                }
                //recoil animation
                else if (!ready)
                {
                    RecoilAnimation();
                }

                if (timer > cannonFireTime)
                {
                    rb.velocity = Vector2.zero;
                    timer = 0;
                    primaryCannonState = PrimaryCannonState.Hide;
                }
                break;

            case (PrimaryCannonState.Hide):

                bool inPosition = Cannon.transform.rotation == transform.rotation;
                if (!inPosition)
                {
                    Quaternion smoothAngle = Quaternion.Lerp(Cannon.transform.rotation, transform.rotation, timer / 1f);
                    Cannon.transform.rotation = smoothAngle;
                }
                if (inPosition)
                {
                    rb.velocity = -(Vector2)Cannon.transform.up * 1f / cannonLoadHideTime;
                    if (timer > cannonLoadHideTime)
                    {
                        rb.velocity = Vector2.zero;
                        timer = 0;
                        primaryCannonState = PrimaryCannonState.Idle;
                    }
                }
                break;

            case (PrimaryCannonState.Idle):

                break;
        }
    }

    Vector3 AimTowardsPlayer()
    {

        Vector2 directionToPlayer = player.transform.position - transform.position;
        directionToPlayer.Normalize();
        float angleToPlayer = Vector2.Angle(transform.up, directionToPlayer);
        if (angleToPlayer <= detectionAngle / 2f)
        {

            float targetAngle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = targetAngle;
            return directionToPlayer;
        }

        return Cannon.transform.up;
    }

    void RecoilAnimation()
    {
        if (recoilTimer < cannonFireDelay / 2)
        {
            rb.velocity = -(Vector2)Cannon.transform.up * 1f / cannonLoadHideTime;
        }
        else
        {
            rb.velocity = (Vector2)Cannon.transform.up * 1f / cannonLoadHideTime;
        }
        if (recoilTimer > cannonFireDelay)
        {
            rb.velocity = Vector2.zero;
            Cannon.transform.position = cannonEndPosition;
            recoilTimer = 0;
            ready = true;
        }
    }

    void Fire(Vector3 dir)
    {
        var spawnnedBullet = Instantiate(bullet, Firepoint.position, Quaternion.identity);
        spawnnedBullet.GetComponent<EnemyBullet>().ShootAtDierctionGiven(dir);
        ready = false;
        recoilTimer = 0;
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize the detection cone in the editor
        Gizmos.color = Color.yellow;
        Vector3 leftBoundary = Quaternion.Euler(0, 0, -detectionAngle / 2f) * transform.up;
        Vector3 rightBoundary = Quaternion.Euler(0, 0, detectionAngle / 2f) * transform.up;

        Gizmos.DrawRay(transform.position, leftBoundary * 5f);
        Gizmos.DrawRay(transform.position, rightBoundary * 5f);
    }
}

enum PrimaryCannonState
{
    Load,
    Fire,
    Hide,
    Idle
}



