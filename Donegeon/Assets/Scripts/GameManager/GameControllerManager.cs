using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerManager : MonoBehaviour
{
    [SerializeField] private List<Text> QuestNameTextList;

    [SerializeField] private float NowDirtyScore,CleanPercentScore;


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

        Debug.Log(CleanPercentScore + "%");
        Debug.Log("NowScore = " + PointArrow.Instance.NowScore);
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

}
