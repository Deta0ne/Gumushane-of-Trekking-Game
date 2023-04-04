using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            PlayerManager player = collision.gameObject.GetComponent<PlayerManager>();
            player.score += 1;
            gameObject.SetActive(false);  //checkboolsýný gorünmez yapar (destroy)
        }
    }
}
