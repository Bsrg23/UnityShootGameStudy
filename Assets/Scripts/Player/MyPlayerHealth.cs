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
            

        //  ¿Û³ýÑªÁ¿
        health -= Damage;
        Debug.Log("¿Û³ýÑªÁ¿:" + Damage);

        
        

        //  ÅÐ¶ÏÊÇ·ñËÀÍö
        if (health <= 0)
        {
            Death();
        }

        //  ²¥·ÅÊÜÉË(ËÀÍö)ÒôÐ§
        audioSource.Play();


    }


    private void Death()
    {
        isDeath = true;
        Debug.Log("Íæ¼ÒËÀÍö");//    ´òÓ¡ÈÕÖ¾
        animator.SetTrigger("Death");// ²¥·ÅËÀÍö¶¯»­
        audioSource.clip = DeathSound;//    ÇÐ»»ËÀÍöÒôÐ§
        
        GetComponent<PlayerMovement>().enabled = false;//   Í£Ö¹ÒÆ¶¯
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
