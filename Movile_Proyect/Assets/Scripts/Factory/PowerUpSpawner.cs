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

    public void SpawnRandomPowerUp()
    {
        spawPosition = GameManager.instance.GetRandomSpawnposition();

        powerUpFactory.Create(PowerUpsID[Random.Range(0, PowerUpsID.Length)].ToString(), spawPosition);
    }
}