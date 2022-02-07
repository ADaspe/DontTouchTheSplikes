using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AXD_ScoreManager : MonoBehaviour
{
    public int score=0;
    public Text scoreTextUi;

    public void AddScore(int scoreToAdd = 1)
    {
        score += scoreToAdd;
        scoreTextUi.text = score.ToString();
    }
}
