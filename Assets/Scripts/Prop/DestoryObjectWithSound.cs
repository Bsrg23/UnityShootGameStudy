using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryObjectWithSound : MonoBehaviour
{
  public AudioClip sound;


    private void OnDestroy()
    {
        if (sound != null)
        {
            AudioSource.PlayClipAtPoint(sound,transform.position,1f);
        }
    }
}
