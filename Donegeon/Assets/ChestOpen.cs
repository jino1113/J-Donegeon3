using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    public bool m_IsOpen;

    [SerializeField] private Animator m_Animator;

    void LateUpdate()
    {
        checkToOpenChest();
    }

    void checkToOpenChest()
    {
        if (m_IsOpen == true)
        {
            m_Animator.SetBool("Open",true);
        }
        else
        {
            m_Animator.SetBool("Open", false);
        }
    }
}
