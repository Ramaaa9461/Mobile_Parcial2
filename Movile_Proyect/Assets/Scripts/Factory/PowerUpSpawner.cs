using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] PowerUpConfiguration powerUpConfiguration;
    [SerializeField] string[] PowerUpsID;

    PowerUpFactory powerUpFactory;
    Vector3 spawPosition;

    private void Awake()
    {
        powerUpFactory = new PowerUpFactory(Instantiate(powerUpConfiguration));
    }

    public PowerUp SpawnRandomPowerUp()
    {
        spawPosition = GameManager.instance.GetRandomSpawnposition();

       return powerUpFactory.Create(PowerUpsID[Random.Range(0, PowerUpsID.Length)].ToString(), spawPosition);
    }
}