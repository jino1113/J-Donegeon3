using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public static DialogueTrigger Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(1);
    }


}
