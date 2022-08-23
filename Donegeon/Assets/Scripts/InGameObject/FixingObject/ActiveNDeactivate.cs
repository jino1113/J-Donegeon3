using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveNDeactivate : MonoBehaviour
{
    public float FixingProgress;
    public float MaxProgress;


    [SerializeField] private GameObject ChildBrokeGameObject;
    [SerializeField] private GameObject ChildFixedGameObject;


    void Start()
    {
        ChildFixedGameObject.SetActive(false);
    }


    void FixedUpdate()
    {
        CheckActive();
    }

    void CheckActive()
    {
        if (!(FixingProgress >= MaxProgress)) return;
        if (!ChildBrokeGameObject.activeSelf)
        {
            ChildFixedGameObject.SetActive(true);
        }

    }
}