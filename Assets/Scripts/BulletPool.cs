using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject prefab;
    public int maxPoolSize = 20;
    public int startPoolSize = 10;
    private Queue<GameObject> pool;

    void Awake()
    {
        pool = new Queue<GameObject>();
        for (int i = 0; i < startPoolSize; i++)
        {
            CreateNewObject();
        }
    }

    private GameObject CreateNewObject()
    {
        GameObject obj = Instantiate(prefab);
        obj.SetActive(false);
        pool.Enqueue(obj);
        return obj;
    }

    public GameObject TryGetFromPool()
    {
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else if (pool.Count < maxPoolSize)
        {
            return CreateNewObject();
        }
        return null;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}
