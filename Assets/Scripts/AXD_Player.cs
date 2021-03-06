using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.UIElements;
using UnityEditor.SceneManagement;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Scene = UnityEngine.SceneManagement.Scene;

public class AXD_Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isDead;
    public GameObject DieUI;
    public AXD_PlayerRenderer axdRenderer;
    public float forceToAddWhenTouch;
    public Vector2 currentDir;
    public UnityEvent touchWallEvent;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        rb = GetComponent<Rigidbody2D>();
        axdRenderer = GetComponent<AXD_PlayerRenderer>();
        currentDir = new Vector2(1, 0);
        rb.velocity = currentDir * speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Touch");
                StartCoroutine(axdRenderer.FlapCoroutine());
                rb.AddForce(new Vector2(0, currentDir.y + forceToAddWhenTouch) * speed);
            }
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall")){
            if (!isDead)
            {
                touchWallEvent.Invoke();
                other.gameObject.GetComponent<LAC_GenerateWallPic>().touchWall.Invoke();
                currentDir *= -1;
                rb.velocity = new Vector2(currentDir.x * speed, 0);
            }
        }
        else if (other.gameObject.CompareTag("Spike"))
        {
            Debug.Log("Death");
            isDead = true;
            DieUI.SetActive(true);
        }
        {
            Debug.Log(other.gameObject.name);
        }
    }
}
