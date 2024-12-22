using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

    //  �ܻ�����
    public void TakeDamage(int damage,Vector3 shootHitPoint)
    {
        //  �Ƿ��Ѿ�����
        if (isDeath)
            return;

        //  �ܻ�������Ч
        particleSystem.transform.position = shootHitPoint;
        particleSystem.Play();

        //  �۳�Ѫ��
        StartingHealth -= damage;
        if(StartingHealth <= 0)
        {
            Death();
        }

         audioSource.Play();//   �����ܻ�(����)��Ч


    }

    private void Death()
    {
        isDeath = true;
        //  ������������
        animator.SetTrigger("Death");
        //  ���ܻ���Ч �л�Ϊ ������Ч
        audioSource.clip = DeathClip;

        //  ������ײ��
        capsuleCollider.isTrigger = true;
        //  ȡ������Ч��
        GetComponent<Rigidbody>().isKinematic = true;
        //  ����NavMeshAgent
        GetComponent<NavMeshAgent>().enabled = false;

    }
    public void StartSinking()
    {
        IsSiking = true;
        //  ��������ٵ�ǰ����
        Destroy(gameObject,2f);
    }


}