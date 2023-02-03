using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdingPaper : MonoBehaviour
{
    [SerializeField] private GameObject paperHolder;
    [SerializeField] private GameObject closeButton;
    public bool isHolding;


    void Update()
    {
        if (isHolding == true)
        {
            paperHolder.SetActive(true);
            closeButton.SetActive(true);
            GameControllerManager.Instance.Pause = true;
        }
        else if (isHolding == false)
        {
            paperHolder.SetActive(false);
        }

    }

    public void ChangeIsHolding()
    {
        isHolding = false;
        GameControllerManager.Instance.Pause = false;

    }
}
