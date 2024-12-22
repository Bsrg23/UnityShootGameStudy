using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TouchEffect : MonoBehaviour
{
    private AudioSource attackAudioSource;
    private void Awake()
    {
        attackAudioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            //  增加玩家伤害
            other.GetComponentInChildren<MyPlayerShooting>().FireDamage += 10;
            Debug.Log("玩家进入增加伤害");       
            //  模型消失
            Destroy(gameObject);
            
        }
        
    }
}
