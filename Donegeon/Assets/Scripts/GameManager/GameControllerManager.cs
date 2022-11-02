using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerManager : MonoBehaviour
{
    [SerializeField] private List<Text> QuestNameTextList;

    public Color ClearQuestColor;

    private void Awake()
    {
        Application.targetFrameRate = 300;
        DontDestroyOnLoad(gameObject);

    }

    void LateUpdate()
    {
        CheckAllQuestObject();
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

        if (PointArrow.Instance.Triggers["Quest1"] == true && PointArrow.Instance.Triggers["Quest2"] == true && PointArrow.Instance.Triggers["Quest3"] == true)
        {
            for (int i = 0; i < QuestNameTextList.Count ; i++)
            {
                QuestNameTextList[i].gameObject.SetActive(false);
            }
        }
    }

}
