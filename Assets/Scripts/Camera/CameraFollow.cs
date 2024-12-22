using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //  ��������ٶ�
    public float Smoothing = 5f;


    private GameObject player;
    private Vector3 offset;


    private void Awake()
    {
        //  ���ݱ�ǩ�ҵ�����
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        offset = transform.position - player.transform.position;
    }
    
    //  �������λ��
    private void FixedUpdate()
    {
        transform.position =Vector3.Lerp(transform.position, offset + player.transform.position,Smoothing*Time.deltaTime) ;
    }
}
