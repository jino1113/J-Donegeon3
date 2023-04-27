using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameControllerManager : MonoBehaviour
{
    [SerializeField] double NowTime;

    [SerializeField] private Text OverallProgress;
    [SerializeField] private List<Text> QuestNameTextList;

    [SerializeField] private float NowDirtyScore, GateOpenScore;

    [SerializeField] private List<Animator> AnimatorController;

    [SerializeField] private List<GameObject> FogGateGameObjects;

    [SerializeField] private GameObject[] DeadPanelGameObject;
    private int PreviousDeadPanel;
    [SerializeField] private GameObject SceneName;

    public AudioSource AudioSource;
    [SerializeField] private AudioClip AudioClips;

    public bool Pause,Ending,isDead;
    public float CleanPercentScore;
    public double scoreTime;
    public int SecretScore;

    public List<int> DieCounter;

    bool open = false;

    private int OldSecret;
    public Color ClearQuestColor;

    private int x;

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
        x = 0;
        OldSecret = 0;
        SecretScore = 0;
        Ending = false;
        Pause = false;
        NowTime = 0;

        DieCounter[0] = 0;
        DieCounter[1] = 0;
        DieCounter[2] = 0;
        DieCounter[3] = 0;
        DieCounter[4] = 0;
        DieCounter[5] = 0;

    }

    void Update()
    {
        NowTime += Time.deltaTime;
    }

    void LateUpdate()
    {
        CheckAllQuestObject();
        CleaningPercent();
        CheckDead();

        if (Pause == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
        }

        OverallProgress.text = "Progress: " + CleanPercentScore + "%";

        if (SecretScore > OldSecret)
        {
            PlayQuestSFX();
            OldSecret = SecretScore;
        }
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
                for (int index = 0; index <= 17; index++)
                {
                    AnimatorController[index].SetBool("Fade", true);
                    index++;
                }
            }
            StartCoroutine(FogGateOpen());
            StartCoroutine(WaitTimer());
            AnimatorController = null;
            // PlayQuestSFX();

        }

        if (open == true || Input.GetKeyDown(KeyCode.O))
        {
            if (AnimatorController != null)
            {
                for (int index = 18; index <= 26; index++)
                {
                    AnimatorController[index].SetBool("Fade", true);
                    index++;
                }
            }
            StartCoroutine(ArenaGateOpen());
            AnimatorController = null;
            //PlayQuestSFX();
        }
    }

    void CleaningPercent()
    {
        NowDirtyScore = 0;
        NowDirtyScore += PointArrow.Instance.LitterCount;
        NowDirtyScore += PointArrow.Instance.BloodCount;
        NowDirtyScore += PointArrow.Instance.BrokenWallCount;
        NowDirtyScore += PointArrow.Instance.CandleCount;

        float i = PointArrow.Instance.NowScore / 4f;
        CleanPercentScore = i;
    }

    void CheckDead()
    {
        int randomIndex = Random.Range(0, DeadPanelGameObject.Length);
        if (x == 0)
        {
            if (isDead == true)
            {
                ChangeDead();
                x += 1;
                PreviousDeadPanel = randomIndex;
                DeadPanelGameObject[randomIndex].SetActive(true);
            }
        }
        if (isDead == false)
        {
            x = 0;
            DeadPanelGameObject[0].SetActive(false);
            DeadPanelGameObject[1].SetActive(false);
            DeadPanelGameObject[2].SetActive(false);
        }
    }


    public void ChangeDead()
    {
        if (isDead == true)
        {
            Time.timeScale = 1f;
            if (DieCounter[0] + DieCounter[1] + DieCounter[2] + DieCounter[3] + DieCounter[4] + DieCounter[5] == 3)
            {
                PointArrow.Instance.Triggers["Quest16"] = true;
            }
            if (DieCounter[0] + DieCounter[1] + DieCounter[2] + DieCounter[3] + DieCounter[4] + DieCounter[5] == 4)
            {
                PointArrow.Instance.Triggers["Quest17"] = true;
            }
            if (DieCounter[0] + DieCounter[1] + DieCounter[2] + DieCounter[3] + DieCounter[4] + DieCounter[5] == 5)
            {
                PointArrow.Instance.Triggers["Quest18"] = true;
            }
        }
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
            scoreTime = Math.Ceiling(scoreTime);

            Time.timeScale = 1;
            SceneManager.LoadScene("MenuScene");

            StartCoroutine(GameReloadTimer());
            Ending = true;
        }
    }

    void PlayQuestSFX()
    {
        if (AudioSource.isPlaying == false)
        {
            AudioSource.PlayOneShot(AudioClips);
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
        yield return new WaitForSeconds(7);

        FogGateGameObjects[0].SetActive(false);
        FogGateGameObjects[1].SetActive(false);
    }

    IEnumerator WaitTimer()
    {
        yield return new WaitForSeconds(300);
        open = true;
    }

    IEnumerator ArenaGateOpen()
    {
        PointArrow.Instance.Triggers["Quest23"] = true;
        yield return new WaitForSeconds(7);
        FogGateGameObjects[2].SetActive(false);

    }

    IEnumerator GameReloadTimer()
    {
        yield return new WaitForSeconds(0.2f);
    }

}
