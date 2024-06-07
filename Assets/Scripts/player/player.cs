using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float health;
    public float speed;
    public float currhealth;
    public float XP;
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addXP(int x)
    {
        XP += (float)x;
        print(XP);
    }
}
