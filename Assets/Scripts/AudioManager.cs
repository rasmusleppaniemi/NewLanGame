using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Singleton instance
    public static AudioManager instance;

    [Header("Audio Source")]
    public AudioSource musicSource;
    public AudioSource SFXSource;

    [Header("Audio Clips")]
    public AudioClip background;
    public AudioClip menuButtons;

    private void Awake()
    {
        // Check if instance already exists
        if (instance == null)
        {
            // If not, set the instance to this AudioManager
            instance = this;
            // Keep this GameObject alive between scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this GameObject
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Play background music when AudioManager starts
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        // Play a single sound effect
        SFXSource.clip = clip;
        SFXSource.Play();
    }

    public void StopSFX()
    {
        // Stop playing all sound effects
        SFXSource.Stop();
    }
}
