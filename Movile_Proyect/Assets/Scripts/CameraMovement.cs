using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
  Transform player;

    private void Start()
    {
        player = GameManager.instance.Player.transform;
    }
    void LateUpdate()
    {
        transform.position = player.position;
    }
}
