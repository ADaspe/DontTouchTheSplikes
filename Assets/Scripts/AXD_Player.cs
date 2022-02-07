using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.UIElements;
using UnityEditor.SceneManagement;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class AXD_Player : MonoBehaviour
{
    private Rigidbody2D rb;

    public float forceToAddWhenTouch;
    public Vector2 currentDir;
    

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentDir = new Vector2(1, 0);
        rb.velocity = currentDir * speed;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Touch");
            rb.AddForce(new Vector2(0, currentDir.y + forceToAddWhenTouch) * speed);
        }
        else
        {
            //rb.AddForce(currentDir * speed);
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall")){
            Debug.Log("Touch Wall");
            currentDir *= -1;
            rb.velocity = new Vector2(currentDir.x *speed,0);
        }
        else if (other.gameObject.CompareTag("Spike"))
        {
            Debug.Log("Death");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //Death
        }
        {
            Debug.Log(other.gameObject.name);
        }
    }
}