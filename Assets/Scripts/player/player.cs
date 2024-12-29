using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static int score = 0;

    public float health;
    public float currhealth;

    public float speed;

    public int XP;
    public int level = 0;
    private int nextLevel = 50;
    private float time;

    public int damage = 20;

    private GameObject FirePoint;
    public GameObject floatingText;

    void Start()
    {
        FirePoint = gameObject.transform.GetChild(0).gameObject;
        time = Time.time;

    }

    public void AddXP(int x)
    {
        XP += x;


        if (XP > nextLevel)
        {
            level++;

            PopUpText.Create("Level" + level.ToString(), transform.position, Color.white);
            XP -= nextLevel;
            nextLevel += 20;

            speed += .5f;
            speed = Mathf.Clamp(speed, 4, 15);

            if (level % 10 == 0)
            {
                damage += 5;
            }
            if (level % 3 == 0)
            {
                FirePoint.GetComponent<fireBullet>().incFireRate();
            }
            if (level % 2 == 0)
            {
                FirePoint.GetComponent<fireBullet>().IncBulletForce();
            }
        }
    }

    public void Death()
    {
        time = Time.time - time;
        score += (int)time * 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
    }
}
