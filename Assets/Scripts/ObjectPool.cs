﻿using UnityEngine;
using System.Collections.Generic;

public class ObjectPool:MonoBehaviour
{
    public GameObject prefab;
    public int initailSize;

    private Queue<GameObject> m_pool = new Queue<GameObject>();

    void Awake()
    {
        for (int cnt = 0; cnt < initailSize; cnt++)
        {
            GameObject go = Instantiate(prefab) as GameObject;
            m_pool.Enqueue(go); go.SetActive(false);
        }
    }

    public void ReUse(Vector3 position, Quaternion rotation)
    {
        if (m_pool.Count > 0)
        {
            GameObject reuse = m_pool.Dequeue();
            reuse.transform.position = position;
            reuse.transform.rotation = rotation;
            reuse.SetActive(true);
            OnReUse(reuse);

        }
        else
        {
            GameObject go = Instantiate(prefab) as GameObject;
            go.transform.position = position;
            go.transform.rotation = rotation;
            OnReUse(go);
        }
    }

    public virtual void OnReUse(GameObject obj)
    {
       
    }


    public void Recovery(GameObject recovery)
    {
        m_pool.Enqueue(recovery);
        recovery.SetActive(false);
    }
}