using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemyAttack : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("·¢ÉúÅö×²:"+collision.gameObject.name);
    }

}
