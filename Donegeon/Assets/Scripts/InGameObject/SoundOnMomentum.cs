using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnMomentum : MonoBehaviour
{
    public AudioClip[] soundClips;
    public float minImpactForce = 10f;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > minImpactForce)
        {
            AudioClip clip = soundClips[Random.Range(0, soundClips.Length)];
            audioSource.PlayOneShot(clip);
        }
    }
}
