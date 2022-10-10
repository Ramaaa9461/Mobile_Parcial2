using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Custom/Power up configuration")]
public class PowerUpConfiguration : ScriptableObject
{
    [SerializeField] PowerUp[] powerUps;
    Dictionary<string, PowerUp> idToPowerUp;

    private void Awake()
    {
        idToPowerUp = new Dictionary<string, PowerUp>();

        foreach (PowerUp powerUp in powerUps)
        {
            idToPowerUp.Add(powerUp.Id, powerUp);
        }
    }

    public PowerUp GetPowerUpPrefabById(string id)
    {
        PowerUp powerUp;

        if (!idToPowerUp.TryGetValue(id, out powerUp))
        {
            Debug.Log("No encontro el Power Up");
        }

        return powerUp;
    }
}
