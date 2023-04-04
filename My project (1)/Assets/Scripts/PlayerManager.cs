using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class PlayerManager : MonoBehaviour
{

    public int score;
    public TextMeshProUGUI playerScoreText;


    public float health, bulletSpeed;

    public bool dead = false;

    Transform muzzle;
    public Transform bullet, floatingText, bloodParticle;

    public Slider slider;

    bool mouseIsNotOverUI;

    // Start is called before the first frame update
    void Start()
    {

        score = 0;
        muzzle = transform.GetChild(1);
        slider.maxValue = health;
        slider.value = health;

    }

    // Update is called once per frame
    void Update()
    {

        playerScoreText.text = score.ToString();
        mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;

        if (Input.GetMouseButtonUp(0))
        {
            ShootBullet();
        }

    }

    public void GetDamage(float damage)
    {
        Instantiate(floatingText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text = damage.ToString();



        if ((health - damage) >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        slider.value = health;
        AmIDead();


    }



    void AmIDead()
    {


        if (health <= 0)
        {
            Destroy(Instantiate(bloodParticle, transform.position, Quaternion.identity), 1f);
            DataManager.Instance.LoseProcess();
            dead = true;
            Destroy(gameObject);
        }


    }


    void ShootBullet()
    {
        Transform tempBullet;
        tempBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);
        DataManager.Instance.ShotBullet++;
    }

}
