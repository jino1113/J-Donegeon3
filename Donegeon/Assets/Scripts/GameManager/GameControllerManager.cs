using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerManager : MonoBehaviour
{
    [SerializeField] double NowTime;

    [SerializeField] private Text OverallProgress;
    [SerializeField] private List<Text> QuestNameTextList;

    [SerializeField] private float NowDirtyScore, GateOpenScore;

    [SerializeField] private List<Animator> AnimatorController;

    [SerializeField] private List<GameObject> FogGateGameObjects;

    [SerializeField] private GameObject SceneName;

    public bool Pause,Ending;
    public float CleanPercentScore;
    public double scoreTime;

    public Color ClearQuestColor;

    public static GameControllerManager Instance;

    private void Awake()
    {
        Application.targetFrameRate = 300;
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        Ending = false;
        Pause = false;
        NowTime = 0;

    }

    void Update()
    {
        NowTime += Time.deltaTime;
    }

    void LateUpdate()
    {
        CheckAllQuestObject();
        CleaningPercent();

        OverallProgress.text = "Progress: " + CleanPercentScore + "%";
    }

    void CheckAllQuestObject()
    {
        if (PointArrow.Instance.Triggers["Quest1"] == true)
        {
            QuestNameTextList[0].color = ClearQuestColor;
        }
        if (PointArrow.Instance.Triggers["Quest2"] == true)
        {
            QuestNameTextList[1].color = ClearQuestColor;
        }
        if (PointArrow.Instance.Triggers["Quest3"] == true)
        {
            QuestNameTextList[2].color = ClearQuestColor;
        }
        if (PointArrow.Instance.Triggers["Quest4"] == true)
        {
            QuestNameTextList[3].color = ClearQuestColor;
        }
        if (PointArrow.Instance.Triggers["Quest5"] == true)
        {
            QuestNameTextList[4].color = ClearQuestColor;
        }

        if (PointArrow.Instance.Triggers["Quest1"] == true && PointArrow.Instance.Triggers["Quest2"] == true && PointArrow.Instance.Triggers["Quest3"] == true
            && PointArrow.Instance.Triggers["Quest4"] == true && PointArrow.Instance.Triggers["Quest5"] == true)
        {
            for (int i = 0; i < QuestNameTextList.Count ; i++)
            {
                QuestNameTextList[i].gameObject.SetActive(false);
            }
        }

        if (PointArrow.Instance.Triggers["Quest1"] == true && PointArrow.Instance.Triggers["Quest2"] == true && PointArrow.Instance.Triggers["Quest3"] == true
            && PointArrow.Instance.Triggers["Quest4"] == true && PointArrow.Instance.Triggers["Quest5"] == true && PointArrow.Instance.NowScore >= GateOpenScore || Input.GetKeyDown(KeyCode.P))
        {
            if (AnimatorController != null)
            {
                int index = 0;
                foreach (var VARIABLE in AnimatorController)
                {
                    AnimatorController[index].SetBool("Fade",true);
                    index++;
                }
            }
            StartCoroutine(FogGateOpen());
            AnimatorController = null;
        }
    }

    void CleaningPercent()
    {
        NowDirtyScore = 0;
        NowDirtyScore += PointArrow.Instance.LitterCount;
        NowDirtyScore += PointArrow.Instance.BloodCount;
        NowDirtyScore += PointArrow.Instance.BrokenWallCount;
        NowDirtyScore += PointArrow.Instance.CandleCount;

        float i = PointArrow.Instance.NowScore / 10f;
        CleanPercentScore = i;
    }

    public void SceneCheck()
    {
        if (SceneManager.GetActiveScene().name == "MenuScene")
        {

            SceneManager.LoadScene("TheChateau");
            Time.timeScale = 1;
            StartCoroutine(GameReloadTimer());

            Ending = false;
            Pause = false;
            PointArrow.Instance.Triggers["Quest1"] = false;
            PointArrow.Instance.Triggers["Quest2"] = false;
            PointArrow.Instance.Triggers["Quest3"] = false;
            PointArrow.Instance.Triggers["Quest4"] = false;
            PointArrow.Instance.Triggers["Quest5"] = false;
            PointArrow.Instance.Triggers["Quest6"] = false;
        }
        if(SceneManager.GetActiveScene().name == "TheChateau")
        {
            scoreTime = NowTime;
            Debug.Log(scoreTime);
            scoreTime = scoreTime / 60.0f;
            Time.timeScale = 1;
            SceneManager.LoadScene("MenuScene");

            StartCoroutine(GameReloadTimer());
            Ending = true;
        }
    }

    public void DisableCursor()
    {
        Time.timeScale = 1;
        Pause = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    IEnumerator FogGateOpen()
    {
        yield return new WaitForSeconds(9);

        FogGateGameObjects[0].SetActive(false);
        FogGateGameObjects[1].SetActive(false);
    }

    IEnumerator GameReloadTimer()
    {
        yield return new WaitForSeconds(0.2f);
    }

}
