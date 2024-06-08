using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float health;
    public float speed;
    public float currhealth;
    public int XP;
    public int level = 0;
    private int nextLevel = 50;
    private GameObject FirePoint;

    void Start()
    {
        FirePoint = gameObject.transform.GetChild(0).gameObject;
    }

    public void addXP(int x)
    {
        XP += x;

        if (XP > nextLevel)
        {
            level++;
            XP -= nextLevel;
            nextLevel += 20;
            if (level % 10 == 0)
            {
               
            }
            else if (level % 3 == 0)
            {
                FirePoint.GetComponent<fireBullet>().incFireRate();
            }
            else if (level % 2 == 0)
            {
                FirePoint.GetComponent<fireBullet>().incBulletForce();
            }
        }
    }
}
