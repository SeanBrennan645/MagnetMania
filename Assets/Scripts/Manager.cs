using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] GameObject player;
    [SerializeField] GameObject mainUI;
    [SerializeField] GameObject scoreUI;
    [SerializeField] GameObject endUI;

    public void GameOver()
    {
        scoreManager.StopScore();
        //display end ui
        //disable spawners
    }

    public void StartGame()
    {
        scoreManager.ResetScore();
        //disable current ui
        //reset player
        //start spawners
    }
}
