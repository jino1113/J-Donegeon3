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

    [SerializeField] private AudioSource AudioSource;

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
            Score[2].text = GameScore.Instance.SecretPoint.ToString() + "/X";

            if (GameScore.Instance.TimeScore <= 45 && GameScore.Instance.DirtyScore >= 80)
            {
                GradeList[0].SetActive(true);
            }
            else if (GameScore.Instance.TimeScore <= 50 && GameScore.Instance.DirtyScore >= 60)
            {
                GradeList[1].SetActive(true);
            }
            else if (GameScore.Instance.TimeScore <= 60 && GameScore.Instance.DirtyScore >= 40)
            {
                GradeList[2].SetActive(true);
            }
            else if (GameScore.Instance.TimeScore <= 70 && GameScore.Instance.DirtyScore >= 20)
            {
                GradeList[3].SetActive(true);
            }
            else if (GameScore.Instance.DirtyScore <= 0 || (GameScore.Instance.TimeScore <= 80 && GameScore.Instance.DirtyScore <= 19.99))
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
