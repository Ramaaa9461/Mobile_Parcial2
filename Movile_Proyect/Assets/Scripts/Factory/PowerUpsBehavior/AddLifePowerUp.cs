using UnityEngine;

public class AddLifePowerUp : PowerUp
{
    public override void Effect(GameObject _gameObject)
    {

        _gameObject.GetComponent<PlayerStats>().AddLife();

        Destroy(gameObject);
        GameManager.instance.SpawnRandomPowerUp();
    }
}
