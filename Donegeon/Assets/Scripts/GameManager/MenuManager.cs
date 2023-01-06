using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Panel;
    [SerializeField] private List<GameObject> GradeList;
    [SerializeField] private List<Text> Score;

    private double DT;


    void Start()
    {
        ScoringShow();
    }


    void ScoringShow()
    {
        if (GameControllerManager.Instance.Ending == true)
        {
            Panel[0].SetActive(false);
            Panel[1].SetActive(true);


            Score[0].text = "~" + GameScore.Instance.TimeScore.ToString() + " Mins";
            Score[1].text = GameScore.Instance.DirtyScore.ToString() + "%";

            if (GameScore.Instance.TimeScore <= 1 && GameScore.Instance.DirtyScore >= 4)
            {
                GradeList[0].SetActive(true);
            }
            else if (GameScore.Instance.TimeScore <= 2 && GameScore.Instance.DirtyScore >= 3)
            {
                GradeList[1].SetActive(true);
            }
            else if (GameScore.Instance.TimeScore <= 3 && GameScore.Instance.DirtyScore >= 2)
            {
                GradeList[2].SetActive(true);
            }
            else if (GameScore.Instance.TimeScore <= 4 && GameScore.Instance.DirtyScore >= 1)
            {
                GradeList[3].SetActive(true);
            }
            else if (GameScore.Instance.DirtyScore <= 0 || (GameScore.Instance.TimeScore <= 5 && GameScore.Instance.DirtyScore <= 0.9))
            {
                GradeList[4].SetActive(true);
            }
        }
    }


    void LateUpdate()
    {

    }


    public void quitGame()
    {
        Application.Quit();
    }

    public void startGame()
    {
        SceneManager.LoadScene("TheChateau");
    }
}
