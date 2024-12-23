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
    public Slider healthSlider;//   血量滑动条
    
    private bool isDamage;//    是否受伤
    public Image HurtImage;//   受伤画面
    private Color flashColor = new Color(1f, 0f, 0f, 1f);// 颜色
    private Color clearColor = Color.clear;



    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        healthSlider.value = health;//  初始化血量
    }

    private void Update()
    {
        //  检测受伤
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
        isDamage = true;//  确认受到伤害

        if (isDeath)
        {
            return;
        }
            

        //  扣除血量
        health -= Damage;
        Debug.Log("扣除血量:" + Damage);
        healthSlider.value = health;



        //  判断是否死亡
        if (health <= 0)
        {
            Death();
        }

        //  播放受伤(死亡)音效
        audioSource.Play();


    }


    private void Death()
    {
        isDeath = true;
        Debug.Log("玩家死亡");//    打印日志
        animator.SetTrigger("Death");// 播放死亡动画
        audioSource.clip = DeathSound;//    切换死亡音效
        GetComponent<PlayerMovement>().enabled = false;//   停止移动
        GetComponentInChildren<MyPlayerShooting>().enabled = false;// 停止射击
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
