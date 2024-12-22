using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerHealth : MonoBehaviour
{
    public float health = 100;



    // Update is called once per frame
    void Update()
    {
        
    }


    public void ReceiveDamage(int Damage)
    {
        health -= Damage;
        Debug.Log("ÕÊº“ ’µΩ…À∫¶");
    }
}
