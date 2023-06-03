using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class GameScore : MonoBehaviour
{
    public static GameScore Instance;

    public string Playername;


    public float DirtyScore;
    public double TimeScore;
    public int SecretPoint;
    public AudioMixer AudioMixer;


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
        SecretPoint = GameControllerManager.Instance.SecretScore;
    }

    public void SetMasterVolume(float volume)
    {
        AudioMixer.SetFloat("MasterVolume",volume);
    }

    public void SetInGameVolume(float volume)
    {
        AudioMixer.SetFloat("InGameVolume", volume);
    }

    public void SetInGameSFXVolume(float volume)
    {
        AudioMixer.SetFloat("InGameSFXVolume", volume);
    }

    public void SetNarratorVolume(float volume)
    {
        AudioMixer.SetFloat("NarratorVolume", volume);
    }
    public void SetBGMVolume(float volume)
    {
        AudioMixer.SetFloat("BGMVolume", volume);
    }

    public void SetMenuSFXVolume(float volume)
    {
        AudioMixer.SetFloat("MenuSFXVolume", volume);
    }
}


