using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyEnemyMovement : MonoBehaviour
{
    private GameObject player;//    ���
    private NavMeshAgent agent;//   AI�������
    
    private MyEnemyHealth MyEnemyHealth;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");//  ���ݱ�ǩ�����Ҷ���
        agent = GetComponent<NavMeshAgent>();// ��ȡ AI�������

        MyEnemyHealth = GetComponent<MyEnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        //  �ж��Ƿ����� û���͵���Ŀ��
        if(!MyEnemyHealth.isDeath)
        {
            //  ���õ����ص�
            agent.SetDestination(player.transform.position);
        }

    }
}
