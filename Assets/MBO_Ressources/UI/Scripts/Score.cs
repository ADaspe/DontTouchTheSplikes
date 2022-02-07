using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private int score;
    public ScoreScriptable scorefile;
    [SerializeField] private Text scoreText, bestScoreText;


    void Awake()
    {
        DisplayScore();
        bestScoreText.enabled = false;
    }

    public void ResetScore()
    {
        score = 0;
        DisplayScore();
        bestScoreText.enabled = false;
    }

    public void AddScore()
    {
        score++;
        DisplayScore();
    }

    public void AddScore(int value)
    {
        score += value;
        DisplayScore();
    }

    public void DisplayScore()
    {
        scoreText.text = score.ToString();
    }

    public void SetScore(int value)
    {
        score = value;
        DisplayScore();
    }

    public void End()
    {
        if (score > scorefile.bestScore) scorefile.bestScore = score;
        //Display bestScore
        bestScoreText.enabled = true;
        bestScoreText.text = scorefile.bestScore.ToString();
    }
}
