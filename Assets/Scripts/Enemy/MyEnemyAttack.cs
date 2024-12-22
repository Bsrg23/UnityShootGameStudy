using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemyAttack : MonoBehaviour
{
    public int AttackValue = 10;

    //  ¹¥»÷¼ä¸ôÊ±¼ä
    float time = 0f;
    float timeBetweenBullets = 1f;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {

        if (time >= timeBetweenBullets && other.gameObject.name == "Player")
        {
            time = 0f;
            other.gameObject.GetComponent<MyPlayerHealth>().ReceiveDamage(AttackValue);
        }
       
    }

}
