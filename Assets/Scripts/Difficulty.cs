using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    private int totalLVL;
    private List<int> a = new List<int>();


    // Start is called before the first frame update
    void Start()
    {
        totalLVL = transform.childCount;

        for(int i = 0; i < totalLVL; i++)
        {
            a.Add(i);
        }

        int x = Random.Range(0, totalLVL);

        gameObject.transform.GetChild(x).gameObject.SetActive(true);
        a.Remove(x);

    }

    // Update is called once per frame
    public void increaseDifficulty()
    {
        int x = Random.Range(0, a.Count);
        gameObject.transform.GetChild(a[x]).gameObject.SetActive(true);
        a.Remove(a[x]);
    }
}
