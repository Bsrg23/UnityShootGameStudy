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
            //  ��������˺�
            other.GetComponentInChildren<MyPlayerShooting>().FireDamage += 10;
            Debug.Log("��ҽ��������˺�");       
            //  ģ����ʧ
            Destroy(gameObject);
            
        }
        
    }
}
