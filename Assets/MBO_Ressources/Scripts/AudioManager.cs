using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.XR;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource source, background;
    public AudioClip[] clips;
    public float fadeoutSpeed = 1;
    private Coroutine coroutine;
    public AnimationCurve fadeoutCurve;
    private int _index;
    private void Awake()
    {
        if (instance != null) Destroy(this);
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
               Play(_index);
               _index = (_index + 1) % clips.Length;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PlayMusic();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            StopMusic();
        }
    }

    public void Play(int index, float volume, bool loop)
    {
        source.loop = loop;
        source.volume = Mathf.Clamp(volume, 0, 1);
        source.clip = clips[index];
        source.Play();
    }

    public void Play(int index, float volume)
    {
        Play(index, volume, false);
    }

    public void Play(int index)
    {
        Play(index, 1, false);
    }

    public void PlayMusic()
    {
        background.volume = 1;
        if (coroutine != null)
        {
            StopCoroutine(FadeOut());
            coroutine = null;
            return;
        }
        background.Play();
    }

    public void StopMusic()
    {
        coroutine = StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float timeElapsed = 0;
        while (fadeoutCurve.keys[fadeoutCurve.length - 1].time >= timeElapsed)
        {
            background.volume = Mathf.Clamp(fadeoutCurve.Evaluate(timeElapsed), 0, 1);
            yield return null;
            timeElapsed += Time.deltaTime;
        }
        background.Stop();
        coroutine = null;
    }
}
