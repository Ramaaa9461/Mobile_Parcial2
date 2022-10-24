using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : PowerUp
{
    PlaneMovement planeMovement;

    public override void Effect(GameObject _gameObject)
    {
        if (_gameObject.CompareTag("Player"))
        {
            planeMovement = _gameObject.GetComponent<PlaneMovement>();

            float normalVelocity = planeMovement.Velocity;
            float normalTurningForce = planeMovement.TurningForce;

            float powerUpVelocity = normalVelocity + (normalVelocity / 2);
            float powerUpTurningForce = normalTurningForce + (normalTurningForce / 2);

            planeMovement.Velocity = powerUpVelocity;
            planeMovement.TurningForce = powerUpTurningForce;

            transform.position = new Vector3(10000, 10000);
            StartCoroutine(PowerUpDuration(planeMovement, normalVelocity, normalTurningForce));
        }
        GameManager.instance.SpawnRandomPowerUp();
    }

    IEnumerator PowerUpDuration(PlaneMovement planeMovement, float normalVelocity, float normalTurningForce)
    {
        yield return new WaitForSeconds(3);
        planeMovement.Velocity = normalVelocity;
        planeMovement.TurningForce = normalTurningForce;
        Destroy(gameObject);
    }
}
