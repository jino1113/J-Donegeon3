using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] soundClips;
    public int maxConcurrentSounds = 3;

    private AudioSource[] audioSources;

    void Start()
    {
        audioSources = new AudioSource[maxConcurrentSounds];
        for (int i = 0; i < maxConcurrentSounds; i++)
        {
            audioSources[i] = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayRandomSound()
    {
        int randomIndex = Random.Range(0, soundClips.Length);

        for (int i = 0; i < audioSources.Length; i++)
        {
            if (!audioSources[i].isPlaying)
            {
                audioSources[i].clip = soundClips[randomIndex];
                audioSources[i].Play();
                return;
            }
        }
    }
}
