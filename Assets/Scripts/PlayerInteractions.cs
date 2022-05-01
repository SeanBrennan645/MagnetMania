using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] ScoreManager score;
    [SerializeField] Manager gameManager;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Collectable")
        {
            score.IncreaseScore(other.GetComponent<Coin>().pointValue);
        }
        else if(other.tag == "Hazard")
        {
            resetPlayer();
            score.StartStopScore();
            gameManager.GameOver();
            //TODO logic to display scoreboard and button to reset level
        }
        else
        {
            return;
        }
    }

    public void resetPlayer()
    {
        gameObject.transform.position = startPosition;
    }
}
