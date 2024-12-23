using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MyEnemyHealth : MonoBehaviour
{
    public int StartingHealth = 100;

    private AudioSource audioSource;
    public AudioClip DeathClip;
    private ParticleSystem particleSystem;
    private Animator animator;
    private CapsuleCollider capsuleCollider;

    public bool isDeath = false;
    private bool IsSiking = false;

    public Text Score;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        particleSystem = GetComponentInChildren<ParticleSystem>();
        animator = GetComponentInChildren<Animator>();
        capsuleCollider = GetComponentInChildren<CapsuleCollider>();
    }



    // Update is called once per frame
    void Update()
    {
        if (IsSiking)
        {
            transform.Translate(-transform.up*Time.deltaTime);
        }
    }

    //  受击函数
    public void TakeDamage(int damage,Vector3 shootHitPoint)
    {
        //  是否已经死亡
        if (isDeath)
            return;

        //  受击粒子特效
        particleSystem.transform.position = shootHitPoint;
        particleSystem.Play();

        //  扣除血量
        StartingHealth -= damage;
        if(StartingHealth <= 0)
        {
            Death();
        }

         audioSource.Play();//   播放受击(死亡)音效


    }

    private void Death()
    {
        isDeath = true;
        //  播放死亡动画
        animator.SetTrigger("Death");
        //  将受击音效 切换为 死亡音效
        audioSource.clip = DeathClip;

        //  增加分数
        GameObject Score = GameObject.Find("ScoreText");
        Score.GetComponent<SoureCount>().ScoureAdd(1);
        //  消除碰撞盒
        capsuleCollider.isTrigger = true;
        GetComponentInChildren<CapsuleCollider>().enabled = false;
        //  循环遍历子组件 删除指定子组件
        Transform transform;
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).name == "AttackBox")
            {
                transform = gameObject.transform.GetChild(i);
                GameObject.Destroy(transform.gameObject);
                break;
            }
           
        }

        //  取消物理效果
        GetComponent<Rigidbody>().isKinematic = true;
        //  禁用NavMeshAgent
        GetComponent<NavMeshAgent>().enabled = false;

    }
    public void StartSinking()
    {
        IsSiking = true;
        //  两秒后销毁当前对象
        Destroy(gameObject,2f);
    }


}
