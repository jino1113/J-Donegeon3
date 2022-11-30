using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class BreathingCamera : MonoBehaviour
{
    public Camera PlayerCamera;
    private float m_InitialFov;

    [Header("Debug")]
    public float timer;
    public bool Doing;

    public float period = 0.5f;

    void Start()
    {
        PlayerCamera.GetComponent<Camera>();
        m_InitialFov = PlayerCamera.fieldOfView;

    }

    void Update()
    {
        if (Doing)
        { 
            PlayerCamera.fieldOfView = Mathf.Lerp(PlayerCamera.fieldOfView, m_InitialFov + 5, 0.001f);
            if (PlayerCamera.fieldOfView >= 62)
            {
                Doing = false;
            }
        }
        else if (Doing == false)
        {
            PlayerCamera.fieldOfView = Mathf.Lerp(PlayerCamera.fieldOfView, m_InitialFov - 5, 0.001f);
            if (PlayerCamera.fieldOfView <= 58)
            {
                Doing = true;
            }
        }
    }
}
