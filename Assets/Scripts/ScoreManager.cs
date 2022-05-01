using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int defaultScoreRate = 5;
    [SerializeField] float timeIncrements = 0.25f;
    [SerializeField] TextMeshProUGUI scoreText;

    private int score = 0;
    private bool isGamePlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score\n0";
        StartCoroutine(IncreaseScoreAuto());
    }

    private IEnumerator IncreaseScoreAuto()
    {
        while (true)
        {
            if (isGamePlaying)
            {
                score += defaultScoreRate;
                scoreText.text = "Score\n" + score;              
            }
            yield return new WaitForSeconds(timeIncrements);
        }
    }

    public void IncreaseScore(int points)
    {
        score += points;
        scoreText.text = "Score\n" + score;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void StartStopScore()
    {
        Debug.Log("SCOREMAN!"); 
        isGamePlaying = !isGamePlaying;
    }

}
