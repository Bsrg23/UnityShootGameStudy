using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        //  �����±� +1  (�л���Ϸ����)  
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
