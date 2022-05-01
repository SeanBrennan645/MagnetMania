﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] GameObject player;
    [SerializeField] GameObject mainUI;
    [SerializeField] GameObject scoreUI;
    [SerializeField] GameObject endUI;
    [SerializeField] GameObject[] spawners;
    

    public void GameOver()
    {
        scoreManager.StopScore();
        player.SetActive(false);
        mainUI.SetActive(true);//replace with end UI
        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i].GetComponent<Spawner>().GameStateChanged();
        }
    }

    public void StartGame()
    {
        scoreManager.ResetScore();
        mainUI.SetActive(false);
        scoreUI.SetActive(true);
        player.GetComponent<PlayerInteractions>().resetPlayer();
        player.SetActive(true);
        for(int i = 0; i < spawners.Length; i++)
        {
            spawners[i].GetComponent<Spawner>().GameStateChanged();
        }
    }
}
