using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestory : MonoBehaviour
{
    private AudioSource m_AudioSource;
    void Start()
    {
        if(m_AudioSource != null)
        {
            return;
        }else
        {
            DontDestroyOnLoad(this.gameObject);
        }
        
    }

    // Update is called once per frame
    //void Awake()
    //{
    //    if(m_AudioSource == null)
    //    {
    //        m_AudioSource.Play();
    //    }
    //}
}
