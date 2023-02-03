using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablerGameobject : MonoBehaviour
{
    [SerializeField] private List<GameObject> WantToDisableList;

    [SerializeField] private Animator m_Animator;
    public bool kindle;
    [Header("Is reversed SetActive?")]
    [SerializeField] private bool m_Reversed;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        kindle = false;
    }

    void Update()
    {
        CheckKindle();
    }

    private void CheckKindle()
    {
        switch (m_Reversed)
        {
            case true when kindle == false:
            {
                //if kindle false = Active true
                foreach (var Item in WantToDisableList)
                {
                    Item.SetActive(true);
                }
                if (m_Animator != null && m_Animator.GetBool("Pull") == false)
                {
                    Debug.Log("Pull0");
                    m_Animator.SetBool("Pull", true);
                }

                PointArrow.Instance.Triggers["Recheck"] = true;
                StartCoroutine(WaitFalse());

                    break;
            }
            case true:
            {
                if(kindle == true)
                {
                    //if kindle true = Active false
                    foreach (var Item in WantToDisableList)
                    {
                        Item.SetActive(false);
                    }
                    if (m_Animator != null && m_Animator.GetBool("Pull") == true)
                    {
                        Debug.Log("Pull1");
                        m_Animator.SetBool("Pull", false);
                    }
                    PointArrow.Instance.Triggers["Recheck"] = true;
                    StartCoroutine(WaitFalse());

                }

                break;
            }
            case false when kindle == false:
            {
                //if kindle false = Active false
                foreach (var Item in WantToDisableList)
                {
                    Item.SetActive(false);
                }
                if (m_Animator != null && m_Animator.GetBool("Pull") == false)
                {
                    Debug.Log("Pull2");

                    m_Animator.SetBool("Pull", true);
                }
                PointArrow.Instance.Triggers["Recheck"] = true;
                StartCoroutine(WaitFalse());

                    break;
            }
            case false:
            {
                if (kindle == true)
                {
                    //if kindle true = Active true
                    foreach (var Item in WantToDisableList)
                    {
                        Item.SetActive(true);
                    }
                    if (m_Animator != null && m_Animator.GetBool("Pull") == true)
                    {
                        Debug.Log("Pull3");

                        m_Animator.SetBool("Pull", false);
                    }
                    PointArrow.Instance.Triggers["Recheck"] = true;
                    StartCoroutine(WaitFalse());
                }
                break;
            }
        }
    }

    IEnumerator WaitFalse()
    {
        yield return new WaitForSeconds(0.5f);
        PointArrow.Instance.Triggers["Recheck"] = false;
    }
}
