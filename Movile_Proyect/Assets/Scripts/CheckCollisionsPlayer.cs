using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisionsPlayer : MonoBehaviour
{
    PlayerStats playerStats;

    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Missile"))
        {
            collision.GetComponent<MyObject>().Recycle();

            playerStats.SubtractLife();            
            //Hago las coasas del player, le saco vida o lo destruyo.
        }
        else if(collision.CompareTag("PowerUp"))
        {
            collision.GetComponent<PowerUp>().Effect(gameObject);
        }
    }

}
