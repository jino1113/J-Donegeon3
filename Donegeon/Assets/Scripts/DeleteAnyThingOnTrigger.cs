using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAnyThingOnTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        Destroy(collider.transform.root.gameObject);

        Destroy(collider.gameObject);
    }
}
