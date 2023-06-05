using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialCore : MonoBehaviour
{
    public static TutorialCore Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public GameObject player;
    public GameObject compass;
    public bool pressPhase = false;
    public int tutorialPhase = 0;

    public List<GameObject> pressBut = new List<GameObject>();
    public List<Vector3> arrowPost = new List<Vector3>();
    public List<string> messagedialog = new List<string>();

    public GameObject arrowTutorial;

    private void Start()
    {
        //compass.SetActive(false);
        Animator animator = pressBut[1].GetComponent<Animator>();
        animator.SetBool("SetPlay", true);
        animator.Play("Press1");
    }

    private void FixedUpdate()
    {
        ToolChangePhase();
    }

    void ToolChangePhase()
    {
        if (pressPhase == false)
        {
            PlayerScript.Instance.m_Move = Vector2.zero;
            arrowTutorial.SetActive(false);
            if (Input.GetKey(KeyCode.Alpha2))
            {
                Animator animator = pressBut[1].GetComponent<Animator>();
                animator.SetBool("SetPlay", false);
                animator.Play("Press1");

                Text text = pressBut[1].GetComponent<Text>();
                text.color = Color.green;

                Animator animator1 = pressBut[2].GetComponent<Animator>();
                animator1.SetBool("SetPlay", true);
                animator1.Play("Press1");
            }
            else if (Input.GetKey(KeyCode.Alpha3))
            {
                Animator animator = pressBut[2].GetComponent<Animator>();
                animator.SetBool("SetPlay", false);
                animator.Play("Press1");

                Text text = pressBut[2].GetComponent<Text>();
                text.color = Color.green;

                Animator animator1 = pressBut[3].GetComponent<Animator>();
                animator1.SetBool("SetPlay", true);
                animator1.Play("Press1");
            }
            else if (Input.GetKey(KeyCode.Alpha4))
            {
                Animator animator = pressBut[3].GetComponent<Animator>();
                animator.SetBool("SetPlay", false);
                animator.Play("Press1");

                Text text = pressBut[3].GetComponent<Text>();
                text.color = Color.green;

                Animator animator1 = pressBut[0].GetComponent<Animator>();
                animator1.SetBool("SetPlay", true);
                animator1.Play("Press1");

            }
            else if (Input.GetKey(KeyCode.Alpha1))
            {
                pressPhase = true;
                MoveArrow(tutorialPhase, messagedialog[tutorialPhase]);
                /*arrowTutorial.SetActive(true);
                Animator animator = pressBut[0].GetComponent<Animator>();                
                Text _text = pressBut[0].GetComponent<Text>();
                _text.text = "MOVE TO ARROW";
                animator.SetBool("SetPlay", true);
                animator.Play("Press1");*/

                for (int i = 1; i < 4; i++)
                {
                    Text atext = pressBut[i].GetComponent<Text>();
                    atext.color = Color.yellow;
                    atext.text = "";
                }
            }
        }
        else
        {
            return;
        }
    }

    public void MoveArrow(int i , string message)
    {
        arrowTutorial.transform.position = arrowPost[i];
        arrowTutorial.SetActive(true);
        //---------------------
        Animator animator = pressBut[0].GetComponent<Animator>();
        Text _text = pressBut[0].GetComponent<Text>();
        _text.text = message;
        animator.SetBool("SetPlay", true);
        animator.Play("Press1");

        tutorialPhase += 1;

        if (tutorialPhase == 6)
        {
            Destroy(arrowTutorial);
            Destroy(this);
        }

    }



}
