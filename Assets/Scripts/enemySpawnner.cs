using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemySpawnner : MonoBehaviour
{

    public GameObject[] enemy;


    public float min = 2f;
    public float max = 5f;
    private float nextSpawn; 
    public bool iniitialSpawn = false;

    private void Start()
    {   
        nextSpawn = Random.Range(min, max);
        if(iniitialSpawn)
            Instantiate(enemy[Random.Range(0,enemy.Length)],transform.position,Quaternion.identity);
    }

    private void Update()
    {
        nextSpawn -= Time.deltaTime;
        if (nextSpawn <= 0) {
            nextSpawn = Random.Range(min, max);
            Instantiate(enemy[Random.Range(0, enemy.Length)], transform.position, Quaternion.identity);
        }
    }

}
