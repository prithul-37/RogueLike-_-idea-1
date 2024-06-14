using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
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

    public void addXP(int x)
    {
        XP += x;
        

        if (XP > nextLevel)
        {
            level++;
            GameObject.FindGameObjectWithTag("spawner").GetComponent<Difficulty>().increaseDifficulty();

            GameObject gg = Instantiate(floatingText,transform.position,Quaternion.identity);
            gg.GetComponent<TextMeshPro>().SetText("Level"+level.ToString());
            XP -= nextLevel;
            nextLevel += 20;

            speed += .1f;
            speed = Mathf.Clamp(speed,4,10);

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
                FirePoint.GetComponent<fireBullet>().incBulletForce();
            }
        }
    }

    public void death()
    {   
        time = Time.time - time;
        score += (int)time * 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
