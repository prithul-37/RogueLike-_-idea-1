using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyBullet2 : MonoBehaviour
{
    [SerializeField] Bullet bullet;
    [SerializeField] float BulletLifeTime;
    [SerializeField] float Phase1Time;
    [SerializeField] float Phase1force;
    [SerializeField] float Phase2force;
    [SerializeField] Transform tr;
    Rigidbody2D rb;
    float timer;
    bool once = true;
    Vector3 dir;
    Vector2 Phase1MaxValocity;

    private void Start()
    {
        timer = 0f;
        rb = GetComponent<Rigidbody2D>();
        dir = tr.up;

        GetComponent<SpriteRenderer>().color = bullet.Color;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        rb.AddForce(dir * Phase1force, ForceMode2D.Impulse);
        Phase1MaxValocity = rb.velocity;
    }


    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > BulletLifeTime)
        {
            Destroy(gameObject);
        }
        else if (timer > Phase1Time && once)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(dir * Phase2force, ForceMode2D.Impulse);
            once = false;
        }

        else if (Phase1Time > timer)
        {
            rb.velocity = Vector2.Lerp(Phase1MaxValocity, Vector2.zero, timer / Phase1Time);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.GetComponent<Player>().Death();
            Destroy(gameObject);
        }
    }

    public void SetSourceTransform(Transform t)
    {
        tr = t; 
    }

}
