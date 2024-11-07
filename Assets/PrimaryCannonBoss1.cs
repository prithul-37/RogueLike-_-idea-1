using UnityEngine;
using UnityEngine.Windows.WebCam;

namespace PrimaryCannonBoss1
{
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

        Vector2 cannonInitialPos;
        Vector2 cannonEndPosition;
        float timer = 0;
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
            switch (primaryCannonState)
            {   
                
                case (PrimaryCannonState.Load):
                    rb.velocity = (Vector2)Cannon.transform.up * 1f/cannonLoadHideTime;
                    if (timer > cannonLoadHideTime)
                    {   
                        rb.velocity = Vector2.zero;
                        timer = 0;
                        primaryCannonState = PrimaryCannonState.Fire;
                        cannonEndPosition = Cannon.transform.position;
                    }

                    break;

                case (PrimaryCannonState.Fire):

                    //aim at player
                    Vector3 dir = player.transform.position - gameObject.transform.position;
                    dir = dir.normalized;

                    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90 - 360;
                    Debug.Log(angle);
                    angle = Mathf.Clamp(angle,-210,-150);
                    rb.rotation = angle;

                    //fire bullet
                    if (ready)
                    {
                        //Instantiate(bullet, Firepoint.position, Quaternion.identity);
                        ready = false;
                    }

                    //animation
                    if (!ready)
                    {
                        if(timer < cannonFireDelay / 2)
                        {
                            rb.velocity = -(Vector2)Cannon.transform.up * 1f / cannonLoadHideTime;
                        }
                        else
                        {
                            rb.velocity = (Vector2)Cannon.transform.up * 1f / cannonLoadHideTime;
                        }
                        if(timer > cannonFireDelay)
                        {
                            rb.velocity = Vector2.zero;
                            Cannon.transform.position = cannonEndPosition;
                            timer = 0;
                            ready = true;
                        }
                    }


                    if (timer > cannonFireTime)
                    {
                        timer = 0;
                        primaryCannonState = PrimaryCannonState.Hide;
                    }

                    break;

                case (PrimaryCannonState.Hide):

                    break;
            }
        }
    }

    enum PrimaryCannonState
    {
        Load,
        Fire,
        Hide
    }

}

