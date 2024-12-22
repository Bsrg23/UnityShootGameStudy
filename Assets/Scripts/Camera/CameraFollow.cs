using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //  相机跟随速度
    public float Smoothing = 5f;


    private GameObject player;
    private Vector3 offset;


    private void Awake()
    {
        //  根据标签找到物体
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        offset = transform.position - player.transform.position;
    }
    
    //  更新相机位置
    private void FixedUpdate()
    {
        transform.position =Vector3.Lerp(transform.position, offset + player.transform.position,Smoothing*Time.deltaTime) ;
    }
}
