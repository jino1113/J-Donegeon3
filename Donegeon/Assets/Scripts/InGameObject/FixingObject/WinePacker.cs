using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinePacker : MonoBehaviour
{
    [SerializeField] private List<GameObject> WineHolePos;
    private int i;
    [SerializeField] private bool Secret;
    [SerializeField] private bool Disc;

    void Start()
    {
        i = 0;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Wine")
        {
            collider.GetComponent<Collider>().isTrigger = true;
            collider.GetComponent<Rigidbody>().useGravity = false;
            collider.GetComponent<Rigidbody>().isKinematic = true;
            collider.gameObject.transform.position = WineHolePos[i].transform.position;
            collider.gameObject.transform.rotation = WineHolePos[i].gameObject.transform.rotation;
            i++;

        }

        if (Secret == true)
        {
            if (collider.gameObject.tag == "Crown")
            {
                PointArrow.Instance.Triggers["Quest32"] = true;
                GameControllerManager.Instance.SecretScore += 1;
                collider.GetComponent<Collider>().isTrigger = true;
                collider.GetComponent<Rigidbody>().useGravity = false;
                collider.GetComponent<Rigidbody>().isKinematic = true;
                collider.gameObject.transform.position = WineHolePos[i].transform.position;
                collider.gameObject.transform.rotation = WineHolePos[i].gameObject.transform.rotation;
                i++;
            }
        }

        if (Disc == true)
        {
            if (collider.gameObject.tag == "Disc")
            {
                collider.GetComponent<Collider>().isTrigger = true;
                collider.GetComponent<Rigidbody>().useGravity = false;
                collider.GetComponent<Rigidbody>().isKinematic = true;
                collider.gameObject.transform.position = WineHolePos[i].transform.position;
                collider.gameObject.transform.rotation = WineHolePos[i].gameObject.transform.rotation;
                i++;
            }
        }
    }
}
