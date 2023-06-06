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
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private float Time;

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
        for (int i = 0; i < 39; i++)
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
            //|| PointArrow.Instance.Triggers["Quest4"] == true && LockerBools[1] == false
            || PointArrow.Instance.Triggers["Quest5"] == true && LockerBools[1] == false)
        {
            TriggerDialogue(1);
            LockerBools[1] = true;
        }
        if (PointArrow.Instance.Triggers["Quest1"] != true && PointArrow.Instance.Triggers["Quest2"] == true && LockerBools[2] == false
            || PointArrow.Instance.Triggers["Quest1"] != true && PointArrow.Instance.Triggers["Quest3"] == true && LockerBools[2] == false
            //|| PointArrow.Instance.Triggers["Quest1"] != true && PointArrow.Instance.Triggers["Quest4"] == true && LockerBools[2] == false
            || PointArrow.Instance.Triggers["Quest1"] != true && PointArrow.Instance.Triggers["Quest5"] == true && LockerBools[2] == false
            || PointArrow.Instance.Triggers["Quest2"] != true && PointArrow.Instance.Triggers["Quest3"] == true && LockerBools[2] == false
            //|| PointArrow.Instance.Triggers["Quest2"] != true && PointArrow.Instance.Triggers["Quest4"] == true && LockerBools[2] == false
            || PointArrow.Instance.Triggers["Quest2"] != true && PointArrow.Instance.Triggers["Quest5"] == true && LockerBools[2] == false
            //|| PointArrow.Instance.Triggers["Quest3"] != true && PointArrow.Instance.Triggers["Quest4"] == true && LockerBools[2] == false
            || PointArrow.Instance.Triggers["Quest3"] != true && PointArrow.Instance.Triggers["Quest5"] == true && LockerBools[2] == false
            /*|| PointArrow.Instance.Triggers["Quest4"] != true && PointArrow.Instance.Triggers["Quest5"] == true && LockerBools[2] == false*/)
        {
            TriggerDialogue(2);
            LockerBools[2] = true;
        }
        if (PointArrow.Instance.Triggers["Quest1"] == true && PointArrow.Instance.Triggers["Quest2"] == true && PointArrow.Instance.Triggers["Quest3"] == true && LockerBools[3] == false
            || PointArrow.Instance.Triggers["Quest1"] == true && PointArrow.Instance.Triggers["Quest2"] == true /*&& PointArrow.Instance.Triggers["Quest4"] */&& LockerBools[3] == false
            || PointArrow.Instance.Triggers["Quest1"] == true && PointArrow.Instance.Triggers["Quest2"] == true && PointArrow.Instance.Triggers["Quest5"] == true && LockerBools[3] == false
            || PointArrow.Instance.Triggers["Quest1"] == true && PointArrow.Instance.Triggers["Quest3"] == true && PointArrow.Instance.Triggers["Quest5"] == true && LockerBools[3] == false
            || PointArrow.Instance.Triggers["Quest1"] == true && PointArrow.Instance.Triggers["Quest3"] == true /*&& PointArrow.Instance.Triggers["Quest4"] */&& LockerBools[3] == false
            || PointArrow.Instance.Triggers["Quest2"] == true && PointArrow.Instance.Triggers["Quest3"] == true /*&& PointArrow.Instance.Triggers["Quest4"] */&& LockerBools[3] == false
            || PointArrow.Instance.Triggers["Quest2"] == true && PointArrow.Instance.Triggers["Quest3"] == true && PointArrow.Instance.Triggers["Quest5"] == true && LockerBools[3] == false
            || PointArrow.Instance.Triggers["Quest2"] == true /*&& PointArrow.Instance.Triggers["Quest4"] == true*/ && PointArrow.Instance.Triggers["Quest5"] == true && LockerBools[3] == false
            || PointArrow.Instance.Triggers["Quest3"] == true /*&& PointArrow.Instance.Triggers["Quest4"] == true*/ && PointArrow.Instance.Triggers["Quest5"] == true && LockerBools[3] == false)
        {
            TriggerDialogue(3);
            LockerBools[3] = true;
        }
        if (PointArrow.Instance.Triggers["Quest1"] == true 
            && PointArrow.Instance.Triggers["Quest2"] == true 
            && PointArrow.Instance.Triggers["Quest3"] == true 
            //&& PointArrow.Instance.Triggers["Quest4"] == true
            && PointArrow.Instance.Triggers["Quest5"] == true && LockerBools[4] == false)
        {
            TriggerDialogue(4);
            LockerBools[4] = true;
        }
        if (!Input.anyKey)
        {
            Time += UnityEngine.Time.deltaTime;
            if (Time >= 30 && LockerBools[5] == false)
            {
                TriggerDialogue(5);
                LockerBools[5] = true;
            }
            else if(Time <= 3 && LockerBools[5] == true && LockerBools[6] == false)
            {
                TriggerDialogue(6);
                LockerBools[6] = true;
            }
        }
        else
        {
            Time = 0;
            LockerBools[5] = false;
            LockerBools[6] = false;
        }
        if (PointArrow.Instance.Triggers["Quest6"] == true && LockerBools[7] == false)
        {
            TriggerDialogue(7);
            LockerBools[7] = true;
        }
        if (PointArrow.Instance.Triggers["Quest7"] == true && LockerBools[8] == false)
        {
            TriggerDialogue(8);
            LockerBools[8] = true;
        }
        if (PointArrow.Instance.Triggers["Quest5"] == true && LockerBools[9] == false)
        {
            TriggerDialogue(9);
            LockerBools[9] = true;
        }
        if (PointArrow.Instance.Triggers["Quest10"] == true && LockerBools[10] == false)
        {
            TriggerDialogue(10);
            LockerBools[10] = true;
        }
        if (PointArrow.Instance.Triggers["Quest11"] == true && LockerBools[11] == false)
        {
            TriggerDialogue(11);
            LockerBools[11] = true;
        }
        if (PointArrow.Instance.Triggers["Quest12"] == true && LockerBools[12] == false)
        {
            TriggerDialogue(12);
            LockerBools[12] = true;
        }
        if (PointArrow.Instance.Triggers["Quest14"] == true && LockerBools[13] == false)
        {
            TriggerDialogue(13);
            LockerBools[13] = true;
        }
        if (PointArrow.Instance.Triggers["Quest16"] == true && LockerBools[14] == false)
        {
            TriggerDialogue(14);
            LockerBools[14] = true;
        }
        if (PointArrow.Instance.Triggers["Quest17"] == true && LockerBools[15] == false)
        {
            TriggerDialogue(15);
            LockerBools[15] = true;
        }
        if (PointArrow.Instance.Triggers["Quest18"] == true && LockerBools[16] == false)
        {
            TriggerDialogue(16);
            LockerBools[16] = true;
        }
        if (PointArrow.Instance.Triggers["Quest19"] == true && LockerBools[17] == false)
        {
            TriggerDialogue(17);
            LockerBools[17] = true;
        }
        if (PointArrow.Instance.Triggers["Quest20"] == true && LockerBools[18] == false)
        {
            TriggerDialogue(18);
            LockerBools[18] = true;
        }
        if (PointArrow.Instance.Triggers["Quest21"] == true && LockerBools[19] == false)
        {
            TriggerDialogue(19);
            LockerBools[19] = true;
        }
        //Break wine bottle
        if (PointArrow.Instance.Triggers["Quest22"] == true && LockerBools[20] == false)
        {
            TriggerDialogue(20);
            LockerBools[20] = true;
        }
        //Look at painting
        if (PointArrow.Instance.Triggers["Quest8"] == true && LockerBools[21] == false)
        {
            TriggerDialogue(21);
            LockerBools[21] = true;
        }
        //Arena area open
        if (PointArrow.Instance.Triggers["Quest23"] == true && LockerBools[22] == false)
        {
            TriggerDialogue(22);
            LockerBools[22] = true;
        }
        //Aye found
        if (PointArrow.Instance.Triggers["Quest24"] == true && LockerBools[23] == false)
        {
            TriggerDialogue(23);
            LockerBools[23] = true;
        }
        //Entry Arena 
        if (PointArrow.Instance.Triggers["Quest25"] == true && LockerBools[24] == false)
        {
            TriggerDialogue(24);
            LockerBools[24] = true;
        }
        //Office entry
        if (PointArrow.Instance.Triggers["Quest26"] == true && LockerBools[25] == false)
        {
            TriggerDialogue(25);
            LockerBools[25] = true;
        }
        //First see BonFire Lit
        if (PointArrow.Instance.Triggers["Quest27"] == true && LockerBools[26] == false)
        {
            TriggerDialogue(26);
            LockerBools[26] = true;
        }
        //First pick Skyrim Helmet
        if (PointArrow.Instance.Triggers["Quest28"] == true && LockerBools[27] == false)
        {
            TriggerDialogue(27);
            LockerBools[27] = true;
        }
        //Switch on torch in Treasure room
        if (PointArrow.Instance.Triggers["Quest29"] == true && LockerBools[28] == false)
        {
            TriggerDialogue(28);
            LockerBools[28] = true;
        }
        //-
        if (PointArrow.Instance.Triggers["Quest30"] == true && LockerBools[29] == false)
        {
            TriggerDialogue(29);
            LockerBools[29] = true;
        }
        //First pick Crown
        if (PointArrow.Instance.Triggers["Quest31"] == true && LockerBools[30] == false)
        {
            TriggerDialogue(30);
            LockerBools[30] = true;
        }
        //Bring the Crown to Treasure room
        if (PointArrow.Instance.Triggers["Quest32"] == true && LockerBools[31] == false)
        {
            TriggerDialogue(31);
            LockerBools[31] = true;
        }
        //Bring CD to gramophone first time
        if (PointArrow.Instance.Triggers["Quest33"] == true && LockerBools[32] == false)
        {
            TriggerDialogue(32);
            LockerBools[32] = true;
        }
        //Enter another office room
        if (PointArrow.Instance.Triggers["Quest34"] == true && LockerBools[33] == false)
        {
            TriggerDialogue(33);
            LockerBools[33] = true;
        }
        //Look at TV for 10s
        if (PointArrow.Instance.Triggers["Quest35"] == true && LockerBools[34] == false)
        {
            TriggerDialogue(34);
            LockerBools[34] = true;
        }
        //Collect the golden hammer
        if (PointArrow.Instance.Triggers["Quest36"] == true && LockerBools[35] == false)
        {
            TriggerDialogue(35);
            LockerBools[35] = true;
        }
        //Collect the golden hands
        if (PointArrow.Instance.Triggers["Quest37"] == true && LockerBools[36] == false)
        {
            TriggerDialogue(36);
            LockerBools[36] = true;
        }


    }

    void TriggerNarrator(int number)
    {
        if (audioClips[number] != null)
        {
            if (GameControllerManager.Instance.AudioSource.isPlaying)
            {
                GameControllerManager.Instance.AudioSource.Stop();
            }
            GameControllerManager.Instance.AudioSource.PlayOneShot(audioClips[number]);
        }
    }


    void TriggerDialogue(int number)
    {
        TriggerNarrator(number);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue.DialogueInfo[number].Sentence, DialogueText, dialogue.DialogueInfo[number].Sprite[0], DialogueBox);
    }


    IEnumerator DelayDialogueEnumerator(float Timer,int Index)
    {
        yield return new WaitForSeconds(Timer);
        TriggerDialogue(Index);
        LockerBools[Index] = true;
    }

}
