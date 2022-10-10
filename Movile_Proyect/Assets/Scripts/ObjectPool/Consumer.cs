using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumer : MonoBehaviour
{

    [SerializeField] MyObject prefaf;
    ObjectPool objectPool;

    void Awake()
    {
        objectPool = new ObjectPool(prefaf);
        objectPool.Init(GameManager.instance.maxMissileInstance);

    }

    public void Spawn()
    {
        objectPool.Spawn<MyObject>();
    }


}
