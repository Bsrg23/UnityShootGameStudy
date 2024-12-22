using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyPlayerHealth : MonoBehaviour
{
    public float health = 100;
    public AudioClip DeathSound;
    private AudioSource audioSource;
    private bool isDeath;
    private Animator animator;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();  
    }


    public void ReceiveDamage(int Damage)
    {
        if (isDeath)
        {
            return;
        }
            

        //  �۳�Ѫ��
        health -= Damage;
        Debug.Log("�۳�Ѫ��:" + Damage);

        
        

        //  �ж��Ƿ�����
        if (health <= 0)
        {
            Death();
        }

        //  ��������(����)��Ч
        audioSource.Play();


    }


    private void Death()
    {
        isDeath = true;
        Debug.Log("�������");//    ��ӡ��־
        animator.SetTrigger("Death");// ������������
        audioSource.clip = DeathSound;//    �л�������Ч
        
        GetComponent<PlayerMovement>().enabled = false;//   ֹͣ�ƶ�
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
