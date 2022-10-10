using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPowerUp : PowerUp
{
    PlayerStats playerStats;

    public override void Effect(GameObject _gameObject)
    {
        if (_gameObject.CompareTag("Player"))
        {
            playerStats = _gameObject.GetComponent<PlayerStats>();

            playerStats.AddMoney(10);

            Destroy(gameObject);
        }
        GameManager.instance.SpawnRandomPowerUp();
    }

}
