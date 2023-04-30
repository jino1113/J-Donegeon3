using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DiscBGM : MonoBehaviour
{
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private AudioClip AudioClips;
    private bool secret;

    void Start()
    {
        secret = false;
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "MusicBox")
        {
            if (AudioSource.isPlaying == false)
            {
                AudioSource.PlayOneShot(AudioClips);
            }
            if (secret == false)
            {
                PointArrow.Instance.Triggers["Quest33"] = true;
                GameControllerManager.Instance.SecretScore += 1;
            }

            secret = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "MusicBox")
        {
            if (AudioSource.isPlaying == true)
            {
                AudioSource.Stop();
            }
        }
    }
}
