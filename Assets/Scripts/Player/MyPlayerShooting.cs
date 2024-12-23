using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerShooting : MonoBehaviour
{
    public int FireDamage = 10;//   子弹伤害

    //  开火间隔时间
    float time = 0f;
    float timeBetweenBullets = 0.15f;

    //  音效
    private AudioSource m_AudioSource;

    //  灯光,开火
    private Light gunLight;
    float lightTime = 0.2f;

    //  光线 子弹线条
    private LineRenderer gunLine;

    //  粒子系统
    private ParticleSystem gunParticleSystem;

    //  射线检测
    private Ray shootRay;// 射线
    private RaycastHit shootHit;//  受击目标后返回的对象
    private int shootMask;//    射击目标图层

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
        //  按下开火键
        if (Input.GetButton("Fire1") && time >= timeBetweenBullets)
        {
            //  射击
            Shoot();
            time = 0f;
      
        }
        //  灯光,子弹销毁
        if (time >= timeBetweenBullets * lightTime)
        {
            gunLight.enabled = false;
            gunLine.enabled = false;

        }
    }


    void Shoot()
    {
        //  播放开枪音效
        m_AudioSource.Play();

        //  枪火灯光
        gunLight.enabled = true;

        //  绘制子弹线条
        gunLine.SetPosition(0, transform.position);//   起点
        //gunLine.SetPosition(1, transform.position + transform.forward * 100);//   终点
        gunLine.enabled = true;

        //  开枪粒子特效
        gunParticleSystem.Play();

        //  发射射线 检测是否命中
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        
        if(Physics.Raycast(shootRay, out shootHit, 100, shootMask))
        {
            gunLine.SetPosition(1, shootHit.point);//  命中后子弹线条终点
            shootHit.collider.GetComponent<MyEnemyHealth>().TakeDamage(FireDamage, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, transform.position + transform.forward * 100);// 未命中后子弹线条终点
        }
    }




}
