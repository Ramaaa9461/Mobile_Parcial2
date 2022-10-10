using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class PowerUpFactory
{
   private readonly PowerUpConfiguration powerUpConfiguration;

    public PowerUpFactory(PowerUpConfiguration powerUpConfiguration)
    {
        this.powerUpConfiguration = powerUpConfiguration;
    }

    public PowerUp Create(string id, Vector3 position)
    {
        PowerUp powerUp = powerUpConfiguration.GetPowerUpPrefabById(id);
        return Object.Instantiate(powerUp, position, Quaternion.identity);
    }

}
