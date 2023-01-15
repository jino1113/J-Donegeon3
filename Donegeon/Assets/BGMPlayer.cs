using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private List<AudioClip> AudioClips;


    private int i;

    void Start()
    {
        i = 0;
    }

    void Update()
    {
        if (AudioSource.isPlaying == false)
        {
            AudioSource.PlayOneShot(AudioClips[i]);
        }
        else
        {
            i++;
        }
        if (i >= AudioClips.Count)
        {
            i = 0;
        }
    }
}
