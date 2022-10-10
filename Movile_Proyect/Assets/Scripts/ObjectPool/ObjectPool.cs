using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private readonly RecyclableObject prefab;
    private readonly HashSet<RecyclableObject> instantiateObjects;
    private Queue<RecyclableObject> recyclableObjects;

    public ObjectPool(RecyclableObject prefab)
    {
        this.prefab = prefab;
        instantiateObjects = new HashSet<RecyclableObject>();
    }

    public void Init(int numberOfInitialObjects)
    {
        recyclableObjects = new Queue<RecyclableObject>(numberOfInitialObjects);

        for (int i = 0; i < numberOfInitialObjects; i++)
        {
            var instance = InstantiateNewInstance();
            instance.gameObject.SetActive(false);
            recyclableObjects.Enqueue(instance);
        }
    }

    private RecyclableObject InstantiateNewInstance()
    {
        var instance = Object.Instantiate(prefab); 
        instance.Configure(this);
        return instance;
    }

    public T Spawn<T>()
    {
        var recyclableObject = GetInstance();
        instantiateObjects.Add(recyclableObject);
        recyclableObject.gameObject.SetActive(true);
        recyclableObject.Init();
        return recyclableObject.GetComponent<T>();
    }

    private RecyclableObject GetInstance()
    {
        if (recyclableObjects.Count > 0)
        {
            return recyclableObjects.Dequeue();
        }

        var instance = InstantiateNewInstance();
        return instance;
    }

    public void RecycleGameObject(RecyclableObject gameObjectToRecycle)
    {
        gameObjectToRecycle.gameObject.SetActive(false);
        gameObjectToRecycle.Release();
        recyclableObjects.Enqueue(gameObjectToRecycle);
    }
}
