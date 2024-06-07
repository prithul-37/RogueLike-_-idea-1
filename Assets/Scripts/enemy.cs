using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{   
    public int resistance = 5;
    public int enemyMaxHealth = 100;
    public GameObject XP;

    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = enemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Instantiate(XP,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void Damage(int x)
    {
        currentHealth -= (x-resistance);
        print(currentHealth);
    }
}
