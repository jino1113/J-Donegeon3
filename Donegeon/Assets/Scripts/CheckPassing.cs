using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPassing : MonoBehaviour
{
    [SerializeField] private int QuestIndex;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            PointArrow.Instance.Triggers["Quest" + QuestIndex] = true;
        }
    }
}
