using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMenu : MonoBehaviour
{
    public GameObject Text;

    private void Start()
    {
        if(Text != null)
        {   
            
            string show = "Your Score is:" + player.score.ToString();
            Text.GetComponent<TextMeshProUGUI>().text = show;


        }
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void close()
    {
        Application.Quit();
    }
}
