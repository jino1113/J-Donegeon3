using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCore : MonoBehaviour
{
    public GameObject compass;

    private void Start()
    {
        compass.SetActive(false);
    }

    void Update()
    {
        DisabledMovementForPhaseOneTutorial();
    }

    void DisabledMovementForPhaseOneTutorial()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            return;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            return;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            return;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            return;
        }
    }
}
