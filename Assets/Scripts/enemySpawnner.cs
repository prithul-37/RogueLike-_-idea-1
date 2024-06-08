using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemySpawnner : MonoBehaviour
{
    public int enemyRate;
    public GameObject enemy;

    private void Start()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
        StartCoroutine(spawnEnemy());
    }
    IEnumerator spawnEnemy()
    {
        WaitForSeconds wait = new WaitForSeconds((float)60 / enemyRate);

        while (true)
        {
            yield return wait;
            Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }
}
