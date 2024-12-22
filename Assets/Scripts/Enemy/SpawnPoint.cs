using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject prefab_to_spawn;//    ˢ��Ԥ����
    public float repeatInterval;//   ˢ��ʱ����

    //  ����ʱ��������ˢ�¹���ʱ��
    void Start()
    {
        if (repeatInterval > 0)
            InvokeRepeating("SpawnObject",0,repeatInterval);
    }

    //  ˢ�¹���
    void SpawnObject()
    {
        if(prefab_to_spawn != null)
        {
            Instantiate(prefab_to_spawn,transform.position, Quaternion.identity);
        }
    }
}
