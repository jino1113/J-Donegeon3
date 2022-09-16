using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerManager : MonoBehaviour
{
    void Awake()
    {
        Application.targetFrameRate = 300;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
