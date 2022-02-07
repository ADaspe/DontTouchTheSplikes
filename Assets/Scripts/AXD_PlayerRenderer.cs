using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class AXD_PlayerRenderer : MonoBehaviour
{
    private SpriteRenderer sr;
    private Sprite currentSprite;
    public List<Sprite> sprites;
    public AXD_Player player;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = currentSprite = sprites[0];
    }

    public void FlipSprite()
    {
        sr.flipX = !sr.flipX;
    }

    public IEnumerator FlapCoroutine()
    {
        Debug.Log("Start Coroutine");
        sr.sprite = currentSprite = sprites[1]; 
        yield return new WaitForSeconds(0.15f);
        sr.sprite = currentSprite = sprites[0];
    }
}
