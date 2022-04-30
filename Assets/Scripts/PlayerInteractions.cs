﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] ScoreManager score;
    [SerializeField] Manager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Collectable")
        {
            score.IncreaseScore(other.GetComponent<Coin>().pointValue);
        }
        else if(other.tag == "Hazard")
        {
            score.StopScore();
            //TODO logic to display scoreboard and button to reset level
        }
        else
        {
            return;
        }
    }
}