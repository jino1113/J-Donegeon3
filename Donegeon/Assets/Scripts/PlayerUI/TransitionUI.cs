using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionUI : MonoBehaviour
{




    public void CloseTransition()
    {
        GameControllerManager.Instance.isDead = false;
    }
}
