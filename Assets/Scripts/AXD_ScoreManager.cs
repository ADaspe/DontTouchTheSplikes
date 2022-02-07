using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AXD_ScoreManager : MonoBehaviour
{
    [HideInInspector] public int score=0;
    public Text scoreTextUi;
    [HideInInspector] public int highScore;
    public Text highScoreTextUI;

    private void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            highScore = 0;
        }

        scoreTextUi.text = score.ToString();
        
    }

    public void AddScore(int scoreToAdd = 1)
    {
        score += scoreToAdd;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore",highScore);
            if(highScoreTextUI != null){
                highScoreTextUI.text = highScore.ToString();
            }
        }
        scoreTextUi.text = score.ToString();
    }
}
