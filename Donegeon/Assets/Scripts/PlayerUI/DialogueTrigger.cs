using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public static DialogueTrigger Instance;


    [SerializeField] private GameObject DialogueBox;
    [SerializeField] private Text DialogueText; 

    public Dictionary<int, bool> LockerBools = new Dictionary<int, bool>();


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        for (int i = 0; i < 23; i++)
        {
            LockerBools[i] = false;
        }
    }

    void LateUpdate()
    {
        if (LockerBools[0] == false)
        {
            TriggerDialogue(0);
            LockerBools[0] = true;
        }
        if (PointArrow.Instance.Triggers["Quest1"] == true && LockerBools[1] == false
            || PointArrow.Instance.Triggers["Quest2"] == true && LockerBools[1] == false
            || PointArrow.Instance.Triggers["Quest3"] == true && LockerBools[1] == false
            || PointArrow.Instance.Triggers["Quest4"] == true && LockerBools[1] == false
            || PointArrow.Instance.Triggers["Quest5"] == true && LockerBools[1] == false)
        {
            TriggerDialogue(1);
            LockerBools[1] = true;
        }
        if (PointArrow.Instance.Triggers["Quest1"] != true && PointArrow.Instance.Triggers["Quest2"] == true && LockerBools[2] == false
            || PointArrow.Instance.Triggers["Quest1"] != true && PointArrow.Instance.Triggers["Quest3"] == true && LockerBools[2] == false
            || PointArrow.Instance.Triggers["Quest1"] != true && PointArrow.Instance.Triggers["Quest4"] == true && LockerBools[2] == false
            || PointArrow.Instance.Triggers["Quest1"] != true && PointArrow.Instance.Triggers["Quest5"] == true && LockerBools[2] == false
            || PointArrow.Instance.Triggers["Quest2"] != true && PointArrow.Instance.Triggers["Quest3"] == true && LockerBools[2] == false
            || PointArrow.Instance.Triggers["Quest2"] != true && PointArrow.Instance.Triggers["Quest4"] == true && LockerBools[2] == false
            || PointArrow.Instance.Triggers["Quest2"] != true && PointArrow.Instance.Triggers["Quest5"] == true && LockerBools[2] == false
            || PointArrow.Instance.Triggers["Quest3"] != true && PointArrow.Instance.Triggers["Quest4"] == true && LockerBools[2] == false
            || PointArrow.Instance.Triggers["Quest3"] != true && PointArrow.Instance.Triggers["Quest5"] == true && LockerBools[2] == false
            || PointArrow.Instance.Triggers["Quest4"] != true && PointArrow.Instance.Triggers["Quest5"] == true && LockerBools[2] == false)
        {
            TriggerDialogue(2);
            LockerBools[2] = true;
        }
        if (PointArrow.Instance.Triggers["Quest1"] == true && PointArrow.Instance.Triggers["Quest2"] == true && PointArrow.Instance.Triggers["Quest3"] && LockerBools[3] == false
            || PointArrow.Instance.Triggers["Quest1"] == true && PointArrow.Instance.Triggers["Quest2"] == true && PointArrow.Instance.Triggers["Quest4"] && LockerBools[3] == false
            || PointArrow.Instance.Triggers["Quest1"] == true && PointArrow.Instance.Triggers["Quest2"] == true && PointArrow.Instance.Triggers["Quest5"] && LockerBools[3] == false
            || PointArrow.Instance.Triggers["Quest1"] == true && PointArrow.Instance.Triggers["Quest3"] == true && PointArrow.Instance.Triggers["Quest5"] && LockerBools[3] == false
            || PointArrow.Instance.Triggers["Quest1"] == true && PointArrow.Instance.Triggers["Quest3"] == true && PointArrow.Instance.Triggers["Quest4"] && LockerBools[3] == false
            || PointArrow.Instance.Triggers["Quest2"] == true && PointArrow.Instance.Triggers["Quest3"] == true && PointArrow.Instance.Triggers["Quest4"] && LockerBools[3] == false
            || PointArrow.Instance.Triggers["Quest2"] == true && PointArrow.Instance.Triggers["Quest3"] == true && PointArrow.Instance.Triggers["Quest5"] && LockerBools[3] == false
            || PointArrow.Instance.Triggers["Quest2"] == true && PointArrow.Instance.Triggers["Quest4"] == true && PointArrow.Instance.Triggers["Quest5"] && LockerBools[3] == false
            || PointArrow.Instance.Triggers["Quest3"] == true && PointArrow.Instance.Triggers["Quest4"] == true && PointArrow.Instance.Triggers["Quest5"] && LockerBools[3] == false)
        {
            TriggerDialogue(3);
            LockerBools[3] = true;
        }
    }

    void TriggerDialogue(int number)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue.DialogueInfo[number].Sentence, DialogueText, dialogue.DialogueInfo[number].Sprite[0], DialogueBox);
    }


}
