using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class AXD_Player : MonoBehaviour
{
    public Vector2 currentDir;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        currentDir = new Vector2(1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
