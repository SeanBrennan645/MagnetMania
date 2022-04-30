using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int defaultScoreRate = 5;
    [SerializeField] float timeIncrements = 0.25f;

    private int score = 0;
    private bool isGamePlaying = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IncreaseScoreAuto());
    }

    private IEnumerator IncreaseScoreAuto()
    {
        while (isGamePlaying)
        {
            //Debug.Log("Score: " + score);
            score += defaultScoreRate;
            yield return new WaitForSeconds(timeIncrements);
        }
    }

    public void IncreaseScore(int points)
    {
        score += points;
        //Debug.Log("Score: " + score);
    }

    public void StopScore()
    {
        isGamePlaying = false;
    }

}
