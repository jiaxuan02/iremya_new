using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    public List<GameObject> PrefabsForPool;

    //List of the pooled objects
    private List<GameObject> _pooledObjects = new List<GameObject>();

    public GameObject GetObjectFromPool(string objectName)
    {
        //Try to get a pooled instance
        var instance = _pooledObjects.FirstOrDefault(obj => obj.name == objectName);

        //If pooled instance existed already
        if (instance != null)
        {
            _pooledObjects.Remove(instance);
            instance.SetActive(true);
            return instance;
        }

        //If there is no existing pooled instance
        var prefab = PrefabsForPool.FirstOrDefault(obj => obj.name == objectName);
        if (prefab != null)
        {
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, 0);
            var newInstance = Instantiate(prefab, newPosition, Quaternion.identity, transform);
            newInstance.name = objectName;
            return newInstance;
        }

        Debug.LogWarning("Object pool doesnt have a prefab for the object with name " + objectName);
        return null;
    }

    public void PoolObject(GameObject obj)
    {
        obj.SetActive(false);
        _pooledObjects.Add(obj);
    }
}
