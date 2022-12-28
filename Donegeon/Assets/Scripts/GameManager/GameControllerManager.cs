using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Animations;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerManager : MonoBehaviour
{
    [SerializeField] private Text OverallProgress;
    [SerializeField] private List<Text> QuestNameTextList;

    [SerializeField] private float NowDirtyScore,CleanPercentScore,GateOpenScore;

    [SerializeField] private List<Animator> AnimatorController;

    [SerializeField] private List<GameObject> FogGateGameObjects;

    public Color ClearQuestColor;

    private void Awake()
    {
        Application.targetFrameRate = 300;
        DontDestroyOnLoad(gameObject);

    }

    void Start()
    {
        CleaningPercent();
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
            int index = 0;
            StartCoroutine(FogGateOpen());
            foreach (var VARIABLE in AnimatorController)
            {
                AnimatorController[index].SetBool("Fade",true);
                index++;
            }
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



    IEnumerator FogGateOpen()
    {
        yield return new WaitForSeconds(9);

        FogGateGameObjects[0].SetActive(false);
        FogGateGameObjects[1].SetActive(false);
    }

}
