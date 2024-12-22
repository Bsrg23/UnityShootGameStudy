using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject prefab_to_spawn;//    刷新预制体
    public float repeatInterval;//   刷新时间间隔

    //  根据时间间隔调用刷新怪物时间
    void Start()
    {
        if (repeatInterval > 0)
            InvokeRepeating("SpawnObject",0,repeatInterval);
    }

    //  刷新怪物
    void SpawnObject()
    {
        if(prefab_to_spawn != null)
        {
            Instantiate(prefab_to_spawn,transform.position, Quaternion.identity);
        }
    }
}
