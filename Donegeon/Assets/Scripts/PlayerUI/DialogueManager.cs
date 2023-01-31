using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public List<string> sentence;
    [SerializeField] private GameObject DialogueGameObject;
    [SerializeField] private Text DialogueText;

    private bool isEnd;


    void Start()
    {
        sentence = new List<string>();
    }

    public void StartDialogue(int number)
    {
        StartCoroutine(TypeSentence(sentence[number]));

    }

    public void DisplaySentence()
    {
        sentence.Clear();

    }

    public void EndDialogue()
    {
        if (isEnd == false)
        {
            isEnd = true;
        }
    }

    IEnumerator WaitForStart()
    {
        yield return new WaitForSeconds(0.5f);
    }



    IEnumerator TypeSentence(string sentence)
    {

        DialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {

            DialogueText.text += letter;
            yield return null;
        }
    }
}
