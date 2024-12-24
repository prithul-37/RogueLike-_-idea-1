using System.Collections;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public int id;
    public string name;
    public GameObject[] enemyList;
    public int enemyCount;
    public float rate;

}

public class WaveManager : MonoBehaviour
{
    public Wave[] wave;
    public int currentWave;

    public float waveGap;

    private float waveTimer;
    private float enemyTimer;
    private bool canSpawn;
    private bool waveEnd;
    private int spawanPosCount;

    private int currentEnemy = 0;


    private void Start()
    {
        currentEnemy = 0;
        waveTimer = waveGap;
        currentWave = 0;
        canSpawn = true;
        spawanPosCount = gameObject.transform.childCount;
        waveEnd = false;
        Random.InitState((int)Time.time * 1000);
    }

    private void Update()
    {
        enemyTimer -= Time.deltaTime;
        waveTimer -= Time.deltaTime;
        if (enemyTimer < 0 && !waveEnd)
        {

            if (currentEnemy < wave[currentWave].enemyCount && canSpawn)
            {
                spawn();
                enemyTimer = 1 / wave[currentWave].rate;
            }
            else if (currentEnemy == wave[currentWave].enemyCount)
            {
                canSpawn = false;
                waveEnd = true;
                waveTimer = waveGap;
                currentWave++;
            }

        }

        else if (waveEnd && waveTimer < 0 && currentWave < wave.Length)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            currentEnemy = enemies.Length;
            if (currentEnemy == 0)
            {
                StartCoroutine(waitNextWave());
            }
        }
    }

    void spawn()
    {
        Instantiate(wave[currentWave].enemyList[Random.Range(0, wave[currentWave].enemyList.Length)],
                    transform.GetChild(Random.Range(0, spawanPosCount)).transform.position,
                    Quaternion.identity);
        currentEnemy++;
    }

    IEnumerator waitNextWave()
    {
        yield return new WaitForSeconds(waveGap);

        canSpawn = true;
        enemyTimer = 1 / wave[currentWave].rate;
        currentEnemy = 0;
        waveEnd = false;
    }
}
