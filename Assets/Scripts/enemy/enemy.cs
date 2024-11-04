using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public int resistance = 5;
    public int enemyMaxHealth = 100;
    public int xpWillGive = 10;
    public int Score = 10;

    public GameObject XP;
    private GameObject Player;

    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = enemyMaxHealth;
        XP.GetComponent<XP>().xp = xpWillGive;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Damage(int x, Vector3 pos)
    {
        PopUpText.Create((x - resistance).ToString(), pos, Color.white);
        currentHealth -= (x - resistance);
        if (currentHealth <= 0)
        {
            global::Player.score += Score;
            GameObject xp = Instantiate(XP, transform.position, Quaternion.identity);
            xp.GetComponent<XP>().xp = xpWillGive;
            Destroy(gameObject);
        }
        //print(currentHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.GetComponent<Player>().death();
        }
    }
}
