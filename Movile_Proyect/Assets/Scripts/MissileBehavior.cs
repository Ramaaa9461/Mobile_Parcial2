using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehavior : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float turningSpeed;
    Transform player;

    Rigidbody2D rigidbody;
    Vector2 direction;

    void Awake()
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
        player = GameManager.instance.Player.transform;
    }

    void FixedUpdate()
    {
        GoToPlayer();
    }

    void GoToPlayer()
    {
        direction = (Vector2)player.position - rigidbody.position;
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rigidbody.angularVelocity = -rotateAmount * turningSpeed;

        rigidbody.velocity = transform.up * speed;
    }

    public void SetPlayer(Transform target)
    {
        player = target;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetTurningSpeed(float turningSpeed)
    {
        this.turningSpeed = turningSpeed;
    }
}
