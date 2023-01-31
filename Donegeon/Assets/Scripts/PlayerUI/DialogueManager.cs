using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public List<string> sentence;


    private bool locker;
    void Start()
    {
        locker = false;
        sentence = new List<string>();
    }

    public void StartDialogue(string sentenceInfo,Text dialogueText,GameObject spirteGameObject, GameObject setActiveGameObject)
    {
        Debug.Log("Prepare to type");
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentenceInfo, dialogueText, spirteGameObject, setActiveGameObject));
        sentence.Clear();
    }

    IEnumerator WaitForStart(GameObject firstGameObject, GameObject secondGameObject)
    {
        yield return new WaitForSeconds(5f);
        firstGameObject.SetActive(false);
        secondGameObject.SetActive(false);
    }

    IEnumerator TypeSentence(string sentence,Text dialogueText,GameObject spriteGameObject, GameObject setActiveGameObject)
    {
        Debug.Log("Start typing");
        spriteGameObject.SetActive(true);
        Debug.Log("Active sprite");
        setActiveGameObject.SetActive(true);
        dialogueText.text = "";
        int i = 0;
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            Debug.Log("Now typing" + ", Max char is " + sentence.Length);
            i++;
            if (i >= sentence.Length)
            {
                Debug.Log("Stop typing");
                StopAllCoroutines();

                StartCoroutine(WaitForStart(spriteGameObject,setActiveGameObject));

            }
            yield return new WaitForSeconds(0.035f);
        }
    }
}
