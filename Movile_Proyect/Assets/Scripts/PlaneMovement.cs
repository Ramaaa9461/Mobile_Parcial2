using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    [SerializeField] float velocity;
    public float Velocity
    {
        set { velocity = value; }
        get { return velocity; }
    }

    [SerializeField] float turningForce;
    public float TurningForce
    {
        set { turningForce = value; }
        get { return turningForce; }
    }

    Rigidbody2D rigidbody;

    void Awake()
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Turn();
    }

    void Turn()
    {
        float hor = Input.GetAxis("Horizontal");

        if (hor != 0)
        {
            float direction = hor * turningForce * Time.deltaTime;

            rigidbody.rotation = rigidbody.rotation - direction;
        }

        rigidbody.velocity = transform.up * velocity;
    }


}
