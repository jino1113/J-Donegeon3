using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeToOtherByHits : MonoBehaviour
{

    [SerializeField] private List<GameObject> SoupList;
    [SerializeField] private List<Collider> Collider;
    [SerializeField] private int Meat,Potato,Mushroom,Vegetable,Litter;

    private bool CheckSoup;

    private int i;

    void Start()
    {
        CheckSoup = false;
        Litter = 0;
        Meat = 0;
        Potato = 0;
        Mushroom = 0;
        Vegetable = 0;
        i = 0;
    }

    void LateUpdate()
    {
        ChangeSoup();
    }

    void ChangeSoup()
    {


        if (CheckSoup == false)
        {
            if (Litter >= 1 && CheckSoup == false)
            {
                CheckSoup = true;
                SoupList[2].SetActive(true);
                SoupList[1].SetActive(false);
                SoupList[0].SetActive(false);

            }
            if (Meat >= 1 && Vegetable >= 2 && Potato >= 3 && Mushroom >= 2 && CheckSoup == false)
            {
                CheckSoup = true;
                SoupList[1].SetActive(true);
                SoupList[0].SetActive(false);
                StartCoroutine(Wait(1f));

            }
        }
    }



    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Meat")
        {
            Destroy(collider.gameObject);
            Meat++;
            i++;
        }
        if (collider.gameObject.tag == "Potato")
        {
            Destroy(collider.gameObject);
            Potato++;
            i++;
        }
        if (collider.gameObject.tag == "Mushroom")
        {
            Destroy(collider.gameObject);
            Mushroom++;
            i++;
        }
        if (collider.gameObject.tag == "Vegetable")
        {
            Destroy(collider.gameObject);
            Vegetable++;
            i++;
        }
        if (collider.gameObject.tag == "Litter")
        {
            Litter++;
            i++;
        }

    }


    IEnumerator Wait(float time)
    {
        Collider[0].isTrigger = true;
        Collider[1].isTrigger = true;
        Collider[2].isTrigger = true;
        yield return new WaitForSeconds(time);
        Collider[0].isTrigger = false;
        Collider[1].isTrigger = false;
        Collider[2].isTrigger = false;
    }
}
