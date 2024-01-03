using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class GameScore : MonoBehaviour
{
    public static GameScore Instance;

    public string Playername;
    public float DirtyScore;
    public double TimeScore;
    public int SecretPoint;

    public AudioMixer AudioMixer;

    public List<Sliderclass> sliderclasses = new List<Sliderclass>();   

    private void Start()
    {
        foreach (var slider in sliderclasses)
        {
            slider.slidervalue = PlayerPrefs.GetFloat("volume"+slider.name);
            slider.slider.value = slider.slidervalue;
        }
    }

    private void Update()
    {
        foreach (var slider in sliderclasses)
        {
            slider.slidervalue = PlayerPrefs.GetFloat("volume" + slider.name);
        }
    }

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
        PlayerPrefs.SetFloat("volume" + sliderclasses[0].name, volume);

    }

    public void SetInGameVolume(float volume)
    {
        AudioMixer.SetFloat("InGameVolume", volume);
        PlayerPrefs.SetFloat("volume" + sliderclasses[1].name, volume);

    }

    public void SetInGameSFXVolume(float volume)
    {
        AudioMixer.SetFloat("InGameSFXVolume", volume);
        PlayerPrefs.SetFloat("volume" + sliderclasses[2].name, volume);
    }

    public void SetNarratorVolume(float volume)
    {
        AudioMixer.SetFloat("NarratorVolume", volume);
        PlayerPrefs.SetFloat("volume" + sliderclasses[3].name, volume);
    }
    public void SetBGMVolume(float volume)
    {
        AudioMixer.SetFloat("BGMVolume", volume);
        PlayerPrefs.SetFloat("volume" + sliderclasses[4].name, volume);
    }

    public void SetMenuSFXVolume(float volume)
    {
        AudioMixer.SetFloat("MenuSFXVolume", volume);
        PlayerPrefs.SetFloat("volume" + sliderclasses[5].name, volume);
    }
}


