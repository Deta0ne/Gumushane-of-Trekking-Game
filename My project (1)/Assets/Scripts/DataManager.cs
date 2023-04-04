using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{

    public static DataManager Instance;
    public static int sayac = 0;
    private int shotBullet;
    public int totalShotBullet;
    public static int enemyKilled;
    public int totalEnemyKilled;

    EasyFileSave myFile;


    // Start is called before the first frame update
    void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            StartProcess();
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int ShotBullet
    {
        get
        {
            return shotBullet;
        }
        set
        {
            shotBullet = value;
            GameObject.Find("Fýrlatýlan Bullet").GetComponent<Text>().text = "Fýrlatýlan Bullet : " + shotBullet.ToString();
        }
    }

    public int EnemyKilled
    {
        get
        {
            return enemyKilled;
        }
        set
        {
            enemyKilled = value;
            GameObject.Find("Öldürülen Düþman").GetComponent<Text>().text = "Öldürülen Düþman : " + enemyKilled.ToString();
            WinProcess();
        }
    }

    void StartProcess()
    {
       
        myFile = new EasyFileSave();
        LoadData();
    }

    public void SaveData()
    {
        totalShotBullet += shotBullet;
        totalEnemyKilled += enemyKilled;

        myFile.Add("totalShotBullet", totalShotBullet);
        myFile.Add("totalEnemyKilled", totalEnemyKilled);

        myFile.Save();

    }

    public void LoadData()
    {
        if (myFile.Load())
        {
            totalShotBullet = myFile.GetInt("totalShotBullet");
            totalEnemyKilled = myFile.GetInt("totalEnemyKilled");
        }
    }

    public void WinProcess()
    {

        if (enemyKilled >= 10 && sayac == 0)
        {
            print("KAZANDINIZ !!!");
            sayac = 1;
            sceneTwo();
            enemyKilled = 0;
            

        }
        if (enemyKilled > 10 && sayac == 1)
        {
            enemyKilled = 0;
            sayac = 0;
            winScene();
        }


    }

    public void LoseProcess()
    {
        enemyKilled = 0;
        sayac = 0;
        shotBullet = 0;
        print("KAYBETTÝNÝZ !!!");
        deathScene();


    }
    void sceneTwo()
    {
       
        SceneManager.LoadScene(2);
       
    }
    void deathScene()
    {
        SceneManager.LoadScene(3);
    }
    void winScene()
    {
        SceneManager.LoadScene(4);
    }
}
