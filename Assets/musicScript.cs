using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicScript : MonoBehaviour
{
    // from https://answers.unity.com/questions/1260393/make-music-continue-playing-through-scenes.html

    public static musicScript instance;

    public AudioSource audioSource;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            return;

        DontDestroyOnLoad(transform.gameObject);
        PlayMusic();
    }
    public void PlayMusic()
    {
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}
