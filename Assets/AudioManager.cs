using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------- Audio Source--------")]
     public AudioSource musicSource;
     public AudioSource SFXSource;

    [Header("--------- Audio Clips--------")]
    public AudioClip background;
    public AudioClip EngineIdle;
    public AudioClip Driving;
    public AudioClip MenuButtons;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void StopSFX()
    {
        SFXSource.Stop();
    }
}