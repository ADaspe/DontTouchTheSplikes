using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class LAC_CandyBonus : MonoBehaviour
{
    [SerializeField] int scoreBonus = 1;
    public AXD_ScoreManager score;
    public LAC_GenerateCandy generator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            score.AddScore(scoreBonus);
            generator.canSpawn = true;
            Destroy(gameObject);
        }
    }
}
