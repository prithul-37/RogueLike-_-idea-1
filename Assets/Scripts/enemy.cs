using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enemy : MonoBehaviour
{   
    public int resistance = 5;
    public int enemyMaxHealth = 100;
    public int xpWillGive = 10;
    public GameObject XP;
    public GameObject floatingText;

    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = enemyMaxHealth;
        XP.GetComponent<XP>().xp = xpWillGive;
    }

    public void Damage(int x)
    {   

        GameObject gg = Instantiate(floatingText,transform.position,Quaternion.identity);
        gg.GetComponent<TextMeshPro>().SetText((x - resistance).ToString());
        currentHealth -= (x-resistance);
        if (currentHealth <= 0)
        {
            GameObject xp = Instantiate(XP, transform.position, Quaternion.identity);
            xp.GetComponent<XP>().xp = xpWillGive;
            Destroy(gameObject);
        }
        //print(currentHealth);
    }
}
