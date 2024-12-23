using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerShooting : MonoBehaviour
{
    public int FireDamage = 10;//   �ӵ��˺�

    //  ������ʱ��
    float time = 0f;
    float timeBetweenBullets = 0.15f;

    //  ��Ч
    private AudioSource m_AudioSource;

    //  �ƹ�,����
    private Light gunLight;
    float lightTime = 0.2f;

    //  ���� �ӵ�����
    private LineRenderer gunLine;

    //  ����ϵͳ
    private ParticleSystem gunParticleSystem;

    //  ���߼��
    private Ray shootRay;// ����
    private RaycastHit shootHit;//  �ܻ�Ŀ��󷵻صĶ���
    private int shootMask;//    ���Ŀ��ͼ��

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
        gunLine = GetComponent<LineRenderer>();
        gunParticleSystem = GetComponent<ParticleSystem>();
        shootMask = LayerMask.GetMask("Shootable");
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //  ���¿����
        if (Input.GetButton("Fire1") && time >= timeBetweenBullets)
        {
            //  ���
            Shoot();
            time = 0f;
      
        }
        //  �ƹ�,�ӵ�����
        if (time >= timeBetweenBullets * lightTime)
        {
            gunLight.enabled = false;
            gunLine.enabled = false;

        }
    }


    void Shoot()
    {
        //  ���ſ�ǹ��Ч
        m_AudioSource.Play();

        //  ǹ��ƹ�
        gunLight.enabled = true;

        //  �����ӵ�����
        gunLine.SetPosition(0, transform.position);//   ���
        //gunLine.SetPosition(1, transform.position + transform.forward * 100);//   �յ�
        gunLine.enabled = true;

        //  ��ǹ������Ч
        gunParticleSystem.Play();

        //  �������� ����Ƿ�����
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        
        if(Physics.Raycast(shootRay, out shootHit, 100, shootMask))
        {
            gunLine.SetPosition(1, shootHit.point);//  ���к��ӵ������յ�
            shootHit.collider.GetComponent<MyEnemyHealth>().TakeDamage(FireDamage, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, transform.position + transform.forward * 100);// δ���к��ӵ������յ�
        }
    }




}
