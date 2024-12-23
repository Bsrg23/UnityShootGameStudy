using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryObjectWithSound : MonoBehaviour
{
    public AudioClip sound;// “Ù∆µ

    private void OnDestroy()
    {
        if (sound != null)
        {
            AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position,1f);
        }
    }
}
