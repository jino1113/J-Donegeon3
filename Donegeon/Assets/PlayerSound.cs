using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private List<AudioSource> AudioSource;
    [SerializeField] private List<AudioClip> AudioClips;


    public void WalkSound()
    {
        AudioSource[0].clip = AudioClips[Random.Range(0, 3)];
        AudioSource[0].Play();
    }

    public void ToolSound(AudioClip audio)
    {
        AudioSource[0].clip = audio;
        AudioSource[0].Play();
    }
}
