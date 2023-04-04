using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerInGame : MonoBehaviour
{

    public GameObject ÝnGameScreen, pauseScreen;                               //***


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PauseButton()
    {
        Time.timeScale = 0;
        ÝnGameScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }

    public void PlayButton()
    {
        
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        ÝnGameScreen.SetActive(true);
    }

    public void RePlayButton()
    {
        DataManager.enemyKilled = 0;
        DataManager.sayac = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void HomeButton()
    {
        Time.timeScale = 1;
        DataManager.Instance.SaveData();
        SceneManager.LoadScene(0);
    }

}
