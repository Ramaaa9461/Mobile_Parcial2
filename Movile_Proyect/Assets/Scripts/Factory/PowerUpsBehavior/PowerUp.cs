using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] string id;

    public string Id => id;

    public abstract void Effect(GameObject _gameObject);

}
