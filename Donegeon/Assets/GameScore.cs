using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameScore : MonoBehaviour
{
    public static GameScore Instance;

    public string Playername;

    public float DirtyScore;
    public double TimeScore;


    void Awake()
    {
        Application.targetFrameRate = 300;
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public GameScore()
    {
        Playername = string.Empty;
        TimeScore = 0f;
    }

    void LateUpdate()
    {
        if (GameControllerManager.Instance.Ending == false)
        {
            TimeScore = 0f;
        }

        TimeScore = GameControllerManager.Instance.scoreTime;
        DirtyScore = GameControllerManager.Instance.CleanPercentScore;
    }


}


