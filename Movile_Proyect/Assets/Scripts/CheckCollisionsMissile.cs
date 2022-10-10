using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisionsMissile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Missile"))
        {
            gameObject.GetComponent<MyObject>().Recycle();
            collision.GetComponent<MyObject>().Recycle();
        }
    }
}
