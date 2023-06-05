using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTutorial : MonoBehaviour
{
    private bool hasTriggered = false;

    public float speed = 2f;
    public float height = 1f;

    private float originalY;

    Vector3 thispost; 

    void Start()
    {
        originalY = 5.31f;
    }

    void FixedUpdate()
    {
        float newY = originalY + Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && !hasTriggered)
        {
            int i = TutorialCore.Instance.tutorialPhase;
            TutorialCore.Instance.MoveArrow(i, TutorialCore.Instance.messagedialog[i]);
            Vector3 arrowpost = TutorialCore.Instance.arrowPost[i];
            originalY = arrowpost.y;
            thispost.x = arrowpost.x;
            thispost.z = arrowpost.z;
            Debug.Log("HIT");
            hasTriggered = true;
            StartCoroutine(WaitAndExecute());
        }

    }

    private IEnumerator WaitAndExecute()
    {
        yield return new WaitForSeconds(2f);
        hasTriggered = false;
    }

}
