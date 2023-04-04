using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus : MonoBehaviour
{
    Rigidbody2D Buss;


    void Start()
    {
     
        Buss = GetComponent<Rigidbody2D>();
     //   HorizontalMove();
    }

   
    void Update()
    {
        Buss.velocity = new Vector2(4,0);
    }

    void HorizontalMove()
    {

        //Buss.velocity = new Vector2(1);
    }

}
