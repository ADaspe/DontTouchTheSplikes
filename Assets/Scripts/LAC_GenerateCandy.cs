using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LAC_GenerateCandy : MonoBehaviour
{
    AXD_ScoreManager score;
    [SerializeField] GameObject candyPrefab;
    List<GameObject> candyPos;
    public bool canSpawn = true;
    private void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            candyPos.Add(transform.GetChild(i).gameObject);
        }
        
    }

    public void GenerateCandy()
    {
        if (canSpawn)
        {
            GameObject candy = Instantiate(candyPrefab, candyPos[Random.Range(0, candyPos.Count - 1)].transform);
            
        }
            
        canSpawn = false;
    }
}
