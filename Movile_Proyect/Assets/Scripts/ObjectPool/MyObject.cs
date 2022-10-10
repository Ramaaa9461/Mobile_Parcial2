using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyObject : RecyclableObject
{

    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;
    [Space]
    [SerializeField] float minTurningSpeed;
    [SerializeField] float maxTurningSpeed;


    internal override void Init()
    {
        MissileBehavior missileBehavior;

        missileBehavior = gameObject.GetComponent<MissileBehavior>();
        missileBehavior.SetSpeed(Random.Range(minSpeed, maxSpeed));
        missileBehavior.SetTurningSpeed(Random.Range(minTurningSpeed, maxTurningSpeed));
        missileBehavior.SetPlayer(GameManager.instance.Player.transform);

        transform.position = GameManager.instance.GetRandomSpawnposition();
    }

    internal override void Release()
    {
        GameManager.instance.ReSpawnMissile();
    }


}
