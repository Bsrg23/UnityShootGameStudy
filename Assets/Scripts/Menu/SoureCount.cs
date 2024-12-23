using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoureCount : MonoBehaviour
{
    public int Score = 0; //   ·ÖÊý

    private void Update()
    {
        GetComponent<Text>().text = "Score:" + Score;
    }

    public void ScoureAdd(int AddScore)
    {
        Score += AddScore;
    }
}
