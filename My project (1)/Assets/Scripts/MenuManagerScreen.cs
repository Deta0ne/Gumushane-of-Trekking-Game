using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagerScreen : MonoBehaviour
{
    public GameObject dataBoard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }
    public void creditButton()
    {
        SceneManager.LoadScene(5);
    }
    public void menuButton()
    {
        SceneManager.LoadScene(0);
    }
    public void DataBoardButton()
    {
        DataManager.Instance.LoadData();

        dataBoard.transform.GetChild(1).GetComponent<Text>().text = "Total Bullet Shot : " + DataManager.Instance.totalShotBullet.ToString();
        dataBoard.transform.GetChild(2).GetComponent<Text>().text = "Total Enemey Killed : " + DataManager.Instance.totalEnemyKilled.ToString();
        dataBoard.SetActive(true);
    }

    public void XButton()
    {
        dataBoard.SetActive(false);
    }
    
}
