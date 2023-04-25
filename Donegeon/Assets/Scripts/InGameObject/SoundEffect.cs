using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public float minImpactForce = 10f;
    private GameObject soundManager;

    void Start()
    {
        soundManager = GameObject.FindWithTag("SoundManager");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > minImpactForce)
        {
            soundManager.GetComponent<SoundManager>().PlayRandomSound();
        }
    }
}
