using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPassing : MonoBehaviour
{
    [SerializeField] private int QuestIndex;
    [SerializeField] private bool Secret;


    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" && PointArrow.Instance.Triggers["Quest" + QuestIndex] == false)
        {
            PointArrow.Instance.Triggers["Quest" + QuestIndex] = true;
            if (Secret == true)
            {
                GameControllerManager.Instance.SecretScore += 1;

            }
        }
    }
}
