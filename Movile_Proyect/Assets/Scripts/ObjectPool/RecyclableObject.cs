using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RecyclableObject : MonoBehaviour
{

    ObjectPool objectPool;

    internal void Configure(ObjectPool objectPool)
    {
        this.objectPool = objectPool;
    }

    public void Recycle()
    {
        objectPool.RecycleGameObject(this);
    }


    internal abstract void Init();
    internal abstract void Release();

}
