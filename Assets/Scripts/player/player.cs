using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player : MonoBehaviour
{
    public float health;
    public float currhealth;

    public float speed;
    
    public int XP;
    public int level = 0;
    private int nextLevel = 50;

    public int damage = 20;

    private GameObject FirePoint;
    public GameObject floatingText;

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
            GameObject gg = Instantiate(floatingText,transform.position,Quaternion.identity);
            gg.GetComponent<TextMeshPro>().SetText("Level"+level.ToString());
            XP -= nextLevel;
            nextLevel += 20;

            speed += .1f;
            speed = Mathf.Clamp(speed,4,10);

            if (level % 10 == 0)
            {
                damage += 3;
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
        print("Cloide with enemy...!");
    }
}
