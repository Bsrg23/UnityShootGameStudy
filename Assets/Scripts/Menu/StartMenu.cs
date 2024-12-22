using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        //  场景下标 +1  (切换游戏场景)  
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
