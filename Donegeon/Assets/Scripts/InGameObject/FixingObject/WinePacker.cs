using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinePacker : MonoBehaviour
{
    [SerializeField] private List<GameObject> WineHolePos;
    private int i;

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
    }
}
