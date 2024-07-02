using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enemy : MonoBehaviour
{   
    public int resistance = 5;
    public int enemyMaxHealth = 100;
    public int xpWillGive = 10;
    public int Score = 10;

    public GameObject XP;
    public GameObject floatingText;
    private GameObject Player;

    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = enemyMaxHealth;
        XP.GetComponent<XP>().xp = xpWillGive;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Damage(int x)
    {   

        GameObject gg = Instantiate(floatingText,transform.position,Quaternion.identity);
        Color color = gameObject.GetComponent<SpriteRenderer>().color;
        gg.GetComponent<TextMeshPro>().color = new Color(255 - color.r, 255 - color.r, 255 - color.b);
        gg.GetComponent<TextMeshPro>().SetText((x - resistance).ToString());
        currentHealth -= (x-resistance);
        if (currentHealth <= 0)
        {
            player.score += Score;
            GameObject xp = Instantiate(XP, transform.position, Quaternion.identity);
            xp.GetComponent<XP>().xp = xpWillGive;
            Destroy(gameObject);
        }
        //print(currentHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player.GetComponent<player>().death();
        }
    }
}
