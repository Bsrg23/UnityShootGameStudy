using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyPlayerHealth : MonoBehaviour
{
    public float health = 100;
    public AudioClip DeathSound;
    private AudioSource audioSource;
    private bool isDeath;
    private Animator animator;
    public Slider healthSlider;//   Ѫ��������
    
    private bool isDamage;//    �Ƿ�����
    public Image HurtImage;//   ���˻���
    private Color flashColor = new Color(1f, 0f, 0f, 1f);// ��ɫ
    private Color clearColor = Color.clear;



    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        healthSlider.value = health;//  ��ʼ��Ѫ��
    }

    private void Update()
    {
        //  �������
        if (isDamage)
        {
            HurtImage.color = flashColor;
        }
        else
        {
            HurtImage.color = Color.Lerp(HurtImage.color, clearColor, Time.deltaTime * 5);
        }
        isDamage = false;
    }




    public void ReceiveDamage(int Damage)
    {
        isDamage = true;//  ȷ���ܵ��˺�

        if (isDeath)
        {
            return;
        }
            

        //  �۳�Ѫ��
        health -= Damage;
        Debug.Log("�۳�Ѫ��:" + Damage);
        healthSlider.value = health;



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
        GetComponentInChildren<MyPlayerShooting>().enabled = false;// ֹͣ���
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
