using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyEnemyMovement : MonoBehaviour
{
    private GameObject player;//    玩家
    private NavMeshAgent agent;//   AI导航组件
    
    private MyEnemyHealth MyEnemyHealth;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");//  根据标签名查找对象
        agent = GetComponent<NavMeshAgent>();// 获取 AI导航组件

        MyEnemyHealth = GetComponent<MyEnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        //  判断是否死亡 没死就导航目标
        if(!MyEnemyHealth.isDeath)
        {
            //  设置导航地点
            agent.SetDestination(player.transform.position);
        }

    }
}
