using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerBehaviour : MonoBehaviour
{

    PowerUp currentPowerUp;
    private void Start()
    {
        transform.SetParent(GameManager.instance.Player.transform);
    }
    void Update()
    {
        if (currentPowerUp != null)
        {
            Vector2 direction = currentPowerUp.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public void SetCurrentPowerUp(PowerUp newPowerUpFollow)
    {
        currentPowerUp = newPowerUpFollow;
    }
}
